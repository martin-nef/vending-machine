using System;
using System.Collections.Generic;
using System.Linq;
using Core.Dtos;
using Core.Interfaces;
using Core.Models;

namespace Core.Services {
    public class MoneyService : IMoneyService {
        private readonly ICoinRepository _coinRepository;
        private readonly ICoinReturnRepository _coinReturnRepository;

        public MoneyService (
            ICoinRepository coinRepository,
            ICoinReturnRepository coinReturnRepository)
        {
            _coinRepository = coinRepository;
            _coinReturnRepository = coinReturnRepository;
        }

        public double DisplayCurrentAmount()
        {
            throw new NotImplementedException();
        }

        public void InsertCoins (ICollection<CoinDto> coinDtos) {
            var coins = ConvertDtosToModels (coinDtos);
            _coinRepository.InsertCoins (coins);
        }

        private ICollection<Coin> ConvertDtosToModels (ICollection<CoinDto> coins) {
            return coins.Select (dto => new Coin (dto)).ToList ();
        }
    }
}