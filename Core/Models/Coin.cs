using Core.Dtos;
using Core.Enums;

namespace Core.Models
{
    public class Coin
    {
        public Coin()
        {
        }
        public Coin(CoinDto dto)
        {
            Type = (Denomination)dto.CentValue;
        }
        public Denomination Type { get; set; }
    }
}
