using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc.Model;

namespace Calc.ViewModel
{
    internal class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _numberDisplay;
        private double _inputNumber;
        private string _operation;
        private bool _readyNumber;
        private double _secondNumber;
        Calculator calModel;

        public string NumberDisplay
        {
            get { return _numberDisplay; }
            set
            {
                _numberDisplay = value;
                OnPropertyChanged();
            }
        }

        public CalculatorViewModel()
        {
            NumberDisplay = "0";
            _readyNumber = true;
            calModel = new Calculator();
        }

        public void NumberPressed(string number)
        {
            if (_readyNumber || NumberDisplay == "0")
            {
                NumberDisplay = number;
                _readyNumber = false;
            }
            else
            {
                NumberDisplay += number;
            }
        }

        public void OperationPressed(string operation)
        {
            _inputNumber = double.Parse(NumberDisplay);
            _operation = operation;
            _readyNumber = true;
        }

        public void EqualsPressed()
        {
            try
            {
                if(!_readyNumber)
                {
                    _secondNumber = double.Parse(NumberDisplay);
                }

                double result = 0;
                switch (_operation)
                {
                    case "＋":
                        result = calModel.Add(_inputNumber, _secondNumber);
                        break;
                    case "－":
                        result = calModel.Subtract(_inputNumber, _secondNumber);
                        break;
                    case "×":
                        result = calModel.Multiply(_inputNumber, _secondNumber);
                        break;
                    case "÷":
                        result = calModel.Divide(_inputNumber, _secondNumber);
                        break;
                    case null:
                        result = double.Parse(NumberDisplay);
                        break;
                }
                NumberDisplay = result.ToString();
                _inputNumber = result;
                _readyNumber = true;
            }
            catch (Exception ex) 
            {
                    Console.WriteLine(ex.Message);
            }

        }

        public void ClearPressed()
        {
            NumberDisplay = "0";
            _inputNumber = 0;
            _operation = null;
            _readyNumber = true;
        }

        public void DecimalPressed()
        {
            if (_readyNumber)
            {
                NumberDisplay = "0.";
                _readyNumber = false;
            }
            else if (!NumberDisplay.Contains("."))
            {
                NumberDisplay += ".";
            }
        }

        public void ClearEntryPressed()
        {
            NumberDisplay = "0";
            _readyNumber = true;
        }

        public void BackspacePressed()
        {
            if (NumberDisplay == "0" || NumberDisplay.Length == 1)
            {
                NumberDisplay = "0";
                _readyNumber = true;
            }
            else if (NumberDisplay.Length == 2 && NumberDisplay.Contains("-"))
            {
                NumberDisplay = "0";
                _readyNumber = true;
            }
            else
            {
                NumberDisplay = NumberDisplay.Substring(0, NumberDisplay.Length - 1);
            }

        }

        public void PlusMinusPressed()
        {
            if (NumberDisplay == "0")
            {
                return;
            }

            if (NumberDisplay.Contains('-'))
            {
                NumberDisplay = NumberDisplay.Substring(1);
            }
            else
            {
                NumberDisplay = "-" + NumberDisplay;
            }
        }
        public void PowPressed()
        {
            if (NumberDisplay == "0")
            {
                return;
            }
            double parseNumber = double.Parse(NumberDisplay);
            parseNumber *= parseNumber;
            NumberDisplay = parseNumber.ToString();
            _readyNumber = true;
        }
        public void RootPressed()
        {
            double parseNumber = double.Parse(NumberDisplay);
            if(parseNumber < 0)
            {
                NumberDisplay = "음수는 불가합니다.";
                _readyNumber = true;
                return;
            }
            NumberDisplay = Math.Sqrt(parseNumber).ToString();
            _readyNumber = true;

        }
        public void PercentPressed()
        {
            if (_inputNumber==0)
            {
                NumberDisplay = "첫번째 값이 0이면 불가합니다.";
                _readyNumber = true;
                return;
            }
            switch(_operation)
            {
                case "＋" or "－":
                    NumberDisplay = (_inputNumber*double.Parse(NumberDisplay)/100).ToString();
                    break;
                case "×" or "÷":
                    NumberDisplay = (double.Parse(NumberDisplay)/100).ToString(); 
                    break;
            }
        }
        public void RecipPressed()
        {
            NumberDisplay = (1/double.Parse(NumberDisplay)).ToString();
            _readyNumber = true;
        }

    }

    
}
