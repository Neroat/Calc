using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.ViewModel
{
    internal class CalculatorViewModel
    {
        private string _numberDisplay;
        private double _inputNumber;
        private string _operation;
        private bool _readyNumber;

        public CalculatorViewModel()
        {
            _numberDisplay = "0";
            _readyNumber = true;
        }

        public void NumberPressed(string number)
        {
            if (_readyNumber || _numberDisplay == "0")
            {
                _numberDisplay = number;
                _readyNumber = false;
            }
            else
            {
                _numberDisplay += number;
            }
        }

        public void OperationPressed(string operation)
        {
            
        }

        public void EqualsPressed()
        {

        }

        public void ClearPressed()
        {

        }
    }

    
}
