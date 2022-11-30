using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Berzerkers.Character;

namespace Berzerkers
{
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
}
