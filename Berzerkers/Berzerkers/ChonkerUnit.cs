using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal abstract class ChonkerUnit : Character // can defend by a multiplier
    {
        private int _DefenceMulti = 2;

        public ChonkerUnit(Race race)
        {
        }

        public virtual int DefenceMulti { get => _DefenceMulti; protected set => _DefenceMulti = value; }


        public override void UnitDefendLogic(int damage, Character attacker)
        {
            if (damage <= BlockValue + DefenceMulti)
            {
                Console.WriteLine($"{damage} Damage  to {Name}  was blocked by {attacker.Name} BlockValue of:{BlockValue} + DefenceMulti of {DefenceMulti}");
                return;
            }
            HP -= (damage - (BlockValue + DefenceMulti));
            Console.WriteLine($"damage is: {damage} - (BlockValue {BlockValue} * DefenceMulti {DefenceMulti})");
            Console.WriteLine($"{this.Name} HP is now: {this.HP}");
        }

    }
}
