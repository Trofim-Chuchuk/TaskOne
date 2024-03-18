using System;
using System.Windows.Input;

namespace TaskOne.Commands.Generic; 

public class RelayCommand:ICommand {
    private Action commandTask;
    private Func<object, bool> canExecute;
    public RelayCommand(Action commandTask,Func<object, bool> canExecute=null){
        this.commandTask = commandTask;
        this.canExecute = canExecute;
    }
    public bool CanExecute(object? parameter)=>canExecute == null || canExecute(parameter);

    public void Execute(object? parameter)=>commandTask.Invoke();

    public event EventHandler? CanExecuteChanged;
}