using System.Collections.Generic;
using vending_machine.Dtos;

namespace vending_machine.Interfaces {
    public interface IMoneyService {
        void InsertCoins (ICollection<CoinDto> coins);
    }
}