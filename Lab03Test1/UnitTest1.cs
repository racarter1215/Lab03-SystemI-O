using System;
using Xunit;
using static Lab03Challenge1.Program;

namespace Lab03Test1
{
    public class UnitTest1
    {
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
