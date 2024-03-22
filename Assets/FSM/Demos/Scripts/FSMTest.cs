using System;
using FSM.Interfaces;
using FSM.ScriptableObjects;
using FSM.States;
using UnityEngine;

namespace FSM.Demos
{
    [RequireComponent(typeof(StateMachine))]
    public class FSMTest : MonoBehaviour
    {
        public IState idleState;
        public IState chaseState;
        public IState attackState;

        public AnimationDataSO idleAnimationData;
        public AnimationDataSO chaseAnimationData;
        public AnimationDataSO attackAnimationData;

        private StateMachine _stateMachine;
        private Animator _animator;

        private void Awake()
        {
            _stateMachine = GetComponent<StateMachine>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            idleState = new IdleState { Animator = _animator, AnimationDataSo = idleAnimationData };
            chaseState = new ChaseState { Animator = _animator, AnimationDataSo = chaseAnimationData };
            attackState = new AttackState { Animator = _animator, AnimationDataSo = attackAnimationData };

            _stateMachine.AddTransition(idleState, chaseState, new FuncPredicate(() => Input.GetKeyDown(KeyCode.A)));
            _stateMachine.AddTransition(chaseState, idleState, new FuncPredicate(() => Input.GetKeyDown(KeyCode.S)));

            _stateMachine.AddAnyTransition(attackState, new FuncPredicate(() => Input.GetKeyDown(KeyCode.Z)));
            _stateMachine.AddTransition(attackState, idleState, new FuncPredicate(() => Input.GetKeyDown(KeyCode.X)));

            _stateMachine.SetState(idleState);
        }
    }
}