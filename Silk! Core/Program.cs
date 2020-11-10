﻿namespace SilkBot
{
    using DSharpPlus;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using NLog.Extensions.Logging;
    using SilkBot.Commands.General;
    using SilkBot.Extensions;
    using SilkBot.Services;
    using SilkBot.Tools;
    using SilkBot.Utilities;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class Program
    {
        public static async Task Main(string[] args) => await CreateHostBuilder(args).RunConsoleAsync().ConfigureAwait(false);

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseConsoleLifetime()
            .ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.SetBasePath(Directory.GetCurrentDirectory());
                configuration.AddJsonFile("appSettings.json", false, false);
            })
            .ConfigureServices((context, services) =>
            {
                IConfiguration config = context.Configuration;
                services.AddSingleton(new DiscordShardedClient(config.Get<DiscordConfiguration>("Bot")));
                services.AddDbContext<SilkDbContext>(options => options.UseNpgsql(config.GetConnectionString("dbConnection")));
                services.AddMemoryCache(option => option.ExpirationScanFrequency = TimeSpan.FromHours(1));
                services.AddSingleton<NLogLoggerFactory>();
                services.AddSingleton<PrefixCacheService>();
                services.AddSingleton<GuildConfigCacheService>();
                services.AddSingleton<TicketService>();
                services.AddSingleton<TimedEventService>();
                services.AddSingleton(typeof(HttpClient), (services) =>
                    {
                        var client = new HttpClient();
                        client.DefaultRequestHeaders.UserAgent.ParseAdd("Silk Project by VelvetThePanda / v1.3");
                        return client;
                    });
                services.AddSingleton<Bot>();
            })
            .ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddNLog(context.Configuration["NLog"]);
            });
    }
}