using FSM.Interfaces;
using FSM.ScriptableObjects;
using UnityEngine;

namespace FSM.Demos
{
    public class ChaseState : IState
    {
        public Animator Animator;
        public AnimationDataSO AnimationDataSo;
        
        public void OnEnter()
        {   
            Animator.CrossFade(AnimationDataSo.AnimationName, AnimationDataSo.FadeTime, AnimationDataSo.Layer);
            Debug.Log("<color=blue>Enter Chase State</color>");
        }

        public void OnUpdate()
        {
            Debug.Log("<color=blue>Update Chase State</color>");
        }

        public void OnFixedUpdate()
        {
            Debug.Log("<color=blue>FixedUpdate Chase State</color>");
        }

        public void OnExit()
        {
            Debug.Log("<color=blue>OnExit Chase State</color>");
        }
    }
}