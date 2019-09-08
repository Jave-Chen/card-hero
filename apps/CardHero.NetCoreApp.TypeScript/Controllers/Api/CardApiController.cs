﻿using System.Collections.Generic;
using System.Threading.Tasks;

using CardHero.Core.Abstractions;
using CardHero.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace CardHero.NetCoreApp.TypeScript.Controllers.Api
{
    [Route("api/cards")]
    public class CardApiController : CardHeroControllerBase
    {
        private readonly ICardService _cardService;

        public CardApiController(IUserService userService, ICardService cardService)
            : base(userService)
        {
            _cardService = cardService;
        }

        public async Task<IEnumerable<CardModel>> GetAsync(CardSearchFilter filter)
        {
            filter.UserId = (await GetUserAsync())?.Id;

            var result = await _cardService.GetCardsAsync(filter);

            return result.Results;
        }
    }
}
