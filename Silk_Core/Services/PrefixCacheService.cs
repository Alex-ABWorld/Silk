﻿using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SilkBot.Database;
using SilkBot.Models;

namespace SilkBot.Services
{
    public class PrefixCacheService
    {
        private readonly ILogger _logger;
        private readonly ConcurrentDictionary<ulong, string> _cache;
        private readonly IDbContextFactory<SilkDbContext> _dbFactory;
        private readonly Stopwatch _sw = new();
        public PrefixResolverDelegate PrefixDelegate { get; private set; }

        public PrefixCacheService(ILogger<PrefixCacheService> logger, IDbContextFactory<SilkDbContext> dbFactory)
        {
            _logger = logger;

            _cache = new ConcurrentDictionary<ulong, string>();
            _dbFactory = dbFactory;

            PrefixDelegate = ResolvePrefix;
        }

        public async Task<int> ResolvePrefix(DiscordMessage m)
        {
            string prefix = await Task.Run(() => RetrievePrefix(m.Channel.GuildId) ?? string.Empty);
            int prefixPos = m.GetStringPrefixLength(prefix);
            return prefixPos;
        }

        public string? RetrievePrefix(ulong? guildId)
        {
            if (guildId == default || guildId == 0) return null;
            if (_cache.TryGetValue(guildId.Value, out string? prefix)) return prefix;
            return GetPrefixFromDatabase(guildId.Value);
        }

        private string GetPrefixFromDatabase(ulong guildId)
        {
            _logger.LogDebug("Prefix not present in cache; queuing from database.");
            _sw.Restart();
            
            using SilkDbContext db = _dbFactory.CreateDbContext();
            
            GuildModel? guild = db.Guilds.AsNoTracking().FirstOrDefault(g => g.Id == guildId);
            if (guild is null)
            {
                _logger.LogCritical("Guild was not cached on join, and therefore does not exist in database.");
                return Bot.DefaultCommandPrefix;
            }

            _sw.Stop();
            _logger.LogDebug($"Cached {guild.Prefix} - {guildId} in {_sw.ElapsedMilliseconds} ms.");
            _cache.TryAdd(guildId, guild.Prefix);
            
            return guild.Prefix;
        }

        public void UpdatePrefix(ulong id, string prefix)
        {
            _cache.TryGetValue(id, out string? currentPrefix);
            _cache.AddOrUpdate(id, prefix, (i, p) => prefix);
            _logger.LogDebug($"Updated prefix for {id} - {currentPrefix} -> {prefix}");
        }
    }
}