using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal abstract class RangedUnit : Character // can attack more then once according to how much projectiles they have
    {

        private int _projectileCount = 2;

        public RangedUnit(Race race)
        {
        }

        public virtual int ProjectileCount { get => _projectileCount; protected set => _projectileCount = value; }


        public override void UnitDefendLogic(int damage, Character attacker)
        {

            for (int i = ProjectileCount; i > 0; i--)
            {
                if (damage <= BlockValue)
                {
                    Console.WriteLine($"{damage} Damage to {this.Name} was blocked by {this.Name} BlockValue of:{BlockValue}");
                    return;
                }
                HP -= (damage - BlockValue);
                Console.WriteLine($"Damaged {this.Name} by {damage} Damage - {BlockValue} BlockValue ");
                Console.WriteLine($"{this.Name} HP is now: {this.HP}");
                Console.WriteLine($"ProjCount {i}");
            }

        }
    }
}
