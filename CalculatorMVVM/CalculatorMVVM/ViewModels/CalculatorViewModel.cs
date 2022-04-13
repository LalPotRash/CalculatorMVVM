using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Data;

namespace CalculatorMVVM.ViewModels
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Expression { get => expression; set { expression = value; OnPropertyChanged("Expression"); } }
        public string expression = "0";

        public ICommand EnterCharCommand { get; set; }
        public ICommand ClearAllCommand { get; set; }
        public ICommand CalculateCommand { get; set; }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public CalculatorViewModel()
        {
            EnterCharCommand = new Command(EnterChar);
            ClearAllCommand = new Command(ClearAll);
            CalculateCommand = new Command(Calculate);
        }

        private void EnterChar(object exp)
        {
            if (Expression == "0")
                Expression = "";

            Expression += ((Button)exp).Text;
        }

        private void ClearAll()
        {
            Expression = "";
        }

        private void Calculate()
        {
            if (Char.IsDigit(expression[expression.Length - 1]))
            {
                Expression = Convert.ToDouble(new DataTable().Compute(Expression, "")).ToString();
            }
        }
    }
}
