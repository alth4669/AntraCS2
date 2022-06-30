using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CS2
{
    public class CS2Class1
    {
        public void CopyArray()
        {
            int[] initial = new int[10];
            for (int i = 0; i < 10; i++)
            {
                initial[i] = i;
            }

            int[] copiedArray = new int[initial.Length];
            for (int i = 0; i < initial.Length; i++)
            {
                copiedArray[i] = initial[i];
            }

            // list contents of both arrays
            for (int i = 0; i < initial.Length; i++)
            {
                Console.Write(initial[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < copiedArray.Length; i++)
            {
                Console.Write(copiedArray[i] + " ");
            }
        }

        public void ManageList()
        {
            List<string> list1 = new List<string>();
            string input;
            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                input = Console.ReadLine();
                string action = input.Substring(0, 2);
                switch (action)
                {
                    case "+ ":
                        list1.Add(input.Substring(2));
                        break;
                    case "- ":
                        list1.Remove(input.Substring(2));
                        break;
                    case "--":
                        if (input.Length == 2)
                        {
                            list1.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("If trying to clear list, please use exactly '--'");
                            break;
                        }
                    default:
                        Console.WriteLine("Please enter a valid command.");
                        break;
                }
                Console.WriteLine("List Contents: ");
                for (int i = 0; i < list1.Count; i++)
                {
                    Console.WriteLine(list1[i]);
                }
            }
        }

        /* 
        * Function isPrime was taken from the wikipedia page regarding Primality Testing
        * see https://en.wikipedia.org/wiki/Primality_test for details
        */

        static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n <= 1 || n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        static int[] FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primes = new List<int>();
            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
        }

        static int[] RotateArray(int[] init_array, int rotations)
        {
            int[] rotatedArray = new int[init_array.Length];
            for (int i = 0; i < init_array.Length; i++)
            {
                rotatedArray[(i + rotations) % init_array.Length] = init_array[i];
            }
            return rotatedArray;
        }

        static int[] SumRotations(int[] init_array, int rotations)
        {
            int[] sum = new int[init_array.Length];
            int[] current_rotation = init_array;
            for (int i = 0; i < rotations; i++)
            {
                current_rotation = RotateArray(current_rotation, 1);
                for (int j = 0; j < current_rotation.Length; j++)
                {
                    sum[j] += current_rotation[j];
                }
            }
            return sum;
        }

        public void RotateAndSum()
        {
            string input1;
            int input2;

            Console.WriteLine("Input");
            input1 = Console.ReadLine();
            input2 = int.Parse(Console.ReadLine());

            string[] s_numbs = input1.Split(' ');

            int[] i_numbs = new int[s_numbs.Length];

            for (int i = 0; i < s_numbs.Length; i++)
            {
                i_numbs[i] = int.Parse(s_numbs[i]);
            }

            int[] sum_rotations = SumRotations(i_numbs, input2);

            Console.WriteLine("Output");
            for (int i = 0; i < sum_rotations.Length; i++)
            {
                Console.Write($"{sum_rotations[i]} ");
            }
        }

        public void LongestSequence()
        {
            string input1;

            Console.WriteLine("Input");
            input1 = Console.ReadLine();

            string[] s_numbs = input1.Split(' ');

            int[] i_numbs = new int[s_numbs.Length];

            for (int i = 0; i < s_numbs.Length; i++)
            {
                i_numbs[i] = int.Parse(s_numbs[i]);
            }

            int currentElement = i_numbs[0];
            int longestElement = i_numbs[0];
            int currentStreak = 1;
            int longestStreak = 1;

            for (int i = 1; i < i_numbs.Length; i++)
            {
                if (i_numbs[i] != currentElement)
                {
                    currentElement = i_numbs[i];
                    currentStreak = 1;
                }
                else
                {
                    currentStreak += 1;
                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                        longestElement = i_numbs[i];
                    }
                }
            }
            Console.WriteLine("Output");
            for (int i=0; i<longestStreak; i++)
            {
                Console.Write($"{longestElement} ");
            }

        }

        public void MostFrequentNumber()
        {
            string input1;
            Dictionary<string, int> numberCounts = new Dictionary<string, int>();

            Console.WriteLine("Input");
            input1 = Console.ReadLine();

            string[] s_numbs = input1.Split(' ');

            foreach (string Number in s_numbs)
            {
                if (numberCounts.ContainsKey(Number))
                {
                    numberCounts[Number]++;
                }
                else
                {
                    numberCounts[Number] = 1;
                }
            }

            int highestCount = numberCounts.Values.MaxBy(x => x);
            List<string> frequentNumbers = new List<string>();

            foreach (string key in numberCounts.Keys)
            {
                if (numberCounts[key] == highestCount)
                {
                    frequentNumbers.Add(key);
                }
            }
            Console.WriteLine("Output");
            if (frequentNumbers.Count == 1)
            {
                Console.WriteLine($"The number {frequentNumbers[0]} is the most frequent (occurs {highestCount} times)");
            }
            else
            {
                Console.Write($"The numbers ");
                foreach (string number in frequentNumbers)
                {
                    Console.Write(number + ' ');
                }
                Console.Write($"have the same maximal frequency (occurs {highestCount} times). The leftmost of them is {frequentNumbers[0]}");
            }
        }

        public void ReverseString()
        {
            string input;
            Console.WriteLine("Input");
            input = Console.ReadLine();
            char[] charArray = input.ToCharArray();

            Array.Reverse(charArray);

            Console.WriteLine("Output with Reversed char array");
            Console.WriteLine(new string(charArray));

            Console.WriteLine("Output printing letters in reverse direction");
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }

        }

        public void ReverseSentence()
        {
            string pattern = "[.,:;=()&[\\]\"'\\/!? ]+";
            Regex r1 = new Regex(pattern);

            string input;
            Console.WriteLine("Input");
            input = Console.ReadLine();

            List<string> words = new List<string>(r1.Split(input));
            words.RemoveAll(s => s == "");

            List<Match> delims = new List<Match>(Regex.Matches(input, pattern));

            StringBuilder reversedString = new StringBuilder("");

            string status = "words";
            while (words.Count > 0 || delims.Count > 0)
            {
                if (status == "words")
                {
                    if (words.Count == 0)
                    {
                        status = "delims";
                    }
                    else
                    {
                        string lastWord = words.Last();
                        reversedString.Append(lastWord);
                        words.RemoveAt(words.Count-1);
                        status = "delims";
                    }
                }
                else if (status == "delims")
                {
                    if (delims.Count == 0)
                    {
                        status = "words";
                    }
                    else
                    {
                        reversedString.Append(delims.First());
                        delims.Remove(delims.First());
                        status = "words";
                    }
                }
            }
            Console.WriteLine(reversedString);
        }

        public void Palindromes()
        {
            string input;
            Console.WriteLine("Input");
            input = Console.ReadLine();

            string pattern = "[.,:;=()&[\\]\"'\\/!? ]+";
            Regex r1 = new Regex(pattern);

            List<string> words = new List<string>(r1.Split(input));
            words.RemoveAll(s => s == "");
            words.Sort();

            List<string> palindromes = new List<string>();
            foreach (string word in words)
            {
                string reverse = new string(word.ToCharArray().Reverse().ToArray());
                if (word == reverse)
                {
                    Console.WriteLine("They're equal");
                    palindromes.Add(word);
                }
            }
            Console.WriteLine("Output");
            foreach(string p in palindromes)
            {
                Console.Write(p + ", ");
            }
        }

        public void ParseURL()
        {
            string input;
            Console.WriteLine("Input");
            input = Console.ReadLine();

            string pattern = "[:/]+";
            Regex r1 = new Regex(pattern);

            List<string> words = new List<string>(r1.Split(input));
            words.RemoveAll(s => s == "");

            for (int i=0; i<words.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            Console.WriteLine($"[protocol] = {words[i]}");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine($"[server] = {words[i]}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"[resource] = {words[i]}");
                            break;
                        }
                }
            }
        }
    }
}
