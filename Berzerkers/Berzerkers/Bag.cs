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
        List<int> numberCards = new List<int>();

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
            int cardValue;
            Random randomCards = new Random();
            if (numberCards.Count == 0)
            {
                Console.WriteLine("bag is out of cards, ReShuffling...");
                for (int i = 0; i < bagSize; i++)
                {
                    numberCards.Add(randomCards.Next(minNumber, maxNumber)); 
                }
            }
                int card = randomCards.Next(numberCards.Count);
                cardValue = numberCards[card];
                numberCards.Remove(card);
            Console.WriteLine($"end list count:{numberCards.Count}");
            return cardValue;
        }

        public int ProvideRandom() => DrawNumber();

    }
}
