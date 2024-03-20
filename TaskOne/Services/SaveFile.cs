using System.IO;
using System.Windows;
using Microsoft.Win32;
using TaskOne.Services.Interface;

namespace TaskOne.Services; 

public class SaveFile:ISaveFile  {
    public void SaveTxtFile(string textFromFolder){
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

        if (saveFileDialog.ShowDialog() == true) {
            string filePath = saveFileDialog.FileName;

            // Получаем текст, который нужно сохранить
            string textToSave = textFromFolder;

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
}