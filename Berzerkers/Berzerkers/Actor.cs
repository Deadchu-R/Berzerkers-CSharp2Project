using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Berzerkers.Character;

namespace Berzerkers
{
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
                    int unit = randomUnit.Next(0, 3);
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
}
