using System;
using System.Collections.Generic;
using System.Linq;
using Core.Dtos;
using Core.Enums;
using Core.Interfaces;
using Core.Models;

namespace Core.Services {
    public class MoneyService : IMoneyService {
        private readonly ICoinRepository _coinRepository;
        private readonly ICoinReturnRepository _coinReturnRepository;

        private readonly List<Denomination> ValidCoins = new List<Denomination> {
            Denomination.Nickel,
            Denomination.Dime,
            Denomination.Quarter,
        };

        public MoneyService (
            ICoinRepository coinRepository,
            ICoinReturnRepository coinReturnRepository) {
            _coinRepository = coinRepository;
            _coinReturnRepository = coinReturnRepository;
        }

        public double DisplayCurrentAmount () {
            throw new NotImplementedException ();
        }

        public void InsertCoins (ICollection<CoinDto> coinDtos) {
            var coins = ConvertDtosToModels (coinDtos);
            var validCoins = GetValidCoins(coins);
            var invalidCoins = GetInvalidCoins(coins);
            _coinRepository.InsertCoins (validCoins);
            _coinReturnRepository.InsertCoins (invalidCoins);
        }

        private ICollection<Coin> ConvertDtosToModels (ICollection<CoinDto> coins) {
            return coins.Select (dto => new Coin (dto)).ToList ();
        }

        private ICollection<Coin> GetValidCoins (ICollection<Coin> coins) {
            return coins.Where (coin => ValidCoins.Contains (coin.Type)).ToList ();
        }

        private ICollection<Coin> GetInvalidCoins (ICollection<Coin> coins) {
            return coins.Where (coin => !ValidCoins.Contains (coin.Type)).ToList ();
        }
    }
}