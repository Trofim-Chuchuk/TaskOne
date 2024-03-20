using TaskOne.Services;
namespace TaskOneTest;

public class UnitTest1 {

   private readonly ChangeFile _changeFile;
   
   public UnitTest1()
   {
       _changeFile = new ChangeFile();
   }

   [Theory]
   [InlineData("Hello world!", 6, "!")]
   [InlineData("Hello world!", 5, "Hello world !")]
   [InlineData("This is a test", 3, "This test")]
   [InlineData("One", 2, "One")]
   [InlineData("", 5, " ")]
   [InlineData("Test", 0, "Test")]
   public void RemoveLetter_RemovesWordsShorterThanGivenLength(string input, int minWordLength, string expected)
   {
       // Arrange

       // Act
       var result = _changeFile.RemoveLetter(input, minWordLength);

       // Assert
       Assert.Equal(expected, result);
   }
   
   [Fact]
   public void RemoveLetter_NullInput_ReturnsEmptyString()
   {
       // Arrange
       string input = null;

       // Act
       var result = _changeFile.RemoveLetter(input, 5);

       // Assert
       Assert.Equal(" ", result);
   }
   
}