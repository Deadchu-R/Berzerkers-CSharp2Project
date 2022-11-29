using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class NaziRangedUnit : RangedUnit
    {
        public NaziRangedUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DamageMod++;
        }
        public override string Name { get => "NaziRangedUnit"; protected set => base.Name = value; }
        public override int ProjectileCount { get => base.ProjectileCount + 1; protected set => base.ProjectileCount = value; }
    }
}
