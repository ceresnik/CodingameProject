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
        private static int Counter = 0;
        public ITurnAction Update(ITank self, IReadOnlyCollection<ITank> enemies)
        {
            if (Counter % 6 == 0)
            {
                return TurnAction.Decelerate;
            }
            if (Counter % 5 == 0)
            {
                return TurnAction.Accelerate;
            }
            if (Counter % 4 == 0)
            {
                return TurnAction.TurnLeft;
            }
            if (Counter % 3 == 0)
            {
                return TurnAction.TurnRight;
            }
            if (Counter % 2 == 0)
            {
                return TurnAction.Fire;
            }

            Counter++;
            return TurnAction.ChargeWeapon;
        }

        string ITankAI.Name => "Miso";

        TankColor ITankAI.Color => new TankColor(0, 0, 255);
    }
}
