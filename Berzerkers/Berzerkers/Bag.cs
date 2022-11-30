using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berzerkers
{
    internal class Bag : IRandomProvider
    {
        public int _bagSize;
        public int _minNumber;
        public int _maxNumber;

        public Bag(int bagSize, int minNumber, int maxNumber)
        {
            this._bagSize = bagSize;
            this._minNumber = minNumber;
            this._maxNumber = maxNumber;
        }

        public int DrawNumber()
        {
            int bagSize = this._bagSize;
            int minNumber = this._minNumber;
            int maxNumber = this._maxNumber;

            List<int> numberCards = new List<int>(bagSize);
            Random randomCards = new Random();
            if (numberCards.Count == 0)
            {
                for (int i = 0; i < _bagSize; i++)
                {
                    numberCards[i] = randomCards.Next(_minNumber, _maxNumber);
                }
            }
                int Card = randomCards.Next(numberCards.Count);
                numberCards.Remove(Card);
                return Card;
        }

        public int ProvideRandom() => DrawNumber();

    }
}
