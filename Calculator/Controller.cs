using System;
using System.Collections.Generic;


namespace Calculator
{
    delegate void MethodToExecute(string s); //Определение типа делегата.

    class Controller
    {
        #region Fields
        private Expression _expression;
        private MethodToExecute WaitMethod;
        private string historyExprression;
        #endregion

        #region Constructors
        public Controller()
        {
            _expression = new Expression();
        }
        #endregion

        #region Methods of operators
        public void AddResult(string s)
        {

            Expression.NextValue = Single.Parse(s);
            Expression.Result += Expression.NextValue;
        }

        public void SubResult(string s)
        {
            Expression.NextValue = Single.Parse(s);
            Expression.Result -= Expression.NextValue;
        }

        public void MultiplyResult(string s)
        {
            Expression.NextValue = Single.Parse(s);
            Expression.Result *= Expression.NextValue;
        }

        public void DivideResult(string s)
        {
            Expression.NextValue = Single.Parse(s);
            Expression.Result /= Expression.NextValue;
        }

        public void Result(string s)
        {
            if (WaitMethod == null)
                return;
            WaitMethod(s);
        }
        #endregion

        #region Other methods
        public void SetValue(string s, MethodToExecute method)
        {
            if (WaitMethod == null)
            {
                WaitMethod = method;
                Expression.Result = Single.Parse(s);
            }
            else
            {
                WaitMethod(s);
                WaitMethod = method;
            }
        }

        public void ResetController()
        {
            WaitMethod = null;
            Expression.ResetExpression();
            Expression.History = String.Empty;
        }
        #endregion

        #region Properties
        public Expression Expression
        {
            get => _expression;
        }
        #endregion


    }
}
