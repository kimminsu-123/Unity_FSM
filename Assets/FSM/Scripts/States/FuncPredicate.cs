using System;
using FSM.Interfaces;

namespace FSM.States
{
    public class FuncPredicate : IPredicate
    {
        private readonly Func<bool> _condition;

        public FuncPredicate(Func<bool> condition)
        {
            _condition = condition;
        }

        public bool Evaluate() => _condition(); 
    }
}