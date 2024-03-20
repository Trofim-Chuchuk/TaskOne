using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using TaskOne.Commands.Generic;
using TaskOne.Services.Interface;
using TaskOne.Views;

namespace TaskOne.ViewModels;
public class MainViewModel:ViewModelBase {
    #region Поля

    private string textFromFolder;
    private int numberOfLetters;
    
    private readonly IOpenFile openFile; 
    private readonly ISaveFile saveFile;
    private readonly IChangeFile changeFile; 
    
    #endregion

    #region Конструктор
    public MainViewModel(IOpenFile openFile,ISaveFile saveFile,IChangeFile changeFile){
        this.openFile = openFile;
        this.saveFile = saveFile;
        this.changeFile = changeFile;
        
        OpenTxt=new RelayCommand((()=>{ TextFromFolder=openFile.SelectFile(); }));
        RemoveLetter=new RelayCommand((()=>{
            if ( NumberOfLetters > 0) {
                TextFromFolder=changeFile.RemoveLetter(TextFromFolder,NumberOfLetters);
                NumberOfLetters = 0;
            }
        }));
        RemoveSigns = new RelayCommand(()=> {
            TextFromFolder = changeFile.RemoveSigns(TextFromFolder);
        });
        SaveTxt=new RelayCommand((()=> saveFile.SaveTxtFile(TextFromFolder)));
        ClearFile = new RelayCommand((()=>TextFromFolder = ""));
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
    
    public ICommand RemoveSigns { get; }
    #endregion
}