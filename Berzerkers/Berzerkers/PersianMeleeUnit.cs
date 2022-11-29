using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class PersianMeleeUnit : MeleeUnit
    {
        public override string Name { get => "PersianMeleeUnit"; protected set => base.Name = value; }
        public PersianMeleeUnit(Race race) : base(race)
        {
            race = Race.Persians;
            BlockValue++;
        }
        public override int MeleeMulti { get => base.MeleeMulti - 1; protected set => base.MeleeMulti = value; }
    }
}
