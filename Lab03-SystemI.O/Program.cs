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
            //this set of code lines basically makes throw exceptions for numbers that don't follow the criteria
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
                //this for loop takes in the user data, parses it, and creates a variable out of it. It also manages a throw exception if the number is bad.
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
            //these code lines call the different methods I've done so far, plus console lines for user readability
            CreateDiamondDisplay(9);
            int bigValue = ArrayWithoutSortingIt(new int[] { 2, 2, 4, 6, 8, 8, 8 });
            Console.WriteLine($"The most common number in this array is {bigValue}");
            int[] genericArray = new int[] { 2, 4, 6, 8 };
            int result = MaximumValue(genericArray);
            Console.WriteLine($"The maximum result is {result}");



        }
        /// <summary>
        /// The following code handles challenge 1, where you multiply 3 numbers, in essense
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int MultiplicationMethod(string input)
        {//splits the string array into individual indexes for further manipulation
            string[] stringArray = input.Split(' ');

            if (stringArray.Length < 3)
            {//says if its less than 3 return 0
                return 0;
            }

            int product = 1;
            int[] intArray = new int[3];

            for (int i = 0; i < 3; i++)
            {
                //convert the string to an integer
                bool numberConversion = int.TryParse(stringArray[i], out int returnValue);
                if (numberConversion)
                {
                    //checks if it's true
                    product *= returnValue;
                }
                else
                {
                    product *= 1;
                }
                //transfer to integer
            }
            return product;
        }
        /// <summary>
        /// This method takes the array of numbers made in the Main method and generates an average
        /// </summary>
        /// <param name="userArray"></param>
        /// <returns></returns>
        public static double PickRandomNumberThenGetAverage(int[] userArray)
        {
            int sum = 0;
            for (int i = 0; i < userArray.Length; i++)
            {
                sum += userArray[i];
            }
            //creates variable average from sum divided by userarray.length
            double average = (double)sum / (double)userArray.Length;
            return average;
        }
        /// <summary>
        /// This method creates the diamond shape in the terminal
        /// </summary>
        /// <param name="rowLength"></param>
        public static void CreateDiamondDisplay(int rowLength)
        {//below are named variables used within the code logic
            int center = ((rowLength + 1) / 2);
            string space = " ";
            char star = '*';
            //the first "greater" for loop creates the top of the diamond
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
            //the bottom "greater" for loop creates the bottom half
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
        /// <summary>
        /// This method sorts and array without using .sort() and returns the largest number in the array
        /// </summary>
        /// <param name="totalNumberArray"></param>
        /// <returns></returns>
        public static int ArrayWithoutSortingIt(int[] totalNumberArray)
        {//below are the variable declarations for the code logic
            int numberCount = 0;
            int LargestNumberCount = 0;
            int firstNumberInArray = totalNumberArray[0];
            int numbersIteratedThrough = totalNumberArray[0];
            //the outer for loop goes through the length of the array
            for (int i = 0; i < totalNumberArray.Length; i++)
            {
                numberCount = 0;
                for (int j = 0; j < totalNumberArray.Length; j++)
                {
                    if (totalNumberArray[i] == totalNumberArray[j])
                    {//this adds one to the numberCount
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
        /// <summary>
        /// This method finds the largest value in the array
        /// </summary>
        /// <param name="genericArray"></param>
        /// <returns></returns>
        public static int MaximumValue(int[] genericArray)
        {
            int largestNumber = genericArray[0];
            //this for loop looks for the most recent number and compares it to the next, over and over again, until the biggest one remains.
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
