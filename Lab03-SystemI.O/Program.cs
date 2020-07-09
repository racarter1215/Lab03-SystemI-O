using System;
using System.Reflection.Metadata.Ecma335;

namespace Lab03Challenge1
{
    public class Program
    {/// <summary>
     /// This method calls all subsequent methods as well as contain the console.writeline and console.readline
     /// so that unit tests can be run. Specifically, code for challenge 2 is held here so that the code to 
     /// create an average of values is in its own method
     /// </summary>
     /// <param name="args"></param>
        static void Main(string[] args)
        {
            int firstMethod = MultiplicationMethod("4 19 50");
            Console.WriteLine($"Here's the product for the numbers: {firstMethod}");
            Console.WriteLine("Enter a number between 2 and 10");
            string userAnswer = Console.ReadLine();
            if (!int.TryParse(userAnswer, out int userNumber))
            {
                throw new Exception("Please enter a number");
            }
            else if (userNumber < 2 || userNumber > 10)
            {
                throw new Exception("Please enter a number BETWEEN 2 and 10");
            }
            else
            {
                int[] userArray = new int[userNumber];
                for (int i = 0; i < userArray.Length; i++)
                {
                    Console.WriteLine($"Please enter a number {i + 1} of {userArray.Length}");
                    string userAnswers = Console.ReadLine();
                    if (int.TryParse(userAnswers, out int finalResponse))
                    {
                        userArray[i] = finalResponse;
                    }
                    else
                    {
                        throw new Exception("Please enter another number");
                    }
                }
                double average = PickRandomNumberThenGetAverage(userArray);
                Console.WriteLine($"The average number is {average}");
            }
            CreateDiamondDisplay(9);
            int bigValue = ArrayWithoutSortingIt(new int[] { 2, 2, 4, 6, 8, 8, 8 });
            Console.WriteLine($"The most common number in this array is {bigValue}");
            int[] genericArray = new int[] { 2, 4, 6, 8 };
            int result = MaximumValue(genericArray);
            Console.WriteLine($"The maximum result is {result}");



        }
        /// <summary>
        /// The following code handles challenge 1, where 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int MultiplicationMethod(string input)
        {
            string[] stringArray = input.Split(' ');

            if (stringArray.Length < 3)
            {
                return 0;
            }

            int product = 1;
            int[] intArray = new int[3];

            for (int i = 0; i < 3; i++)
            {
                //convert the string to an int
                bool numberConversion = int.TryParse(stringArray[i], out int returnValue);
                if (numberConversion)
                {
                    //if it's true
                    product *= returnValue;
                }
                else
                {
                    product *= 1;
                }
                //transfer to int
            }
            return product;
        }

        public static double PickRandomNumberThenGetAverage(int[] userArray)
        {
            int sum = 0;
            for (int i = 0; i < userArray.Length; i++)
            {
                sum += userArray[i];
            }
            double average = (double)sum / (double)userArray.Length;
            return average;
        }

        public static void CreateDiamondDisplay(int rowLength)
        {
            int center = ((rowLength + 1) / 2);
            string space = " ";
            char star = '*';
            for (int i = 1; i <= center; i++)
            {
                for (int j = 1; j <= (center - i); j++)
                {
                    Console.Write(space);
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write(star);
                }
                Console.WriteLine();
            }

            for (int i = center - 1; i > 0; i--)
            {
                for (int j = 1; j <= (center - i); j++)
                {
                    Console.Write(space);
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write(star);
                }
                Console.WriteLine();
            }
        }

        public static int ArrayWithoutSortingIt(int[] totalNumberArray)
        {
            int numberCount = 0;
            int LargestNumberCount = 0;
            int firstNumberInArray = totalNumberArray[0];
            int numbersIteratedThrough = totalNumberArray[0];
            for (int i = 0; i < totalNumberArray.Length; i++)
            {
                numberCount = 0;
                for (int j = 0; j < totalNumberArray.Length; j++)
                {
                    if (totalNumberArray[i] == totalNumberArray[j])
                    {
                        numberCount += 1;
                    }
                    if (LargestNumberCount < numberCount)
                    {
                        firstNumberInArray = totalNumberArray[i];
                        LargestNumberCount = numberCount;
                    }
                }
            }
            return firstNumberInArray;
        }

        public static int MaximumValue(int[] genericArray)
        {
            int largestNumber = genericArray[0];
            for (int i = 0; i < genericArray.Length; i++)
            {
                if (genericArray[i] > largestNumber)
                {
                    largestNumber = genericArray[i];
                }
            }
            return largestNumber;
        }
    }
}
