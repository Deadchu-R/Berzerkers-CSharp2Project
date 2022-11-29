﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
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
            int hitChance = hitChanceDice.Roll();
            return hitChance;
        }
        public int CreateDefendChanceDice()
        {
            Dice defendChanceDice;
            defendChanceDice = new Dice(6, 2, DefenceChanceMod);
            Console.WriteLine($"Rolling {this.Name}'s defendChanceDice {defendChanceDice._scalar} times");
            int defendChance = defendChanceDice.Roll();
            return defendChance;
        }
        public int CreateDamageDice()
        {
            Dice damageDice;
            damageDice = new Dice(6, 2, DamageMod);
            Console.WriteLine($"Rolling {this.Name}'s DamageDice {damageDice._scalar} times");
            int damage = damageDice.Roll();
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
}