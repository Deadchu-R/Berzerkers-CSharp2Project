using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class PersianRangedUnit : RangedUnit
    {
        public PersianRangedUnit(Race race) : base(race)
        {
            race = Race.Persians;
            BlockValue++;
        }
        public override string Name { get => "PersianRangedUnit"; protected set => base.Name = value; }
        public override int ProjectileCount { get => base.ProjectileCount + 1; protected set => base.ProjectileCount = value; }
    }

}
