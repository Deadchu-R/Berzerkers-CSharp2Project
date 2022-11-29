using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class NaziChonkerUnit : ChonkerUnit
    {
        public NaziChonkerUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DamageMod++;
        }
        public override string Name { get => "NaziChonkerUnit"; protected set => base.Name = value; }
        public override int DefenceMulti { get => base.DefenceMulti + 1; protected set => base.DefenceMulti = value; }
    }
}
