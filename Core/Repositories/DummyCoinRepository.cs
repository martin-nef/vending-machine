using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using vending_machine.Core.Enums;
using vending_machine.Core.Interfaces;
using vending_machine.Core.Models;

namespace Core.Repositories {
    public class DummyCoinRepository : ICoinRepository {
        private IDictionary<Denomination, ConcurrentBag<Coin>> _coinStore = new ConcurrentDictionary<Denomination, ConcurrentBag<Coin>> {
            [Denomination.Cent] = new ConcurrentBag<Coin> (),
            [Denomination.Nickel] = new ConcurrentBag<Coin> (),
            [Denomination.Dime] = new ConcurrentBag<Coin> (),
            [Denomination.Quarter] = new ConcurrentBag<Coin> (),
            [Denomination.Half] = new ConcurrentBag<Coin> (),
            [Denomination.Dollar] = new ConcurrentBag<Coin> (),
        };

        public ICollection<Coin> GetCoins () {
            return _coinStore.Values.SelectMany (coins => coins).ToList ();
        }

        public void InsertCoins (ICollection<Coin> coins) {
            foreach (var coin in coins) {
                _coinStore[coin.Type].Add(coin);
            }
        }
    }
}