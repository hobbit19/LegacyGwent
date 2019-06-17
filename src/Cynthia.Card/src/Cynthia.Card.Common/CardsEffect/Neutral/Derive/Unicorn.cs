using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("15008")]//独角兽
    public class Unicorn : CardEffect
    {//使所有其他单位获得2点增益。
        public Unicorn(IGwentServerGame game, GameCard card) : base(game, card) { }
        public override async Task<int> CardPlayEffect(bool isSpying)
        {
            var cards = Game.GetAllCard(Game.AnotherPlayer(Card.PlayerIndex))
                .Where(x => x.Status.CardRow.IsOnPlace() && x != Card).ToList();
            foreach (var card in cards)
            {
                await card.Effect.Boost(2, Card);
            }
            return 0;
        }
    }
}