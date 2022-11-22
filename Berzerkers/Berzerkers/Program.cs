// ---- C# II (Dor Ben Dor) ----
//          Roee Tal
// -----------------------------

using Berzekers;
using System.ComponentModel;

internal class Program
{
    //List<Character> cUnits = new List<Character>();
    public static void Main(string[] args)
    {

        //instantiate
        NaziMeleeUnit NaziMelee = new NaziMeleeUnit(Character.Race.Nazis);
        SlavMeleeUnit SlavMelee = new SlavMeleeUnit(Character.Race.Slavs);
        PersianMeleeUnit PersianMelee = new PersianMeleeUnit(Character.Race.Persians);
        ChonkerUnit NaziChonker = new NaziChonkerUnit(Character.Race.Nazis);
        ChonkerUnit SlavChonker = new SlavChonkerUnit(Character.Race.Slavs);
        ChonkerUnit PersianChonker = new PersianChonkerUnit(Character.Race.Persians);
        RangedUnit NaziRanged = new NaziRangedUnit(Character.Race.Nazis);
        RangedUnit SlavRanged = new SlavRangedUnit(Character.Race.Slavs);
        RangedUnit PersianRanged = new PersianRangedUnit(Character.Race.Persians);


        List<Character> cUnits = new List<Character>();
         cUnits.Add( new NaziMeleeUnit(Character.Race.Nazis));
        cUnits.Add(new SlavMeleeUnit(Character.Race.Slavs));
        cUnits.Add(new PersianMeleeUnit(Character.Race.Persians));


        // just testing
        
        Console.WriteLine(cUnits[1]); // testing the list
        Console.WriteLine($"{NaziMelee} dmg:{NaziMelee.DMG} HP:{NaziMelee.HP} DeffenceValue:{NaziMelee.DefVal} MeleeMulti:{NaziMelee.MeleeMulti}");
        Console.WriteLine($"{SlavMelee} dmg:{SlavMelee.DMG} HP:{SlavMelee.HP} DeffenceValue:{SlavMelee.DefVal} MeleeMulti:{SlavMelee.MeleeMulti}");
        Console.WriteLine($"{PersianMelee} dmg:{PersianMelee.DMG} HP:{PersianMelee.HP} DeffenceValue:{PersianMelee.DefVal} MeleeMulti:{PersianMelee.MeleeMulti}");
        Console.WriteLine($"{NaziChonker} dmg:{NaziChonker.DMG} HP:{NaziChonker.HP} DeffenceValue:{NaziChonker.DefVal} DeffenceMulti:{NaziChonker.DefMulti}");
        Console.WriteLine($"{SlavChonker} dmg:{SlavChonker.DMG} HP:{SlavChonker.HP} DeffenceValue:{SlavChonker.DefVal} DeffenceMulti:{SlavChonker.DefMulti} ");
        Console.WriteLine($"{PersianChonker} dmg:{PersianChonker.DMG} HP:{PersianChonker.HP} DeffenceValue:{PersianChonker.DefVal} DeffenceMulti:{PersianChonker.DefMulti}");
        // just testing
    }
}

namespace Berzekers
{

    abstract class Character // Unit Class named Character
    {
        private Race _race; // field

        // props and fields to set values 
        public virtual Race Races { get => _race; set => _race = value; } //prop 

        private int _dmg = 5; // field
        public virtual int DMG { get => _dmg; protected set => _dmg = value; } // prop

        private int _hp = 100; // field
        public virtual int HP { get => _hp; protected set => _hp = value; } // prop

        private int _defVal = 2; // field
        public virtual int DefVal { get => _defVal; protected set => _defVal = value; } //prop

        // at first i wanted to have a shortcut with the constructor
        //public Character(Race race)
        //{
        //    Races = race;

        //    if (race == Race.Nazis)
        //    {
        //        this.DMG++;
        //    }
        //    if (race == Race.Slavs)
        //    {
        //        this.HP++;
        //    }
        //    if (race == Race.Persians)
        //    {
        //        this.DefVal++;
        //    }
        //} 
        // at first i wanted to have a shortcut with the constructor

        public virtual void Attack(Character defender)
        {
            defender.Defend(this);
        }
        public virtual void Defend(Character attacker)
        {
            if (DMG <= DefVal)
            {
                return;
            }
            HP -= (attacker.DMG - DefVal);
        }


        public enum Race { Nazis, Slavs, Persians }
    }
    internal abstract class MeleeUnit : Character // can attack by a multiplier
    {

        private int _meleeMulti = 2;

        public MeleeUnit(Race race)
        {

        }


        public virtual int MeleeMulti { get => _meleeMulti; protected set => _meleeMulti = value; }
        public override void Defend(Character attacker)
        {
            if (DMG * MeleeMulti <= DefVal)
            {
                return;
            }
            HP -= ((attacker.DMG * MeleeMulti) - DefVal);
        }
    }
    internal abstract class ChonkerUnit : Character // can defend by a multiplier
    {
        private int _defMulti = 2;

        public ChonkerUnit(Race race)
        {
        }

        public virtual int DefMulti { get => _defMulti; protected set => _defMulti = value; }
        public override void Defend(Character attacker)
        {
            if (DMG <= DefVal * DefMulti)
            {
                return;
            }
            HP -= (attacker.DMG - (DefVal * DefMulti));
        }

    }
    internal abstract class RangedUnit : Character // can attack more then once according to how much proj they have
    {

        private int _projCount = 2;

        public RangedUnit(Race race)
        {
        }

        public virtual int ProjCount { get => _projCount; protected set => _projCount = value; }

        public override void Defend(Character attacker)
        {
            while (ProjCount > 0)
            {
                if (DMG <= DefVal)
                {
                    return;
                }
                HP -= (attacker.DMG - DefVal);
                ProjCount--;
            }
        }
    }

    internal class NaziMeleeUnit : MeleeUnit
    {
   
        public NaziMeleeUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DMG++;
        }
        //hello berzerkers

        public override int MeleeMulti { get => base.MeleeMulti + 3; protected set => base.MeleeMulti = value; }
    }
    internal class NaziChonkerUnit : ChonkerUnit
    {
        public NaziChonkerUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DMG++;
        }
        public override int DefMulti { get => base.DefMulti + 1; protected set => base.DefMulti = value; }
    }
    internal class NaziRangedUnit : RangedUnit
    {
        public NaziRangedUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DMG++;
        }
        public override int ProjCount { get => base.ProjCount + 4; protected set => base.ProjCount = value; }
    }
    internal class SlavMeleeUnit : MeleeUnit
    {
        public SlavMeleeUnit(Race race) : base(race)
        {
            race = Race.Slavs;
            HP++;
        }
        public override int MeleeMulti { get => base.MeleeMulti + 5; protected set => base.MeleeMulti = value; }
    }
    internal class SlavChonkerUnit : ChonkerUnit
    {
        public SlavChonkerUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            HP++;
        }
        public override int DefMulti { get => base.DefMulti + 2; protected set => base.DefMulti = value; }
    }
    internal class SlavRangedUnit : RangedUnit
    {
        public SlavRangedUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            HP++;
        }
        public override int ProjCount { get => base.ProjCount - 1; protected set => base.ProjCount = value; }
    }
    internal class PersianMeleeUnit : MeleeUnit
    {
        public PersianMeleeUnit(Race race) : base(race)
        {
            race = Race.Persians;
            DefVal++;
        }
        public override int MeleeMulti { get => base.MeleeMulti - 1; protected set => base.MeleeMulti = value; }
    }
    internal class PersianChonkerUnit : ChonkerUnit
    {
        public PersianChonkerUnit(Race race) : base(race)
        {
            race = Race.Persians;
            DefVal++;
        }
        public override int DefMulti { get => base.DefMulti - 1; protected set => base.DefMulti = value; }
    }
    internal class PersianRangedUnit : RangedUnit
    {
        public PersianRangedUnit(Race race) : base(race)
        {
            race = Race.Persians;
            DefVal++;
        }
        public override int ProjCount { get => base.ProjCount + 1; protected set => base.ProjCount = value; }
    }



}