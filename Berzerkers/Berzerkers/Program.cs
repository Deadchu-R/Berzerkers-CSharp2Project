// ---- C# II (Dor Ben Dor) ----
//          Roee Tal
// -----------------------------

using Berzekers;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;

internal class Program
{
    //List<Character> cUnits = new List<Character>();
    public static void Main(string[] args)
    {


        TestingClass test = new TestingClass();
        // test.TestDice();

        GameManager gameManager = new GameManager();
        // gameManager.GameLoop();
        gameManager.UnitsCombat();


        // test.UnitTypesTest();
    }
}

namespace Berzekers
{


    public class GameManager // where the game will run
    {

        public void GameLoop()
        {

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
            //Console.WriteLine($"{PersianRangedUnit}  HP:{PersianRangedUnit.HP} DeffenceValue:{PersianRangedUnit.DefVal} DeffenceMulti:{PersianRangedUnit.DefMulti}");
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
                if (i == 0) Console.WriteLine($"1st Dice Value:{cubeVal}");
                if (i == 1) Console.WriteLine($"2nd Dice Value:{cubeVal}");
                if (i == 2) Console.WriteLine($"3rd Dice Value:{cubeVal}");
                if (i >= 3) Console.WriteLine($"{cubeNam}th Dice Value: {cubeVal} ");
                if (i < scalar)
                {
                    Console.WriteLine($"");
                }
                value += cubeVal;
            }
            value += mod;
            Console.WriteLine($"value is {value}");
            return value;
        }

        public override string ToString()
        {
            return $"die type:{_die}sides, times to roll:{_scalar}, modifier{_mod} throwing dices....";
          
        }
        public override bool Equals([NotNullWhen(true)] object? obj)
        {

            if (obj is Dice diceObj) // casting obj as dice
            {

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
        private string _name = "John Doe"; 
        public virtual string Name { get => _name; protected set => _name = value; } 

        private int _carryingCapacity = 100; 
        public virtual int CarryingCapacity { get => _carryingCapacity; protected set => _carryingCapacity = value; } 
        private int _damageMod = 0; 
        public virtual int DamageMod { get => _damageMod; protected set => _damageMod = value; } 

        private int _hitChanceMod = 0; 
        public virtual int HitChanceMod { get => _hitChanceMod; protected set => _hitChanceMod = value; } 

        private int _defenceChanceMod = 0; 
        public virtual int DefenceChanceMod { get => _defenceChanceMod; protected set => _defenceChanceMod = value; } 
        public virtual Race Races { get => _race; set => _race = value; } 

        private int _hp = 10; 
        public virtual int HP { get => _hp; protected set => _hp = value; } 

        private int _defVal = 2; 
        public virtual int DefVal { get => _defVal; protected set => _defVal = value; } 

        

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
//        public Dictionary<Dice, string> MultipleDice()
//        {
//            //Dice hitChanceDice;
//            //hitChanceDice = new Dice(6,2,HitChanceMod);
//            //Dice defenderChanceDice;
//            //defenderChanceDice = new Dice(6,2,DefenceChanceMod);
//            //Dice damageDice;
//            //damageDice = new Dice(6,2,DamageMod);
//           // Dice[] multipleDice = { hitChanceDice, defenderChanceDice, damageDice };
//            //var multipleDiceDicionary = Enumerable.Range(0, multipleDice.Length).ToDictionary(x => multipleDice[x]);
//           //var multipleDice = new Dictionary<Dice, string>();
//           // multipleDice.Add(hitChanceDice, "hitChanceDice");
//           // multipleDice.Add(defenderChanceDice, "defenderChanceDice");
//           // multipleDice.Add(damageDice, "damageDice");
//           // return multipleDice;

//;
//        }
        //public int[] DiceRollValues(Dictionary<Dice, int> multipleDice)
        //{
        //    MultipleDice();
        //    int hitChance = multipleDice[0]
        //    int hitChance = multipleDice[0].roll();
        //    Console.WriteLine($"hit chance is: {hitChance}");
        //    int defenderChance = multipleDice[1].roll();
        //    Console.WriteLine($"defender chance is: {defenderChance}");
        //    int DMG = multipleDice[2].roll();

        //    int[] diceRollValues = { hitChance, defenderChance, DMG };
        //    return diceRollValues;
           
        //}
        
        public int CreateHitChanceDice()
        {  
             Dice hitChanceDice;
             hitChanceDice = new Dice(6, 2, HitChanceMod);
             int hitChance = hitChanceDice.roll();   
             return hitChance; 
        }
        public int CreateDefendChanceDice()
        {
            Dice defendChanceDice;
            defendChanceDice = new Dice(6, 2, HitChanceMod);
            int defendChance = defendChanceDice.roll();
            return defendChance;
        }
        public int CreateDamageDice()
        {
            Dice damageChanceDice;
            damageChanceDice = new Dice(6, 2, HitChanceMod);
            int damage = damageChanceDice.roll();
            return damage;
        }
        public virtual void Attack(Character defender)
        {
            
            
            defender.Defend(this);
        }
        public virtual void Defend(Character attacker)
        {



            int hitChance =  CreateHitChanceDice();     
            int defenderChance = CreateDefendChanceDice();
     
            int damage = CreateDamageDice();
            Console.WriteLine("");
            Console.WriteLine("damage chance is active");

            if (hitChance > defenderChance)
            {
                Console.WriteLine($"hit is succesful");

                if (damage <= DefVal)
                {
                    return;
                }
                Console.WriteLine($"damage is: {damage} DefenceValue is:{DefVal}");
                HP -= (damage - DefVal);
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

        public override void Defend(Character attacker)
        {

            int hitChance = CreateHitChanceDice();
            int defenderChance = CreateDefendChanceDice();
            int damage = CreateDamageDice();
            


            if (damage * MeleeMulti <= DefVal)
            {
                return;
            }
            HP -= ((damage * MeleeMulti) - DefVal);
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
            Console.WriteLine("hitDice throw");
            int hitChance = CreateHitChanceDice();
            Console.WriteLine("DefendDice throw");
            int defenderChance = this.CreateDefendChanceDice();
            int damage = CreateDamageDice();
            
            

            if (damage <= DefVal * DefMulti)
            {
                return;
            }
            HP -= (damage - (DefVal * DefMulti));
        }

    }
    internal abstract class RangedUnit : Character // can attack more then once according to how much projectiles they have
    {

        private int _projectileCount = 2;

        public RangedUnit(Race race)
        {
        }

        public virtual int ProjCount { get => _projectileCount; protected set => _projectileCount = value; }

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