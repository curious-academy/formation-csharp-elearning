using HarryPotter.Games.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class PlayerUnitTest
    {
        [Fact]
        public void DevraitEnlever50AUnEnnemi()
        {
            // Arrange
            Player player = new("HP", Console.WriteLine);
            Ennemi ennemi = new("Voldemort");

            // Act
            player.Attaquer(ennemi);

            // Assert
            Assert.Equal(Ennemi.DEFAULT_POINTS_DE_VIE - 50, ennemi.PointsDeVie);
        }

        [Fact]
        public void DevraitTuerEnnemi()
        {
            // Arrange
            Player player = new("HP", Console.WriteLine);
            Ennemi ennemi = new("Voldemort");

            // Act
            ennemi.EstMort += character =>
            {
                Assert.IsType<Ennemi>(character);
            };

            player.Attaquer(ennemi);
            player.Attaquer(ennemi);

            // Assert
            Assert.Equal(0, ennemi.PointsDeVie);
        }
    }
}
