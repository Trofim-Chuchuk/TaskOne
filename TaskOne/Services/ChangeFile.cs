using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using TaskOne.Services.Interface;

namespace TaskOne.Services; 

public class ChangeFile:IChangeFile {
    
    /// <summary>
    /// Убирание слов менее какой-то длины.
    /// </summary>
   public string RemoveLetter(string textFromFolder,int numberOfLetters){
        
        if (textFromFolder?.Length > 0) {
            textFromFolder = textFromFolder.Replace("\r\n", " ");
            
            // Выстовляем пробелы между знаками припинания.
            textFromFolder= AddSpacesAroundPunctuation(textFromFolder);
        
            string punctuationMarks = ",.?!;:()[]{}<>-";
            string[] words = textFromFolder.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            // Создаем объект StringBuilder для построения результирующей строки
            StringBuilder result = new StringBuilder();
            
           
            foreach (string word in words) {
                
                if (word.Length >= numberOfLetters||punctuationMarks.Contains(word)) {
                    result.Append(word);
                    if (punctuationMarks.Contains(word)!=true) {
                        result.Append(' ');
                    }
                }
            }
            return textFromFolder = result.ToString().TrimEnd();
        }
        else if ( textFromFolder==null) {
            MessageBox.Show("Пустой документ");
        }
        return " ";
    }
    
    /// <summary>
    /// Убрать знаки припинания.
    /// </summary>
    public string RemoveSigns(string textFromFolder){
        string text = textFromFolder.Replace("\r\n", " ");
        return Regex.Replace(text, @"[^\w\s]", "");
    }
    
    /// <summary>
    /// Разделяет пробелом знаки припинания.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private string AddSpacesAroundPunctuation(string input)
    {
        // Строка с знаками препинания, которые нужно учитывать
        string punctuationMarks = ",.?!;:()[]{}<>-";

        // Создание объекта StringBuilder для построения результирующей строки
        StringBuilder result = new StringBuilder();

        // Проходимся по каждому символу во входной строке
        foreach (char c in input)
        {
            // Если символ - знак препинания, добавляем пробел справа и слева
            if (punctuationMarks.Contains(c))
            {
                result.Append(" ");
                result.Append(c);
                result.Append(" ");
            }
            // Иначе просто добавляем символ к результирующей строке
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}