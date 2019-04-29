using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksAI.Player;
using TanksAI.Player.TurnActions;

namespace TanksAI.Miso
{
    public class MySuperTankAI : ITankAI
    {
        public ITurnAction Update(ITank self, IReadOnlyCollection<ITank> enemies)
        {
            return new AccelerateTurnAction();
        }

        public string Name () => "Miso";
        public TankColor Color () => new TankColor(0, 0, 255);
    }
}
