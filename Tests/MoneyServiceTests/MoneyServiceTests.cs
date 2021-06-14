using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using vending_machine.Core.Dtos;
using vending_machine.Core.Enums;
using vending_machine.Core.Interfaces;
using vending_machine.Core.Models;
using vending_machine.Core.Services;

namespace MoneyServiceTests {
    public class Tests {
        private Mock<ICoinRepository> _coinRepo;
        private MoneyService _sut;

        [SetUp]
        public void Setup () {
            _coinRepo = new Mock<ICoinRepository> ();
            _sut = new MoneyService (_coinRepo.Object);
        }

        [TestCase (Denomination.Cent)]
        [TestCase (Denomination.Dime)]
        [TestCase (Denomination.Dollar)]
        [TestCase (Denomination.Half)]
        [TestCase (Denomination.Nickel)]
        [TestCase (Denomination.Quarter)]
        public void WhenCoinsAreInserted_ThenTheyAreStored (Denomination denominationOfInsertedCoin)
        {
            var coins = new List<CoinDto> {
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
                new CoinDto { CentValue = (int) denominationOfInsertedCoin },
            };

            _sut.InsertCoins(coins);

            _coinRepo.Verify(repo => repo.InsertCoins(VerifyInsertedCoins(coins)));
        }

        private ICollection<Coin> VerifyInsertedCoins(List<CoinDto> expectedCoins)
        {
            return It.Is<ICollection<Coin>>(
                insertedCoins => insertedCoins.All(insertedCoin => expectedCoins.Any(expectedCoin => expectedCoin.CentValue == (int)insertedCoin.Type)) &&
                insertedCoins.Sum(coin => (int)coin.Type) == expectedCoins.Sum(coin => coin.CentValue) &&
                insertedCoins.Count == expectedCoins.Count);
        }
    }
}