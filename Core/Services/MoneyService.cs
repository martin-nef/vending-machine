using System;
using System.Collections.Generic;
using System.Linq;
using vending_machine.Core.Dtos;
using vending_machine.Core.Interfaces;
using vending_machine.Core.Models;

namespace vending_machine.Core.Services {
    public class MoneyService : IMoneyService {
        private readonly ICoinRepository _coinRepository;

        public MoneyService (ICoinRepository coinRepository) {
            _coinRepository = coinRepository;
        }

        public void InsertCoins (ICollection<CoinDto> coins) {
            throw new NotImplementedException();
        }
    }
}