using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34,996237, -85.291147, Taco Bell Chattanooga...", -85.291147)]
        [InlineData("33.958057, -84.133918, Taco Bell Duluth...", -84.133918)]
        [InlineData("30.4784669, -87.206052, Taco Bell Pensacola...", -87.206052)]
        [InlineData("31.447495, -85.657311, Taco Bell Ozar...", -85.657311)]
        [InlineData("34.113051, -84.56005, Taco Bell Woodstoc...", -84.56005)]

    //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        
        //TODO: Create a test called ShouldParseLatitude
        
        [Theory]
        [InlineData("31.597099, -84.176122, Taco Bell Albany...", 31.597099)]
        [InlineData("32.524378, -84.88839, Taco Bell Columbus...", 32.524378)]
        [InlineData("33.283584, -86.855317, Taco Bell Helena...", 33.283584)]
        [InlineData("34.752697, -86.747007, Taco Bell Madiso...", 34.752697)]
        [InlineData("31.447495, -85.657311, Taco Bell Ozar...", 31.447495)]
        [InlineData("33.933808, -85.610591, Taco Bell Piedmont...", 33.933808)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line);
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
