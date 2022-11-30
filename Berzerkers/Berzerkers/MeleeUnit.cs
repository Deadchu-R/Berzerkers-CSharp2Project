using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal abstract class MeleeUnit : Character // can attack by a multiplier
    {

        private int _meleeMulti = 2
        ;
        public int UseBag()
        {
            Console.Write($"{this.Name} Drawing a NumberCard from the bag");
            IRandomProvider bag;
            bag = new Bag(10, 2, 50); // yes, it is hard codded
            int NumberCard = bag.ProvideRandom();
            Console.WriteLine($"NumberCard:{NumberCard}");
            return NumberCard;
        }
        public MeleeUnit(Race race)
        {

        }


        public virtual int MeleeMulti { get => _meleeMulti; protected set => _meleeMulti = value; }

        public override void UnitDefendLogic(int damage, Character attacker)
        {
           damage = UseBag();
            if (damage + MeleeMulti <= BlockValue)
            {

                Console.WriteLine($"{damage} Damage + {MeleeMulti} BlockValue  was blocked by BlockValue of:{BlockValue}");
                return;
            }
            HP -= ((damage + MeleeMulti) - BlockValue);
            Console.WriteLine($"{damage} Damage + {MeleeMulti} MeleeMulti is {damage * MeleeMulti}");
            Console.WriteLine($"damage is: {damage + MeleeMulti} BlockValue is:{BlockValue}");
            Console.WriteLine($"{this.Name} HP is now: {this.HP}");
        }
    }
}
