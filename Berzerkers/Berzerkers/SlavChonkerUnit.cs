using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class SlavChonkerUnit : ChonkerUnit
    {
        public SlavChonkerUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            HP++;
        }
        public override string Name { get => "SlavChonkerUnit"; protected set => base.Name = value; }
        public override int DefenceMulti { get => base.DefenceMulti + 2; protected set => base.DefenceMulti = value; }
    }
}
