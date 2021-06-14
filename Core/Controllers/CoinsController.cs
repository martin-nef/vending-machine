﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vending_machine.Core.Dtos;
using vending_machine.Core.Interfaces;
using vending_machine.Core.Models;

namespace vending_machine.Core.Controllers {
    [ApiController]
    [Route ("coins")]
    public class CoinsController : ControllerBase {
        private readonly ILogger<CoinsController> _logger;
        private readonly IMoneyService _moneyService;

        public CoinsController (ILogger<CoinsController> logger, IMoneyService moneyService) {
            _logger = logger;
            _moneyService = moneyService;
        }

        [HttpPost]
        public void InsertCoins (ICollection<CoinDto> coins) {
            _moneyService.InsertCoins(coins);
        }
    }
}