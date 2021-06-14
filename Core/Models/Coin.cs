using vending_machine.Core.Dtos;
using vending_machine.Core.Enums;

namespace vending_machine.Core.Models
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
