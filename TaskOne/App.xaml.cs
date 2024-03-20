using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskOne.Services;
using TaskOne.Services.Interface;
using TaskOne.ViewModels;
using TaskOne.Views;

namespace TaskOne {
   
    public partial class App : Application {
        private readonly IServiceCollection services = new ServiceCollection();
        private readonly IServiceProvider serviceProvider;

        public App(){
            services.AddSingleton<MainWindow>((provider)=>new MainWindow(){
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            
            services.AddSingleton<IOpenFile,OpenFile>();
            services.AddSingleton<ISaveFile,SaveFile>();
            services.AddSingleton<IChangeFile,ChangeFile>();
            
            serviceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e){
           var mainView=serviceProvider.GetRequiredService<MainWindow>();
           mainView.Show();
           base.OnStartup(e);
        }
    }
}