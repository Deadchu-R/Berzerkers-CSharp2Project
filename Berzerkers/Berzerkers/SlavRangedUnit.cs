using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class SlavRangedUnit : RangedUnit
    {
        public SlavRangedUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            HP++;
        }
        public override string Name { get => "SlavRangedUnit"; protected set => base.Name = value; }
        public override int ProjectileCount { get => base.ProjectileCount - 1; protected set => base.ProjectileCount = value; }
    }
}
