using FSM.Interfaces;
using FSM.ScriptableObjects;
using UnityEngine;

namespace FSM.Demos
{
    public class AttackState : IState
    {
        public Animator Animator;
        public AnimationDataSO AnimationDataSo;
        
        public void OnEnter()
        {   
            Animator.CrossFade(AnimationDataSo.AnimationName, AnimationDataSo.FadeTime, AnimationDataSo.Layer);
            Debug.Log("<color=green>Enter Attack State</color>");
        }

        public void OnUpdate()
        {
            Debug.Log("<color=green>Update Attack State</color>");
        }

        public void OnFixedUpdate()
        {
            Debug.Log("<color=green>FixedUpdate Attack State</color>");
        }

        public void OnExit()
        {
            Debug.Log("<color=green>OnExit Attack State</color>");
        }
    }
}