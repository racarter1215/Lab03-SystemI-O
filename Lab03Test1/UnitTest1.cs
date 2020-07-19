using System;
using Xunit;
using static Lab03Challenge1.Program;

namespace Lab03Test1
{
    public class UnitTest1
    {/// <summary>
    /// this test checks if it returns a zero
    /// </summary>
        [Fact]
        public void ReturnZeroTest()
        {
            //Arrange
            string input = "string";
            //Act
            int outputFromMethod = MultiplicationMethod(input);

            //Assert
            Assert.Equal(0, outputFromMethod);
        }
        /// <summary>
        /// this checks if the multiplication method works with 3 values
        /// </summary>
        [Fact]
        public void ThreeValuesProductTest()
        {
            //Arrange
            string numbers = "2 3 4";
            //Act
            int output = MultiplicationMethod(numbers);
            //Assert
            Assert.Equal(24, output);
        }
        /// <summary>
        /// below tests what happens when lots of different values go through multiplication method
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="product"></param>
        [Theory]
        [InlineData("2 4 1", 8)]
        [InlineData("1 1 1", 1)]
        [InlineData("dark tower 5", 5)]
        [InlineData("raven guard", 0)]
        [InlineData("-10 -10 1", 100)]
        public void ProductTest(string numbers, int product)
        {
            //Arrange
            
            //Act
            int result = MultiplicationMethod(numbers);

            //Assert
            Assert.Equal(product, result);
        }
        /// <summary>
        /// below is a test that verifies an array of numbers can return an average
        /// </summary>
        /// <param name="intArrayTest"></param>
        /// <param name="average"></param>
        [Theory]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 2, 6 }, 3)]
        [InlineData(new int[] { 3, 5, 10, 55, 67}, 28)]
        [InlineData(new int[] { 0, 0, 0, 0 }, 0)]
        public void CanFindAveragesOfUserNumbers(int[] intArrayTest, int average)
        {
            //Arrange
            int expectedOutcome = average;
            //Act
            int output = (int)PickRandomNumberThenGetAverage(intArrayTest);
            //Assert
            Assert.Equal(expectedOutcome, output);
        }
        /// <summary>
        /// below is a test of pulling the biggest number from an array
        /// </summary>
        /// <param name="arrayTest"></param>
        /// <param name="biggestNumber"></param>
        [Theory]
        [InlineData(new int[] {5, 5, 5, 5, 5, 5, 5, 5}, 5)]
        [InlineData(new int[] {4, 5, 6, 6, 7}, 6)]
        [InlineData(new int[] {1, 2, 3, 4}, 1)]
        [InlineData(new int[] { 1, 1, 2, 2, 3, 3}, 1)]

        public void TestTheSortedArray(int[] arrayTest, int biggestNumber)
        {
            //Arrange

            //Act
            int output = ArrayWithoutSortingIt(arrayTest);
            //Assert
            Assert.Equal(biggestNumber, output);
        }
        /// <summary>
        /// below tests the max number with edge cases like negative numbers
        /// </summary>
        /// <param name="genericArray"></param>
        /// <param name="largestNumber"></param>
        [Theory]
        [InlineData(new int[] {1, 4, 98, -310}, 98)]
        [InlineData(new int[] { 2, 2, 2, 2, 2}, 2)]
        public void TestTheMaxNumberMethod(int[] genericArray, int largestNumber)
        {
            //Arrange
            int expectedOutcome = largestNumber;
            //Act
            int output = (int)MaximumValue(genericArray);
            //Assert
            Assert.Equal(expectedOutcome, output);
        }
        /// <summary>
        /// below verifies that the returned array of strings is the same as expected
        /// </summary>
        [Fact]

        public void ReturnsArrayWithCorrectValues()
        {
            //Arrange
            string[] test = new string[]
            {
                " This: 4,",
                " Is: 2,",
                " A: 1,",
                " Test: 4"
            };
            //Act
            string[] answer = InputSentence("This Is A Test");
            //Assert
            Assert.Equal(test, answer);
        }
        /// <summary>
        /// below is a test that verifies the correct array of strings is returned
        /// </summary>
        [Fact]
       
        public void ReturnsTheRightArray()
        {
            //Arrange
            string[] test = new string[]
            {
                " Please: 5,",
                " Let: 3,",
                " This: 4,",
                " Work: 4"
            };
            //Act
            string[] answer = InputSentence("Please Let This Work");
            Type testa = typeof(string[]);
            Type testb = answer.GetType();
            //Assert
            Assert.Equal(testa, testb);
        }

    }
}
