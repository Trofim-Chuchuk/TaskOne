using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using TaskOne.Commands.Generic;
using TaskOne.Views;

namespace TaskOne.ViewModels;
public class MainWindowViewModel:ViewModelBase {
    #region Поля

    private string textFromFolder;
    private int numberOfLetters;

    #endregion

    #region Конструктор
    public MainWindowViewModel(){
        
        OpenTxt=new RelayCommand(SelectFileButton);
        RemoveLetter=new RelayCommand((()=>{
            RemoveSigns();
            if ( NumberOfLetters > 0) {
                ChangeFile();
            }
        }));
        SaveTxt=new RelayCommand(SaveButton);
        ClearFile = new RelayCommand((()=>TextFromFolder = ""));
    }

    #endregion

    #region Методы
    /// <summary>
    /// Выбор текстового документа.
    /// </summary>
    private void SelectFileButton(){
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Фильтр для текстовых файлов
        if (openFileDialog.ShowDialog() == true)
        {
            string selectedFilePath = openFileDialog.FileName;
            MessageBox.Show($"Выбран файл: {selectedFilePath}");
            
            try
            {
                string fileContent = File.ReadAllText(selectedFilePath);
                TextFromFolder = fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
    
    /// <summary>
    /// Сохранение текстового файла.
    /// </summary>
    private void SaveButton(){
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

        if (saveFileDialog.ShowDialog() == true) {
            string filePath = saveFileDialog.FileName;

            // Получаем текст, который нужно сохранить
            string textToSave = TextFromFolder;

            // Записываем текст в файл
            try
            {
                File.WriteAllText(filePath, textToSave);
                MessageBox.Show("Файл успешно сохранен.", "Успех");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка");
            }
        }
    }

    /// <summary>
    /// Убирание слов менее какой-то длины.
    /// </summary>
    private void ChangeFile(){
        if (TextFromFolder.Length > 0) {
            string[] words = TextFromFolder.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            // Создаем объект StringBuilder для построения результирующей строки
            StringBuilder result = new StringBuilder();
            
            // Проходимся по каждому слову
            foreach (string word in words) {
                // Если длина слова больше или равна минимальной длине, добавляем его к результирующей строке
                if (word.Length >= NumberOfLetters) {
                    result.Append(word);
                    result.Append(' '); // Добавляем пробел между словами
                }
            }

            // Возвращаем результирующую строку без последнего лишнего пробела
            TextFromFolder = result.ToString().TrimEnd();
            NumberOfLetters = 0;
        }
        else if ( TextFromFolder==null) {
            MessageBox.Show("Пустой документ");
        }
    }
    

    /// <summary>
    /// Убрать знаки припинания.
    /// </summary>
    private void RemoveSigns(){
        string text = TextFromFolder.Replace("\r\n", " ");
        TextFromFolder =Regex.Replace(text, @"[^\w\s]", "");
    }
    
    #endregion
    
    #region Свойства
    
    public int NumberOfLetters{
        get=> numberOfLetters;
        set {
            numberOfLetters = value;
            OnPropertyChanged(nameof(NumberOfLetters));
        }
    }

    public string TextFromFolder {
        get=>textFromFolder;
        set {
            textFromFolder = value;
            OnPropertyChanged(nameof(TextFromFolder));
        }
    }
    #endregion
    
    #region Команды
    public ICommand OpenTxt { get;}
    public ICommand RemoveLetter { get;}
    public ICommand SaveTxt { get;}
    public ICommand  ClearFile { get;}
    #endregion
}