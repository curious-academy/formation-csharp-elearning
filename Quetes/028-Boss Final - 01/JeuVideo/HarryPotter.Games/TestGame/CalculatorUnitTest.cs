using Computers;

namespace TestGame
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void DevraitObtenir2AvecDivision6Et3()
        {
            // Arrange
            float result = 0;
            Calculateur calc = new();

            // Act
            result = calc.Calculer(6, 3);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void DevraitPlanterDivisionParZero()
        {
            // Arrange
            float result = 0;
            Calculateur calc = new();

            // Assert
            Assert.Throws<DivideByZeroException>(() =>
            {
                calc.Calculer(6, 0);
            });
        }
    }
}