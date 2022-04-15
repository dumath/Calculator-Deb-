using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator
{
    class Expression : INotifyPropertyChanged
    {


        #region Fields
        private float _result; //Результат операции.
        private float _nextValue; //Слудующее значение для выражения.
        private string _history;
        #endregion

        #region Properties
        public float Result
        {
            get => _result;
            set
            {
                _result = value;
                onPropertyChanged(nameof(Result));
                History = value.ToString();
            }
        }

        public float NextValue
        {
            get => _nextValue;
            set
            {
                _nextValue = value;
                onPropertyChanged(nameof(NextValue));
            }
        }

        public string History
        {
            get => _history;
            set
            {
                _history += value;
                //onPropertyChanged(nameof(History));
            }
        }
        #endregion

        #region Other
        protected virtual void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ResetExpression()
        {
            this._result = 0;
            this._nextValue = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
