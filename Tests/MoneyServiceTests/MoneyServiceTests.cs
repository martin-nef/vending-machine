using System;
using System.Collections.Generic;
using System.Linq;
using Core.Dtos;
using Core.Enums;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Moq;
using NUnit.Framework;

namespace MoneyServiceTests {
    public class Tests {
        private ICoinRepository _coinRepo;
        private DummyCoinRepository _coinReturnRepo;
        private MoneyService _sut;

        [SetUp]
        public void Setup () {
            _coinRepo = new DummyCoinRepository ();
            _coinReturnRepo = new DummyCoinRepository ();
            _sut = new MoneyService (_coinRepo, _coinReturnRepo);
        }

        [TestCase (Denomination.Nickel)]
        [TestCase (Denomination.Dime)]
        [TestCase (Denomination.Quarter)]
        public void WhenValidCoinsAreInserted_ThenTheyAreStored (Denomination denominationOfInsertedCoin) {
            var coins = new List<CoinDto> {
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
            };

            _sut.InsertCoins (coins);

            VerifyInsertedCoins (_coinRepo, coins);
            VerifyInsertedCoins (_coinReturnRepo, new List<CoinDto> ());
        }

        [TestCase (Denomination.Cent)]
        [TestCase (Denomination.Dollar)]
        [TestCase (Denomination.Half)]
        public void WhenInValidCoinsAreInserted_ThenTheyAreRejected (Denomination denominationOfInsertedCoin) {
            var coins = new List<CoinDto> {
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
            };

            _sut.InsertCoins (coins);

            VerifyInsertedCoins (_coinReturnRepo, coins);
            VerifyInsertedCoins (_coinRepo, new List<CoinDto> ());
        }

        [Test]
        public void WhenIWantToSeeTheCurrentCoinAmount_ThenItIsDisplayed () {
            var coins = new List<CoinDto> {
                new CoinDto { CentValue = (int) Denomination.Nickel },
                new CoinDto { CentValue = (int) Denomination.Dime },
                new CoinDto { CentValue = (int) Denomination.Quarter },
            };
            var expected = coins.Sum (coin => coin.CentValue);
            _sut.InsertCoins (coins);

            var currentAmount = _sut.DisplayCurrentAmount ();

            Assert.AreEqual (expected, currentAmount);
        }

        private void VerifyInsertedCoins (ICoinRepository coinRepo, List<CoinDto> expectedCoins) {
            var insertedCoins = coinRepo.GetCoins ();
            var denominationsMatch = insertedCoins.All (insertedCoin => expectedCoins.Any (expectedCoin => expectedCoin.CentValue == (int) insertedCoin.Type));
            var sumsMatch = insertedCoins.Sum (coin => (int) coin.Type) == expectedCoins.Sum (coin => coin.CentValue);
            var countsMatch = insertedCoins.Count == expectedCoins.Count;
            Assert.True (denominationsMatch);
            Assert.True (sumsMatch);
            Assert.True (countsMatch);
        }
    }
}