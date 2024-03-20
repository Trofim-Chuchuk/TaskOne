using TaskOne.Services;
namespace TaskOneTest;

public class ChangeFileTest {

   private readonly ChangeFile _changeFile;
   
   public ChangeFileTest()
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
   
   [Theory]
   [InlineData("Hello world!",  "Hello world")]
   [InlineData("This, is, a, test,",  "This is a test")]
   [InlineData("One",  "One")]
   [InlineData("",  "")]
   [InlineData("Test,,,,",  "Test")]
   public void RemoveSings(string input, string expected)
   {
       // Arrange

       // Act
       var result = _changeFile.RemoveSigns(input);
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
   [Fact]
   public void RemoveLetter_NullInput_NullValue()
   {
       // Arrange
       string input = null;
       int value = 0;

       // Act
       var result = _changeFile.RemoveLetter(input, value);

       // Assert
       Assert.Equal(" ", result);
   }
   
}