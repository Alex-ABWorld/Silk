﻿using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace SilkBot.Commands.General
{
    public class AvatarCommand : BaseCommandModule
    {
        [Command("Avatar")]
        public async Task GetAvatarAsync(CommandContext ctx)
        {
            await ctx.RespondAsync(embed:
                new DiscordEmbedBuilder()
                .WithImageUrl(ctx.User.AvatarUrl.Replace("128", "4096"))
                .WithColor(DiscordColor.CornflowerBlue)
                .WithFooter("Silk", ctx.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now));
        }

        [Command("Avatar")]
        public async Task GetAvatarAsync(CommandContext ctx, DiscordUser user)
        {
            await ctx.RespondAsync(embed:
                new DiscordEmbedBuilder()
                .WithAuthor(ctx.Member.DisplayName, iconUrl: ctx.Member.AvatarUrl)
                .WithDescription($"{user.Mention}'s Avatar")
                .WithImageUrl(user.AvatarUrl.Replace("128", "4096"))
                .WithColor(DiscordColor.CornflowerBlue)
                .WithFooter("Silk", ctx.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now));
        }


        [Command("Avatar")]
        public async Task GetAvatarAsync(CommandContext ctx, [RemainingText] string mention)
        {
            var user = ctx.Guild.Members.First(m => m.Value.DisplayName.ToLower().StartsWith(mention.ToLower())).Value;

            await ctx.RespondAsync(embed:
                new DiscordEmbedBuilder()
                .WithAuthor(ctx.Member.DisplayName, iconUrl: ctx.Member.AvatarUrl)
                .WithDescription($"{user.Mention}'s Avatar")
                .WithImageUrl(user.AvatarUrl.Replace("128", "4096"))
                .WithColor(DiscordColor.CornflowerBlue)
                .WithFooter("Silk", ctx.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now));
        }

    }
}