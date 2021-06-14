using System.Collections.Generic;
using vending_machine.Models;

namespace vending_machine.Interfaces {
    public interface ICoinRepository {
        void InsertCoins (ICollection<Coin> coin);
        ICollection<Coin> GetCoins ();
    }
}