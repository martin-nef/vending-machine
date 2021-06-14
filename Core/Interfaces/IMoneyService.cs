using System.Collections.Generic;
using vending_machine.Core.Dtos;

namespace vending_machine.Core.Interfaces {
    public interface IMoneyService {
        void InsertCoins (ICollection<CoinDto> coins);
    }
}