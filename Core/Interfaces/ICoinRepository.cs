using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces {
    public interface ICoinRepository {
        void InsertCoins (ICollection<Coin> coins);
        ICollection<Coin> GetCoins();
    }
}