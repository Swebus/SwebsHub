using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core;
using System.Windows.Input;
using System.ComponentModel;

namespace MyApp.MVVM.ViewModel
{
    public class ViewTwoModel : INotifyPropertyChanged
    {
        public ICommand CalculateCommand { get; }
        public ICommand SetOperatorCommand { get; }
        public ViewTwoModel()
        {
            SetOperatorCommand = new RelayCommand(SetOperator);
            CalculateCommand = new RelayCommand(_ => Calculate());
        }

        private string _operator;
        public string Operator
        {
            get => _operator;
            set
            {
                _operator = value;
                OnPropertyChanged(nameof(Operator));
            }
        }

        

        private void SetOperator(object parameter)
        {
            if (parameter is string op)
            {
                Operator = op;
            }
        }

        //=======================================================\\

        private string _firstNumber;
        public string FirstNumber
        {
            get => _firstNumber;
            set
            {
                _firstNumber = value;
                OnPropertyChanged(nameof(FirstNumber));
            }
        }

        //=======================================================\\

        private string _secondNumber;
        public string SecondNumber
        {
            get => _secondNumber;
            set
            {
                _secondNumber = value;
                OnPropertyChanged(nameof(SecondNumber));
            }
        }

        //========================================================\\

        private string _resultText;
        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged(nameof(ResultText));
            }
        }

        //========================================================\\

        private void Calculate()
        {
            //if (int.TryParse(FirstNumber, out int num1) && int.TryParse(SecondNumber, out int num2))
            //{
            //    ResultText = $"Result: {num1 + num2}";
            //}
            //else
            //{
            //    ResultText = "Invalid input. Please enter numbers.";
            //}
            if (int.TryParse(FirstNumber, out int num1) && int.TryParse(SecondNumber, out int num2))
            {
                if (Operator != null)
                {
                    if (Operator == "+")
                    {
                        ResultText = $"Result: {num1 + num2}";
                    }
                    else if (Operator == "-")
                    {
                        ResultText = $"Result: {num1 - num2}";
                    }
                    else if (Operator == "*")
                    {
                        ResultText = $"Result: {num1 * num2}";
                    }
                    else if (Operator == "/")
                    {
                        float result = (float)num1 / num2;
                        ResultText = $"Result: {result}";
                    }

                    }
            }
        }

        //========================================================\\

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
