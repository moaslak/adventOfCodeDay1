using System;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\mas\\OneDrive - FlexDanmark\\Skole\\H2\\H2_Repo\\adventOfCodeDay1\\day2\\data.txt";
            string[] lines = File.ReadAllLines(path);
            List<string> elf = new List<string>();
            List<string> me = new List<string>();



            // part 1
            for(int i = 0; i < lines.Length; i++)
            {
                elf.Add(lines[i].Substring(0,1));
                if (elf[i] == "A")
                    elf[i] = "ROCK";
                if (elf[i] == "B")
                    elf[i] = "PAPER";
                if (elf[i] == "C")
                    elf[i] = "SCISSORS";

                me.Add(lines[i].Substring(2,1));
                if (me[i] == "X")
                    me[i] = "ROCK";
                if (me[i] == "Y")
                    me[i] = "PAPER";
                if (me[i] == "Z")
                    me[i] = "SCISSORS";
            }

            int points = 0;
            bool DRAW = false;
            for(int i = 0; i < lines.Length; i++)
            {
                int newPoints = 0;
                int buffer = 0;
                (DRAW, newPoints) = Draw(elf[i], me[i]);

                if (DRAW)
                {
                    Console.WriteLine("Draw! Elf played " + elf[i] + " and you played " + me[i]);
                }
                if (!DRAW)
                {
                    bool win = false;
                    (win, buffer) = Win(elf[i], me[i]);
                    if(!win)
                        Console.WriteLine("Loose! Elf played " + elf[i] + " and you played " + me[i]);
                    else
                        Console.WriteLine("Win! Elf played " + elf[i] + " and you played " + me[i]);
                    
                    newPoints = newPoints + buffer;
                }

                points = points + newPoints;
                Console.WriteLine("You get " + newPoints + " new points. Tolal points: " + points);
                Console.WriteLine();
                //Console.ReadKey();
            }
            Console.WriteLine();
            Console.WriteLine("Tournament end");
            Console.WriteLine("Total points: " + points);
            Console.ReadKey();

            // part 2
            points = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                if (me[i] == "ROCK")
                    me[i] = "Loose";
                if (me[i] == "PAPER")
                    me[i] = "Draw";
                if (me[i] == "SCISSORS")
                    me[i] = "Win";
            }

            for(int i = 0; i < lines.Length; i++)
            {
                int newPoints = 0;
                if (me[i] == "Draw")
                {
                    newPoints = DrawPartTwo(elf[i]);
                    Console.WriteLine("Draw! Both played " + elf[i] +". New points: " + newPoints + ". Total points: " + (points + newPoints));
                }
                else
                {
                    newPoints = winPartTwo(elf[i], me[i]);
                    if (me[i] == "Win")
                        Console.WriteLine("Win! Elf played: " + elf[i] + ". New points: " + newPoints + ". Total points: " + (points + newPoints));
                    else
                        Console.WriteLine("Loose! Elf played: " + elf[i] + ". New points: " + newPoints + ". Total points: " + (points + newPoints));
                }
                Console.WriteLine();
                points = points + newPoints;
            }
            Console.WriteLine();
            Console.WriteLine("Tournament end");
            Console.WriteLine("Total points: " + points);
            Console.ReadKey();
        }

        static int DrawPartTwo(string elf)
        {
            int points = 0;
            if (elf == "ROCK")
                points = 1;
            if (elf == "PAPER")
                points = 2;
            if (elf == "SCISSORS")
                points = 3;

            return points + 3;
        }

        private static int winPartTwo(string elf, string me)
        {
            int points = 0;
            if(me == "Win")
            {
                if (elf == "ROCK")
                    points = 2;
                if (elf == "PAPER")
                    points = 3;
                if (elf == "SCISSORS")
                    points = 1;

                points = points + 6;
            }
            else
            {
                if (elf == "ROCK")
                    points = 3;
                if (elf == "PAPER")
                    points = 1;
                if (elf == "SCISSORS")
                    points = 2;
            }
            return points;
        }

        private static (bool, int) Draw(string elf, string me)
        {
            int points = pointsForMyPlay(me);
            bool DRAW = true;

            if (elf == me )
            {
                DRAW = true;
            }   
            else
            {
                DRAW = false;
            }

            if (DRAW)
                points = points + 3;
            return (DRAW, points);
        }

        private static (bool, int) Win(string elf, string me)
        {
            // A = ROCK
            // B = PAPER
            // C = SCISSORS

            // Y = PAPER
            // X = ROCK
            // Z = SCISSORS

            //1 for Rock, 2 for Paper, and 3 for Scissors

            bool WIN = false;
            int points = 0;

            if (elf == "ROCK" && me == "PAPER")
            {
                WIN = true;
            }
            if(elf == "ROCK" && me == "SCISSORS")
            {
                WIN = false;
            }
            if (elf == "PAPER" && me == "ROCK")
            {
                WIN = false;
            }
            if (elf == "PAPER" && me == "SCISSORS")
            {
                WIN = true;
            }
            if(elf == "SCISSORS" && me == "PAPER")
            {
                WIN = false;
            }
            if(elf == "SCISSORS" && me == "ROCK")
            {
                WIN = true;
            }

            if (WIN)
                points = points + 6;

            return (WIN, points);
        }

        private static int pointsForMyPlay(string me)
        {
            int points = 0;

            if (me == "PAPER")
                points = 2;
            if (me == "ROCK")
                points = 1;
            if (me == "SCISSORS")
                points = 3;

            return points;
        }
    }
}