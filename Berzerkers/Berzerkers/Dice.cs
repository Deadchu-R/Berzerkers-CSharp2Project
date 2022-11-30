using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    class Dice : IRandomProvider
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
        public int Roll()
        {

            uint die = this._die;
            uint scalar = this._scalar;
            int mod = this._mod;
            Console.WriteLine(this.ToString());
            Random rnd = new Random();
            int value = 0;
            int cubeNam = 0;
            Console.WriteLine($" Dice {scalar} times");
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

        public int ProvideRandom() => Roll();
     
    }

}
