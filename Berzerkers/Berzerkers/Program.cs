﻿// ---- C# II (Dor Ben Dor) ----
//          Roee Tal
// -----------------------------

using Berzekers;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

internal class Program
{
    //List<Character> cUnits = new List<Character>();
    public static void Main(string[] args)
    {


        TestingClass test = new TestingClass();
        // test.TestDice();

        GameManager gameManager = new GameManager();
        gameManager.GameLoop();


        // test.UnitTypesTest();
    }
}

namespace Berzekers
{


    public class GameManager // where the game will run
    {



        //public enum DiceTypes { AttackDice, DeffenceDice, DamageDice }
        //Dice DiceType(DiceTypes type, int mod)
        //{

        //    if (type == DiceTypes.AttackDice)
        //    {
        //        Dice attackDice;
        //        attackDice = new Dice();
        //        attackDice._die = 0;
        //        attackDice._scalar = 0;
        //        attackDice._mod = mod;
        //        return attackDice;
        //    }
        //    if (type == DiceTypes.DeffenceDice)
        //    {
        //        Dice deffeceDice;
        //        deffeceDice = new Dice();
        //        deffeceDice._die = 0;
        //        deffeceDice._scalar = 7;
        //        deffeceDice._mod = mod;
        //        return deffeceDice;
        //    }
        //    if (type == DiceTypes.DamageDice)
        //    {
        //        Dice damageDice;
        //        damageDice = new Dice();
        //        damageDice._die = 0;
        //        damageDice._scalar = 7;
        //        damageDice._mod = mod;
        //        return damageDice;
        //    }

        //    else
        //    {
        //        Dice defaultDice;
        //        defaultDice = new Dice();
        //        defaultDice._die = 0;
        //        defaultDice._scalar = 0;
        //        defaultDice._mod = mod;
        //        return defaultDice;
        //    }
        //}
        public void GameLoop()
        {


            //Dice defDice = DiceType(DiceTypes.DeffenceDice, 1);
            //Console.WriteLine(defDice._mod);


            while (true)
            {
                int hp = -5;
                Console.WriteLine("starting game...");
                if (GameOver(hp))
                {
                    Console.WriteLine("closing game...");
                    break;
                }
            }
            UnitsCombat();


        }
        public void UnitsCombat() // a method for Units Combat Algo
        {
            Units();
            List<Character> unitTeam1 = new List<Character>();
            unitTeam1.Add(new NaziMeleeUnit(Character.Race.Nazis));
            unitTeam1.Add(new SlavChonkerUnit(Character.Race.Slavs));
            unitTeam1.Add(new PersianRangedUnit(Character.Race.Persians));
            int team1Count = unitTeam1.Count;

            List<Character> unitTeam2 = new List<Character>();
            unitTeam2.Add(new NaziChonkerUnit(Character.Race.Nazis));
            unitTeam2.Add(new SlavRangedUnit(Character.Race.Slavs));
            unitTeam2.Add(new PersianMeleeUnit(Character.Race.Persians));
            int team2Count = unitTeam2.Count;

            bool team1Turn = true;
            if (team1Turn == true)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("it is Team1 Turn:");
                Console.WriteLine("-----------------");
                Random rndAttacker = new Random();
                int randomAttacker = rndAttacker.Next(0, team1Count);
                Random rndDefender = new Random();
                int randomDefender = rndAttacker.Next(0, team2Count);
                Console.WriteLine($"Team1: {unitTeam1[randomAttacker].Name} is attacking Team2:{unitTeam2[randomDefender].Name} ");
                unitTeam1[randomAttacker].Attack(unitTeam2[randomDefender]);
                team1Turn = false;
            }
            if (team1Turn == false)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("it is Team2 Turn:");
                Console.WriteLine("-----------------");
                Random rndAttacker = new Random();
                int randomAttacker = rndAttacker.Next(0, team2Count);
                Random rndDefender = new Random();
                int randomDefender = rndAttacker.Next(0, team1Count);
                Console.WriteLine($"Team2: {unitTeam2[randomAttacker].Name} is attacking Team1:{unitTeam1[randomDefender].Name} ");
                unitTeam2[randomAttacker].Attack(unitTeam1[randomDefender]);


                team1Turn = true;
            }
        }
        public void Units() // method to instanciate unit types
        {
            NaziMeleeUnit NaziMelee = new NaziMeleeUnit(Character.Race.Nazis);
            SlavMeleeUnit SlavMelee = new SlavMeleeUnit(Character.Race.Slavs);
            PersianMeleeUnit PersianMelee = new PersianMeleeUnit(Character.Race.Persians);
            ChonkerUnit NaziChonker = new NaziChonkerUnit(Character.Race.Nazis);
            ChonkerUnit SlavChonker = new SlavChonkerUnit(Character.Race.Slavs);
            ChonkerUnit PersianChonker = new PersianChonkerUnit(Character.Race.Persians);
            RangedUnit NaziRanged = new NaziRangedUnit(Character.Race.Nazis);
            RangedUnit SlavRanged = new SlavRangedUnit(Character.Race.Slavs);
            RangedUnit PersianRanged = new PersianRangedUnit(Character.Race.Persians);
        }

        public bool GameOver(int HP)
        {
            Console.WriteLine("GameOver");
            return HP <= 0;
        }
    }

    public class TestingClass
    {
        public void UnitTypesTest()
        {
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
            cUnits.Add(new NaziMeleeUnit(Character.Race.Nazis));
            cUnits.Add(new SlavMeleeUnit(Character.Race.Slavs));
            cUnits.Add(new PersianMeleeUnit(Character.Race.Persians));

            Console.WriteLine(cUnits[1]); // testing the list
            Console.WriteLine($"{NaziMelee}  HP:{NaziMelee.HP} DeffenceValue:{NaziMelee.DefVal} MeleeMulti:{NaziMelee.MeleeMulti}");
            Console.WriteLine($"{SlavMelee}  HP:{SlavMelee.HP} DeffenceValue:{SlavMelee.DefVal} MeleeMulti:{SlavMelee.MeleeMulti}");
            Console.WriteLine($"{PersianMelee}  HP:{PersianMelee.HP} DeffenceValue:{PersianMelee.DefVal} MeleeMulti:{PersianMelee.MeleeMulti}");
            Console.WriteLine($"{NaziChonker}  HP:{NaziChonker.HP} DeffenceValue:{NaziChonker.DefVal} DeffenceMulti:{NaziChonker.DefMulti}");
            Console.WriteLine($"{SlavChonker}  HP:{SlavChonker.HP} DeffenceValue:{SlavChonker.DefVal} DeffenceMulti:{SlavChonker.DefMulti} ");
            Console.WriteLine($"{PersianChonker}  HP:{PersianChonker.HP} DeffenceValue:{PersianChonker.DefVal} DeffenceMulti:{PersianChonker.DefMulti}");
        }
        public void TestDice()
        {
            Dice dice1;
            Dice dice2;
            dice1 = new Dice();
            dice2 = new Dice();
            dice2._die = 2;
            dice2._scalar = 3;
            dice2._mod = 2;
            while (true)
            {
                dice1._die = 2;
                dice1._scalar = 3;
                dice1._mod = 2;
                int value = dice1.roll();
                Console.WriteLine(value);
                if (value == dice1._die * dice1._scalar)
                {
                    Console.WriteLine("");
                    Console.WriteLine(value);
                    Console.WriteLine("its the max value");
                    break;
                }
            }
            Console.WriteLine(dice1.Equals(dice2)); // testing of equals
        } // for testing
    }
    struct Dice
    {
        public uint _die; // how many dice
        public uint _scalar = 0; // how many times die will roll
        public int _mod = 0; //modifier value + or -
        public Dice(uint die, uint scalar, int mod)
        {
            this._die = die;
            this._scalar = scalar;
            this._mod = mod;

        }
        public int roll()
        {

            uint die = this._die;
            uint scalar = this._scalar;
            int mod = this._mod;
            Console.WriteLine(this.ToString());
            Random rnd = new Random();
            int value = 0;
            int cubeNam = 0;
            for (int i = 0; i < scalar; i++)
            {
                cubeNam++;
                int cubeVal = rnd.Next(1, (int)die + 1);
                //if (i == 0) Console.WriteLine($"1st Dice Value:{cubeVal}");
                //if (i == 1) Console.WriteLine($"2nd Dice Value:{cubeVal}");
                //if (i == 2) Console.WriteLine($"3rd Dice Value:{cubeVal}");
                //if (i >= 3) Console.WriteLine($"{cubeNam}th Dice Value: {cubeVal} ");
                if (i < scalar)
                {
                    Console.WriteLine($"");
                }
                value += cubeVal;
            }
            value += mod;
            return value;
        }

        public override string ToString()
        {
            return $"die type:{_die} sides, times to roll:{_scalar}, modifier{_mod} throwing dices....";
          
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {

            if (obj is Dice diceObj) // casting obj as dice
            {
                //  if (diceObj._die == this._die && diceObj._scalar == this._scalar && diceObj._mod == this._mod)
                //   {
                //      return true;
                //  
                return this.GetHashCode() == diceObj.GetHashCode();
            }
            return false;

        }
        public override int GetHashCode()
        {
            int a = (int)this._die;
            int b = (int)this._scalar;
            int c = this._mod;

            return a * 100 + b * 10 + c;
        }

    }
    abstract class Character  // Unit Class named Character
    {


        public enum Weather { Sunny, Rainy, Snowy }




        private Race _race;
        // props and fields to set values 
        private string _name = "John Doe"; //field
        public virtual string Name { get => _name; protected set => _name = value; } //prop

        private int _carryingCapacity = 100; //field
        public virtual int CarryingCapacity { get => _carryingCapacity; protected set => _carryingCapacity = value; } //prop

        private int _damageMod = 0; //field
        public virtual int DamageMod { get => _damageMod; protected set => _damageMod = value; } //prop

        private int _hitChanceMod = 0; //field
        public virtual int HitChanceMod { get => _hitChanceMod; protected set => _hitChanceMod = value; } //prop

        private int _defenceChanceMod = 0; //field
        public virtual int DefenceChanceMod { get => _defenceChanceMod; protected set => _defenceChanceMod = value; } //prop
        public virtual Race Races { get => _race; set => _race = value; } //prop 

        private int _hp = 10; // field
        public virtual int HP { get => _hp; protected set => _hp = value; } // prop

        private int _defVal = 2; // field
        public virtual int DefVal { get => _defVal; protected set => _defVal = value; } //prop

        public void WeatherEffects(Weather weatherType)
        {
            if (weatherType == Weather.Sunny)
            {
                HitChanceMod++;
            }
            if (weatherType == Weather.Rainy)
            {
                DamageMod--;
                HitChanceMod++;
            }
            if (weatherType == Weather.Snowy)
            {
                HitChanceMod--;
            }
        }

        public virtual void Attack(Character defender)
        {
            Dice hitChanceDice;
            hitChanceDice = new Dice();
            hitChanceDice._die = 6;
            hitChanceDice._scalar = 2;
            hitChanceDice._mod = HitChanceMod;

            Dice damageDice;
            damageDice = new Dice();
            damageDice._die = 6;
            damageDice._scalar = 2;
            damageDice._mod = DamageMod;

            defender.Defend(this, hitChanceDice, damageDice);
        }
        public virtual void Defend(Character attacker, Dice hitChanceDice, Dice damageDice)
        {

            Dice defenderChanceDice;
            defenderChanceDice = new Dice();
            defenderChanceDice._die = 6;
            defenderChanceDice._scalar = 2;
            defenderChanceDice._mod = DefenceChanceMod;
            int hitChance = hitChanceDice.roll();
            Console.WriteLine($"hit chance is: {hitChance}");
            int defenderChance = defenderChanceDice.roll();
            Console.WriteLine($"defender chance is: {defenderChance}");
            if (hitChance > defenderChance)
            {
                Console.WriteLine($"hit is succesful");
                int DMG = damageDice.roll();
                Console.WriteLine($"damage is: {DMG} DefenceValue is:{DefVal}");

                if (DMG <= DefVal)
                {
                    return;
                }
                HP -= (DMG - DefVal);
                Console.WriteLine($"{this.Name} HP is now: {this.HP}");

            }
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

        //public override void Defend(Character attacker, Dice hitChanceDice, Dice damageDice)
        //{
        //    Dice defenderChanceDice;
        //    defenderChanceDice = new Dice();
        //    defenderChanceDice._die = 6;
        //    defenderChanceDice._scalar = 2;
        //    defenderChanceDice._mod = DefenceChanceMod;
        //    int hitChance = hitChanceDice.roll();
        //    Console.WriteLine($"hit chance is: {hitChance}");
        //    int defenderChance = defenderChanceDice.roll();
        //    Console.WriteLine($"defender chance is: {defenderChance}");
        //    int DMG = damageDice.roll();

        //    if (DMG * MeleeMulti <= DefVal)
        //    {
        //        return;
        //    }
        //    HP -= ((DMG * MeleeMulti) - DefVal);
        //}
    }
    internal abstract class ChonkerUnit : Character // can defend by a multiplier
    {
        private int _defMulti = 2;

        public ChonkerUnit(Race race)
        {
        }

        public virtual int DefMulti { get => _defMulti; protected set => _defMulti = value; }

        //public override void Defend(Character attacker, Dice hitChanceDice, Dice damageDice)
        //{
        //    Dice defenderChanceDice;
        //    defenderChanceDice = new Dice();
        //    defenderChanceDice._die = 6;
        //    defenderChanceDice._scalar = 2;
        //    defenderChanceDice._mod = DefenceChanceMod;
        //    int hitChance = hitChanceDice.roll();
        //    Console.WriteLine($"hit chance is: {hitChance}");
        //    int defenderChance = defenderChanceDice.roll();
        //    Console.WriteLine($"defender chance is: {defenderChance}");
        //    int DMG = damageDice.roll();

        //    if (DMG <= DefVal * DefMulti)
        //    {
        //        return;
        //    }
        //    HP -= (DMG - (DefVal * DefMulti));
        //}

    }
    internal abstract class RangedUnit : Character // can attack more then once according to how much proj they have
    {

        private int _projCount = 2;

        public RangedUnit(Race race)
        {
        }

        public virtual int ProjCount { get => _projCount; protected set => _projCount = value; }

        //public override void Defend(Character attacker, Dice hitChanceDice, Dice damageDice)
        //{

        //    Dice defenderChanceDice;
        //    defenderChanceDice = new Dice();
        //    defenderChanceDice._die = 6;
        //    defenderChanceDice._scalar = 2;
        //    defenderChanceDice._mod = DefenceChanceMod;
        //    int hitChance = hitChanceDice.roll();
        //    Console.WriteLine($"hit chance is: {hitChance}");
        //    int defenderChance = defenderChanceDice.roll();
        //    Console.WriteLine($"defender chance is: {defenderChance}");
        //    while (ProjCount > 0)
        //    {
        //        int DMG = damageDice.roll();

        //        if (DMG <= DefVal)
        //        {
        //            return;
        //        }
        //        HP -= (DMG - DefVal);
        //        ProjCount--;
        //    }
        //}
    }

    internal class NaziMeleeUnit : MeleeUnit
    {

        public NaziMeleeUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DamageMod++;
        }

        public override string Name { get => "NaziMeleeUnit"; protected set => base.Name = value; }
        public override int MeleeMulti { get => base.MeleeMulti + 3; protected set => base.MeleeMulti = value; }
    }
    internal class NaziChonkerUnit : ChonkerUnit
    {
        public NaziChonkerUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DamageMod++;
        }
        public override string Name { get => "NaziChonkerUnit"; protected set => base.Name = value; }
        public override int DefMulti { get => base.DefMulti + 1; protected set => base.DefMulti = value; }
    }
    internal class NaziRangedUnit : RangedUnit
    {
        public NaziRangedUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            DamageMod++;
        }
        public override string Name { get => "NaziRangedUnit"; protected set => base.Name = value; }
        public override int ProjCount { get => base.ProjCount + 4; protected set => base.ProjCount = value; }
    }
    internal class SlavMeleeUnit : MeleeUnit
    {
        public SlavMeleeUnit(Race race) : base(race)
        {
            race = Race.Slavs;
            HP++;
        }
        public override string Name { get => "SlavMeleeUnit"; protected set => base.Name = value; }
        public override int MeleeMulti { get => base.MeleeMulti + 5; protected set => base.MeleeMulti = value; }
    }
    internal class SlavChonkerUnit : ChonkerUnit
    {
        public SlavChonkerUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            HP++;
        }
        public override string Name { get => "SlavChonkerUnit"; protected set => base.Name = value; }
        public override int DefMulti { get => base.DefMulti + 2; protected set => base.DefMulti = value; }
    }
    internal class SlavRangedUnit : RangedUnit
    {
        public SlavRangedUnit(Race race) : base(race)
        {
            race = Race.Nazis;
            HP++;
        }
        public override string Name { get => "SlavRangedUnit"; protected set => base.Name = value; }
        public override int ProjCount { get => base.ProjCount - 1; protected set => base.ProjCount = value; }
    }
    internal class PersianMeleeUnit : MeleeUnit
    {
        public override string Name { get => "PersianMeleeUnit"; protected set => base.Name = value; }
        public PersianMeleeUnit(Race race) : base(race)
        {
            race = Race.Persians;
            DefVal++;
        }
        public override int MeleeMulti { get => base.MeleeMulti - 1; protected set => base.MeleeMulti = value; }
    }
    internal class PersianChonkerUnit : ChonkerUnit
    {
        public override string Name { get => "PersianChonkerUnit"; protected set => base.Name = value; }
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
        public override string Name { get => "PersianRangedUnit"; protected set => base.Name = value; }
        public override int ProjCount { get => base.ProjCount + 1; protected set => base.ProjCount = value; }
    }



}