using System;
using System.ComponentModel;
using System.Windows.Input;
using MinimalMVVM.ViewModel;
using StudentInfoSystem.Model;
using StudentInfoSystem.View;

namespace StudentInfoSystem.ViewModel
{
    public class StudentPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public StudentPresenter()
        {
            Student = new Student();
        }

        public Student Student { get; set; }

        public ICommand LoginCommand => new DelegateCommand(Login);
        
        private void Login()
        {
            new LoginDialog(student =>
            {
                Student = student;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Student"));
            }).ShowDialog();
        }
    }
}