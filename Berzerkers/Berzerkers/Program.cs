// ---- C# II (Dor Ben Dor) ----
//          Roee Tal
// -----------------------------

using Berzekers;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using static Character;
using static System.Net.Mime.MediaTypeNames;



namespace Berzekers
{



    }

  class Actor 
{
    private Race _race;
    private int _recources = 0;
    public virtual int Recources { get => _recources; protected set => _recources = value; }

    public Actor(Race race)
    {
        _race = race;
    }

    public void ActorWon(int enemyRecources)
    {
        Console.WriteLine($"stole {enemyRecources} from enemy");
    }
    public List<Character> CreateTeam(int teamSize)
    {
             List<Character> unitTeam = new List<Character>();
             Random randomRecources = new Random();
             _recources = randomRecources.Next(500);
        if (_race == Race.Nazis)
        {

            NaziMeleeUnit NaziMelee = new NaziMeleeUnit(Character.Race.Nazis);
            ChonkerUnit NaziChonker = new NaziChonkerUnit(Character.Race.Nazis);
            RangedUnit NaziRanged = new NaziRangedUnit(Character.Race.Nazis);
            for (int i = 1; i < teamSize; i++)
            {
                Random randomUnit = new Random();
                int unit = randomUnit.Next(0,3);
                if (unit == 0) unitTeam.Add(NaziMelee);
                if (unit == 1) unitTeam.Add(NaziChonker);
                if (unit == 2) unitTeam.Add(NaziRanged);
               
            }
            
        }
        if (_race == Race.Slavs)
        {
            RangedUnit SlavRanged = new SlavRangedUnit(Character.Race.Slavs);
            SlavMeleeUnit SlavMelee = new SlavMeleeUnit(Character.Race.Slavs);
            ChonkerUnit SlavChonker = new SlavChonkerUnit(Character.Race.Slavs);
            for (int i = 1; i < teamSize; i++)
            {
                Random randomUnit = new Random();
                int unit = randomUnit.Next(0, 2);
                if (unit == 0) unitTeam.Add(SlavMelee);
                if (unit == 1) unitTeam.Add(SlavChonker);
                if (unit == 2) unitTeam.Add(SlavRanged);
               
            }

        }
        if (_race == Race.Persians)
        {
            PersianMeleeUnit PersianMelee = new PersianMeleeUnit(Character.Race.Persians);
            ChonkerUnit PersianChonker = new PersianChonkerUnit(Character.Race.Persians);
            RangedUnit PersianRanged = new PersianRangedUnit(Character.Race.Persians);
            for (int i = 1; i < teamSize; i++)
            {
                Random randomUnit = new Random();
                int unit = randomUnit.Next(0, 2);
                if (unit == 0) unitTeam.Add(PersianMelee);
                if (unit == 1) unitTeam.Add(PersianChonker);
                if (unit == 2) unitTeam.Add(PersianRanged);
               
            }
        }
        foreach (Character unit in unitTeam)
        {
            Console.WriteLine(unit.Name);
        }
        return unitTeam;
    }  
}
public class GameManager // where the game will run
    {
        public static void Main(string[] args)
        {
         
            GameManager gameManager = new GameManager();
            gameManager.UnitsCombat();
        }

        public void UnitsCombat() // a method for Units Combat Algo
        {
        
           Actor Actor1 = new Actor(Race.Nazis);
           List<Character> unitTeam1 = Actor1.CreateTeam(3);
          Console.ReadLine();
            Actor Actor2 = new Actor(Race.Slavs);
            List<Character> unitTeam2 = Actor2.CreateTeam(3);
            Console.ReadLine();


            void RandomWeather(int turns)
            {
                
                if (turns % 3 == 0)
                {
                    Random randomWeatherChance = new Random();
                    int weatherChance = randomWeatherChance.Next(0, 3);
                    Console.WriteLine($"weatherChance is {weatherChance}");
                    if (weatherChance == 2)
                    {
                        Console.WriteLine("]]]]]]]]]]]]]]]]]");
                        Console.WriteLine("Switching Weather");
                        Console.WriteLine("]]]]]]]]]]]]]]]]]");
                        Random randomWeatherNum = new Random();
                        int weatherNum = randomWeatherNum.Next(0, 3);
                        foreach (Character c in unitTeam1)
                        {
                            c.SwitchWeather(weatherNum);
                        }
                        foreach (Character c in unitTeam2)
                        {
                            c.SwitchWeather(weatherNum);
                        }

                        if (unitTeam1.Count >= 0) unitTeam1[0].PrintWeather(weatherNum);
                        else if (unitTeam2.Count >= 0) unitTeam2[0].PrintWeather(weatherNum);

                    }
                }
            }
            int turns = 0;

            bool bothTeamsAlive = true;
            while (bothTeamsAlive)
            {
                bool team1Turn = true;
                if (team1Turn == true) // team1 turn
                {
                    RandomWeather(turns);
                    Console.WriteLine("-----------------");
                    Console.WriteLine("it is Team1 Turn:");
                    Console.WriteLine("-----------------");
                    Random rndAttacker = new Random();
                    int randomAttacker = rndAttacker.Next(0, unitTeam1.Count);
                    Random rndDefender = new Random();
                    int randomDefender = rndAttacker.Next(0, unitTeam2.Count);
                    Console.WriteLine($"Team1: {unitTeam1[randomAttacker].Name} is attacking Team2:{unitTeam2[randomDefender].Name} ");
                    unitTeam1[randomAttacker].Attack(unitTeam2[randomDefender]);
                    Console.WriteLine($"press anything to Finish Team1 Turn");
                    Console.ReadLine();
                    Console.Clear();
                    if (unitTeam2[randomDefender].isDead())
                    {
                        Console.WriteLine($"UnitTeam2: {unitTeam2[randomDefender].Name} is dead");
                        unitTeam2.Remove(unitTeam2[randomDefender]);

                        if (unitTeam2.Count <= 0)
                        {
                            Actor1.ActorWon(Actor2.Recources);
                            Console.WriteLine("team1 won");
                            bothTeamsAlive = false;
                            break;
                        }
                        for (int i = 0; i < unitTeam2.Count; i++)
                        {
                            Console.Write($"{unitTeam2[i].Name}is still alive. ");
                        }
                        turns++;
                   

                    }
                    Console.WriteLine($"press anything to continue ");
                    Console.ReadLine();
                    Console.Clear();
                    team1Turn = false;
                }
                if (team1Turn == false) // team 2 turn
                {
                    RandomWeather(turns);
                    Console.WriteLine("-----------------");
                    Console.WriteLine("it is Team2 Turn:");
                    Console.WriteLine("-----------------");
                    Random rndAttacker = new Random();
                    int randomAttacker = rndAttacker.Next(0, unitTeam2.Count);
                    Random rndDefender = new Random();
                    int randomDefender = rndAttacker.Next(0, unitTeam1.Count);

                    Console.WriteLine($"Team2: {unitTeam2[randomAttacker].Name} is attacking Team1:{unitTeam1[randomDefender].Name} ");
                    unitTeam2[randomAttacker].Attack(unitTeam1[randomDefender]);
                    Console.WriteLine($"press anything to Finish Team2 Turn");
                    Console.ReadLine();
                    Console.Clear();
                    if (unitTeam2.Count > 0)
                    {

                        if (unitTeam1[randomDefender].isDead())
                        {
                            Console.WriteLine($"UnitTeam1: {unitTeam1[randomDefender].Name} is dead");
                            unitTeam1.Remove(unitTeam1[randomDefender]);

                            if (unitTeam1.Count <= 0)
                            {
                                Console.WriteLine("team2 won");
                                Actor2.ActorWon(Actor1.Recources);
                            bothTeamsAlive = false;
                                break;
                            }
                            for (int i = 0; i < unitTeam1.Count; i++)
                            {
                                Console.Write(unitTeam1[i].Name);
                            }
                        }
                        turns++;

                    }

                    Console.WriteLine($"press anything to continue ");
                    Console.ReadLine();
                    Console.Clear();
                    team1Turn = false;

                }

            }
        }


        public bool TeamLost(int HP)
        {
            Console.WriteLine("GameOver");
            return HP <= 0;
        }
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
                if (i == 0) Console.Write($"1st Roll Value:{cubeVal}");
                if (i == 1) Console.Write($",2nd Roll Value:{cubeVal}");
                if (i == 2) Console.Write($",3rd Roll Value:{cubeVal}");
                if (i >= 3) Console.Write($",{cubeNam}th Roll Value: {cubeVal} ");
                value += cubeVal;
            }
            int moddedValue = value + mod;
            Console.WriteLine("");
            Console.WriteLine($"Value is:{moddedValue} = DiceValue:{value} + mod:{mod} ");
            Console.WriteLine("");
            return moddedValue;
        }

        public override string ToString()
        {
            return $"die type:{_die}sides, times to roll:{_scalar}, modifier{_mod} ";

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

        private int _blockValue = 2;
        public virtual int BlockValue { get => _blockValue; protected set => _blockValue = value; }

        public void SwitchWeather(int weatherNum)
        {
            Weather weatherEnum = (Weather)weatherNum;
            WeatherEffects(weatherEnum); 
        }



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
        public void PrintWeather(int weatherNum)
        {
            Weather weatherType = (Weather)weatherNum;
            
            if (weatherType == Weather.Sunny)
            {
                Console.WriteLine("===========");
                Console.WriteLine("it is sunny");
                Console.WriteLine("===========");
                Console.WriteLine($"Weather Changed HitChanceMod Changed to: {HitChanceMod}");
            }
            if (weatherType == Weather.Rainy)
            {
                Console.WriteLine("===========");
                Console.WriteLine("it is Rainy");
                Console.WriteLine("===========");
                Console.WriteLine($"Weather Changed HitChanceMod Changed to: {HitChanceMod}");
                Console.WriteLine($"Weather Changed DamageMod Changed to: {DamageMod}");


            }
            if (weatherType == Weather.Snowy)
            {
                Console.WriteLine("===========");
                Console.WriteLine("it is Snowy");
                Console.WriteLine("===========");
                Console.WriteLine($"Weather Changed HitChanceMod Changed to: {HitChanceMod}");

            }
        }

        public int CreateHitChanceDice()
        {
            Dice hitChanceDice;
            hitChanceDice = new Dice(6, 2, HitChanceMod);
            Console.WriteLine($"Rolling {this.Name}'s HitChanceDice {hitChanceDice._scalar} times");
            int hitChance = hitChanceDice.roll();
            return hitChance;
        }
        public int CreateDefendChanceDice()
        {
            Dice defendChanceDice;
            defendChanceDice = new Dice(6, 2, DefenceChanceMod);
            Console.WriteLine($"Rolling {this.Name}'s defendChanceDice {defendChanceDice._scalar} times");
            int defendChance = defendChanceDice.roll();
            return defendChance;
        }
        public int CreateDamageDice()
        {
            Dice damageDice;
            damageDice = new Dice(6, 2, DamageMod);
            Console.WriteLine($"Rolling {this.Name}'s DamageDice {damageDice._scalar} times");
            int damage = damageDice.roll();
            return damage;
        }
        public bool isDead()
        {
            if (HP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void Attack(Character defender)
        {

            int hitChance = CreateHitChanceDice();
            defender.Defend(this, hitChance);
        }
        public virtual void Defend(Character attacker, int hitChance)
        {
            int defenderChance = CreateDefendChanceDice();
            if (hitChance > defenderChance)
            {
                Console.WriteLine($"hit is succesful");
                int damage = CreateDamageDice();
                UnitDefendLogic(damage, attacker);
            }
            else
            {
                Console.WriteLine($"{attacker.Name} missed");
            }
        }

        public virtual void UnitDefendLogic(int damage, Character attcker)
        {
            if (damage <= BlockValue)
            {
                Console.WriteLine($"{damage} damage to {this.Name} was blocked by {Name} BlockValue of:{BlockValue}");
                return;
            }
            HP -= (damage - BlockValue);
            Console.WriteLine($"damage is: {damage} BlockValue is:{BlockValue}");
            Console.WriteLine($"damage is: {damage - BlockValue}");
            Console.WriteLine($"{this.Name} HP is now: {this.HP}");
        }


        public enum Race { Nazis, Slavs, Persians }
    }
    internal abstract class MeleeUnit : Character // can attack by a multiplier
    {

        private int _meleeMulti = 2
        ;

        public MeleeUnit(Race race)
        {

        }


        public virtual int MeleeMulti { get => _meleeMulti; protected set => _meleeMulti = value; }

        public override void UnitDefendLogic(int damage, Character attacker)
        {
            if (damage + MeleeMulti <= BlockValue)
            {

                Console.WriteLine($"{damage} Damage + {MeleeMulti} BlockValue  was blocked by BlockValue of:{BlockValue}");
                return;
            }
            HP -= ((damage + MeleeMulti) - BlockValue);
            Console.WriteLine($"{damage} Damage + {MeleeMulti} MeleeMulti is {damage * MeleeMulti}");
            Console.WriteLine($"damage is: {damage +
                MeleeMulti} BlockValue is:{BlockValue}");
            Console.WriteLine($"{this.Name} HP is now: {this.HP}");
        }
    }
    internal abstract class ChonkerUnit : Character // can defend by a multiplier
    {
        private int _DefenceMulti = 2;

        public ChonkerUnit(Race race)
        {
        }

        public virtual int DefenceMulti { get => _DefenceMulti; protected set => _DefenceMulti = value; }


        public override void UnitDefendLogic(int damage, Character attacker)
        {
            if (damage <= BlockValue + DefenceMulti)
            {
                Console.WriteLine($"{damage} Damage  to {Name}  was blocked by {attacker.Name} BlockValue of:{BlockValue} + DefenceMulti of {DefenceMulti}");
                return;
            }
            HP -= (damage - (BlockValue + DefenceMulti));
            Console.WriteLine($"damage is: {damage} - (BlockValue {BlockValue} * DefenceMulti {DefenceMulti})");
            Console.WriteLine($"{this.Name} HP is now: {this.HP}");
        }

    }
    internal abstract class RangedUnit : Character // can attack more then once according to how much projectiles they have
    {

        private int _projectileCount = 2;

        public RangedUnit(Race race)
        {
        }

        public virtual int ProjectileCount { get => _projectileCount; protected set => _projectileCount = value; }


        public override void UnitDefendLogic(int damage, Character attacker)
        {
           
            for (int i = ProjectileCount; i > 0; i--)
            {
                if (damage <= BlockValue)
                {
                    Console.WriteLine($"{damage} Damage to {this.Name} was blocked by {this.Name} BlockValue of:{BlockValue}");
                    return;
                }
                HP -= (damage - BlockValue);
                Console.WriteLine($"Damaged {this.Name} by {damage} Damage - {BlockValue} BlockValue ");
                Console.WriteLine($"{this.Name} HP is now: {this.HP}");
                Console.WriteLine($"ProjCount {i}");
            }

        }
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
        public override int DefenceMulti { get => base.DefenceMulti + 1; protected set => base.DefenceMulti = value; }
    }
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
        public override int DefenceMulti { get => base.DefenceMulti + 2; protected set => base.DefenceMulti = value; }
    }
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



