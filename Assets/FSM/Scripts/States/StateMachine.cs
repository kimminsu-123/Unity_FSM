using System;
using System.Collections.Generic;
using FSM.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using IState = FSM.Interfaces.IState;

namespace FSM.States
{
    public class StateMachine : MonoBehaviour
    {
        private StateNode _currentState;
        private Dictionary<IState, StateNode> _nodes = new();
        private HashSet<ITransition> _anyTransitions = new();

        private void Update()
        {
            var transition = GetTransition();
            if(transition != null)
                ChangeState(transition.To);
            
            _currentState?.State?.OnUpdate();
        }

        private void FixedUpdate()
        {
            _currentState?.State?.OnFixedUpdate();
        }
        
        public void AddTransition(IState from, IState to, IPredicate condition) => GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        public void AddAnyTransition(IState to, IPredicate condition) => _anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));

        public void SetState(IState state)
        {
            _currentState = _nodes[state];
            _currentState?.State?.OnEnter();
        }

        public void ChangeState(IState state)
        {
            if (state == _currentState.State) return;

            var prevState = _currentState.State;
            var nextState = _nodes[state].State;
            
            prevState?.OnExit();
            nextState?.OnEnter();

            _currentState = _nodes[state];
        }

        private ITransition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition.Evaluate())
                    return transition;
            
            foreach (var transition in _currentState.Transitions)
                if (transition.Condition.Evaluate())
                    return transition;
            
            return null;
        }

        private StateNode GetOrAddNode(IState state)
        {
            var node = _nodes.GetValueOrDefault(state);
            
            if (node == null) {
                node = new StateNode(state);
                _nodes.Add(state, node);
            }
            
            return node;
        }

        private class StateNode
        {
            public IState State { get; }
            public HashSet<ITransition> Transitions { get; }

            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<ITransition>();
            }

            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(new Transition(to, condition));
            }
        }
    }
}