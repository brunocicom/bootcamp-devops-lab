using Xunit;
using System;
using BootcampDevOpsLab.Services;
using BootcampDevOpsLab.Services.Interfaces;

namespace BootcampDevOpsLab.Unit.Tests
{
    public class MathServiceTest
    {
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(5, 6, 11)]
        public void AddTest(decimal firstValue, decimal secondValue, decimal expected)
        {
            // Arrange
            IMathService math = new MathService();

            // Act
            decimal actual = math.Add(firstValue, secondValue);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(7, 8, -1)]
        public void SobtractTest(decimal firstValue, decimal secondValue, decimal expected)
        {
            // Arrange
            IMathService math = new MathService();

            // Act
            decimal actual = math.Subtract(firstValue, secondValue);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        public void DivideTest(int firstValue, int secondValue, int expected)
        {
            // Arrange
            IMathService math = new MathService();

            // Act
            decimal actual = math.Divide(firstValue, secondValue);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideTest_ThrowsException()
        {
            // Arrange
            IMathService math = new MathService();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => math.Divide(10, 0));
        }
    }
}