using System.Linq;
using CodingArena.AI;

namespace BotAI
{
    public class MySuperBotAI : CodingArena.AI.BotAI
    {

        public override string BotName => "Miso";

        public override ITurnAction Update(IBot ownBot, IBattlefield battlefield)
        {
            var maxRange = ownBot.EquippedWeapon.MaxRange;
            IGameObject closestEnemy = battlefield.Bots.Except(new[] { ownBot }).OrderBy(ownBot.DistanceTo).FirstOrDefault();

            if (closestEnemy != null && ownBot.DistanceTo(closestEnemy) < maxRange)
            {
                return TurnAction.ShootAt(closestEnemy);
            }

            if (ownBot.HasResource)
            {
                return GoHomeWithResource(ownBot);
            }
            else
            {
                return GetResource(ownBot, battlefield);
            }
            //return TurnAction.Idle;
        }

        private ITurnAction GetResource(IBot ownBot, IBattlefield battlefield)
        {
            var closestResource = battlefield.Resources.OrderBy(ownBot.DistanceTo).First();
            return ownBot.DistanceTo(closestResource) < ownBot.Radius
                ? TurnAction.PickUpResource()
                : TurnAction.MoveTowards(closestResource);
        }

        private ITurnAction GoHomeWithResource(IBot ownBot)
        {
            return ownBot.DistanceTo(ownBot.Home) < (ownBot.Radius) ? TurnAction.DropDownResource() : TurnAction.MoveTowards(ownBot.Home);
        }

        public override void OnDamaged(double damage, IBot shooter)
        {
        }

        public override void OnMoved(double distance)
        {
        }

        public override void OnCollisionWith(IBot bot)
        {
        }

        public override void OnResourcePicked()
        {
        }

        public override void OnWeaponPicked(IWeapon weapon)
        {
        }

        public override void OnRegenerated()
        {
        }
    }
}
