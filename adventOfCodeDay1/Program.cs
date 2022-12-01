using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C:\\Users\\mas\\OneDrive - FlexDanmark\\Skole\\H2\\H2_Repo\\adventOfCodeDay1\\adventOfCodeDay1\\data.txt");
            List<int> elves = new List<int>();

            int buffer = 0;

            // part one

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                    buffer = buffer + Convert.ToInt32(lines[i]);
                else
                {
                    elves.Add(buffer);
                    buffer = 0;
                }
                    

            }
            int max = elves.Max();
            int index = elves.IndexOf(max);

            Console.WriteLine("Elf numnber " + index + " is carryien " + max);

            Console.ReadKey();

            // part two
            int topThreeMax = max;
            int reps = 0;
            do
            {
                elves.RemoveAt(index);
                topThreeMax = topThreeMax + elves.Max();
                index = elves.IndexOf(elves.Max());
                reps++;
            } while (reps < 2);
            Console.WriteLine("The top three elbes are carrying: " + topThreeMax);
            Console.ReadKey();

        }
    }
}