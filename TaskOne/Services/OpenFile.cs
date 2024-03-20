using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using TaskOne.Services.Interface;

namespace TaskOne.Services; 

public class OpenFile:IOpenFile {
   public string SelectFile(){
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Фильтр для текстовых файлов
        if (openFileDialog.ShowDialog() == true)
        {
            string selectedFilePath = openFileDialog.FileName;
            MessageBox.Show($"Выбран файл: {selectedFilePath}");
            
            try
            {
                string fileContent = File.ReadAllText(selectedFilePath);
                return  fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        return "";
   }
}