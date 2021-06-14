using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using Core.Interfaces;
using Core.Models;

namespace Core.Repositories {
    public class DummyCoinRepository : ICoinRepository, ICoinReturnRepository {
        private List<Coin> _coinStore = new List<Coin> ();

        public ICollection<Coin> GetCoins()
        {
            return _coinStore.ToList();
        }

        public void InsertCoins (ICollection<Coin> coins) {
            _coinStore.AddRange(coins);
        }

        public ICollection<Coin> ReturnCoins () {
            var coins = GetCoins();
            _coinStore.Clear();
            return coins;
        }
    }
}