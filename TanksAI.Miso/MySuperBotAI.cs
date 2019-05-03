using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingArena.AI;

namespace TanksAI.Miso
{
    public class MySuperBotAI : IBotAI
    {
        public ITurnAction Update(IBot ownBot, IBattlefield battlefield)
        {
            throw new NotImplementedException();
        }

        public void OnDamaged(double damage, IBot shooter)
        {
            throw new NotImplementedException();
        }

        public void OnMoved(double distance)
        {
            throw new NotImplementedException();
        }

        public void OnCollisionWith(IBot bot)
        {
            throw new NotImplementedException();
        }

        public void OnResourcePicked()
        {
            throw new NotImplementedException();
        }

        public void OnWeaponPicked(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void OnRegenerated()
        {
            throw new NotImplementedException();
        }

        public string BotName { get; }
    }
}
