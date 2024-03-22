using FSM.Interfaces;
using FSM.ScriptableObjects;
using UnityEngine;

namespace FSM.Demos
{
    public class IdleState : IState
    {
        public Animator Animator;
        public AnimationDataSO AnimationDataSo;
        
        public void OnEnter()
        {   
            Animator.CrossFade(AnimationDataSo.AnimationName, AnimationDataSo.FadeTime, AnimationDataSo.Layer);
            
            Debug.Log("<color=red>Enter Idle State</color>");
        }

        public void OnUpdate()
        {
            Debug.Log("<color=red>Update Idle State</color>");
        }

        public void OnFixedUpdate()
        {
            Debug.Log("<color=red>FixedUpdate Idle State</color>");
        }

        public void OnExit()
        {
            Debug.Log("<color=red>OnExit Idle State</color>");
        }
    }
}