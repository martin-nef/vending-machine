using System.Collections.Generic;
using vending_machine.Core.Models;

namespace vending_machine.Core.Interfaces {
    public interface ICoinRepository {
        void InsertCoins (ICollection<Coin> coins);
        ICollection<Coin> GetCoins ();
    }
}