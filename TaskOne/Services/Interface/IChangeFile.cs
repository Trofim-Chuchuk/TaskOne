namespace TaskOne.Services.Interface; 

public interface IChangeFile {
    string RemoveLetter(string textFromFolder, int numberOfLetters);
    string RemoveSigns(string textFromFolder);
}