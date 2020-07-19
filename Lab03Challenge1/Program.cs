using System;
using System.IO;

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
                    if(int.TryParse(userAnswers, out int finalResponse))
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
            
            EnterWordSaveToFile();
            ListTestFileWords();
            DeleteText();
            Console.WriteLine("Please write words to make a sentence");
            string userInput = Console.ReadLine();
            string[] userSentence = InputSentence(userInput);
            string output = "";
            for (int i = 0; i < userSentence.Length; i++)
            {
                output += userSentence[i];
            }
            Console.WriteLine(output);






        }
        /// <summary>
        /// The following code handles challenge 1, where a user is asked for 3 numbers, and they are multiplied together
        /// </summary>
        /// <param name="input"></param>
        /// <returns>the product of the input</returns>
        public static int MultiplicationMethod(string input)
        {
            string[] stringArray = input.Split(' ');

            if(stringArray.Length < 3)
            {
                return 0;
            }

            int product = 1;
            int[] intArray = new int[3];

            for (int i = 0; i < 3; i++)
            {
                //convert the string to an int
                bool numberConversion = int.TryParse(stringArray[i], out int returnValue);
                if(numberConversion)
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
        /// <summary>
        /// below method asks a user to pick a number, then give a set of numbers equal to that first number, then an average of those numbers is given
        /// </summary>
        /// <param name="userArray"></param>
        /// <returns>an average of the second sets of user input</returns>
        public static double PickRandomNumberThenGetAverage(int[] userArray)
        {
            int sum = 0;
            for(int i = 0; i < userArray.Length; i++)
            {
                sum += userArray[i];
            }
            double average = (double) sum / (double) userArray.Length;
            return average; 
        }
        /// <summary>
        /// below is a method that, using the "*" character, makes a diamond
        /// </summary>
        /// <param name="rowLength">it outputs a diamond shape</param>
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
        /// <summary>
        /// the below method returns a sorted array without using the .Sort()
        /// </summary>
        /// <param name="totalNumberArray"></param>
        /// <returns>a new sorted array</returns>
        public static int ArrayWithoutSortingIt(int[] totalNumberArray)
        {
            int numberCount = 0;
            int LargestNumberCount = 0;
            int firstNumberInArray = totalNumberArray[0];
            int numbersIteratedThrough = totalNumberArray[0];
            for (int i = 0; i < totalNumberArray.Length; i++)
            {
                numberCount = 0;
                for (int j = 0; j <totalNumberArray.Length; j++)
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
        /// <summary>
        /// below is a method that displays the largest value in an array
        /// </summary>
        /// <param name="genericArray"></param>
        /// <returns>an integer which represents the largest number in the array</returns>
        public static int MaximumValue(int[] genericArray)
        {
            int largestNumber = genericArray[0];
            for (int i = 0; i < genericArray.Length; i++)
            {
                if(genericArray[i] > largestNumber)
                {
                    largestNumber = genericArray[i];
                }
            }
            return largestNumber;
        }
        /// <summary>
        /// below is a method that allows a user to enter a word into a text document
        /// </summary>
        public static void EnterWordSaveToFile()
        {
            Console.WriteLine("Please write a word");
            string[] inputArray = new string[1];
            string userInput = Console.ReadLine();
            inputArray[0] = userInput;
            string textPath = "../../Words.txt";
            File.AppendAllLines(textPath, inputArray);

        }
        /// <summary>
        /// the below method returns a list of all words in the text document
        /// </summary>
        public static void ListTestFileWords()
        {
            string filePath = "../../Words.txt";
            string[] lineArray = File.ReadAllLines(filePath);
            Console.WriteLine(String.Join('\n', lineArray));
        }
        /// <summary>
        /// the below method deletes a line of text from the text document
        /// </summary>
        public static void DeleteText()
        {
            string filePath = "../../Words.txt";
            string newFilePath = "../../New.txt";

            Console.WriteLine("Please write the word to be deleted");
            string userInput = Console.ReadLine();
            string[] readArray = File.ReadAllLines(filePath);
            string[] writeArray = new string[readArray.Length - 1];
            int counter = 0;
            for (int i = 0; i < readArray.Length; i++)
            {
                if(readArray[i] != userInput)
                {
                    writeArray[counter] = readArray[i];
                    counter++;
                }
            }
            File.WriteAllLines(newFilePath, writeArray);
            File.Delete(filePath);
            File.Move(newFilePath, filePath);
        }
        /// <summary>
        /// the below method allows a user to input a sentence to be viewed on the text document
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>a sentence of strings, with a number value to their length</returns>
        public static string[] InputSentence(string userInput)
        {
            string[] userSentence = userInput.Split(" ");
            string[] count = new string[userSentence.Length];
            for (int i = 0; i < userSentence.Length; i++)
            {
                if (userSentence.Length - 1 == i)
                {
                    count[i] += $" {userSentence[i]}: {userSentence[i].Length}";
                }
                else
                {
                    count[i] += $" {userSentence[i]}: {userSentence[i].Length},";
                }
            }
            return count;
        }
    }
}
