using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class PersianChonkerUnit : ChonkerUnit
    {
        public override string Name { get => "PersianChonkerUnit"; protected set => base.Name = value; }
        public PersianChonkerUnit(Race race) : base(race)
        {
            race = Race.Persians;
            BlockValue++;
        }
        public override int DefenceMulti { get => base.DefenceMulti - 1; protected set => base.DefenceMulti = value; }
    }
}
