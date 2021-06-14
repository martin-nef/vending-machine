using System.Collections.Generic;
using Core.Dtos;

namespace Core.Interfaces {
    public interface IMoneyService {
        void InsertCoins (ICollection<CoinDto> coinDtos);
        double DisplayCurrentAmount();
    }
}