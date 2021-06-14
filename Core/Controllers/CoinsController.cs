using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.Controllers {
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
            _moneyService.InsertCoins (coins);
        }

        [HttpGet, Route ("current")]
        public double DisplayCurrentAmount () {
            return _moneyService.DisplayCurrentAmount ();
        }
    }
}