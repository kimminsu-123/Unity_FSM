using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AnimationDataSO", menuName = "FSM/Animation Data", order = 1)]
    public class AnimationDataSO : ScriptableObject
    {
        [SerializeField] private string animationName;
        [SerializeField] private float fadeTime;
        [SerializeField] private int layer;

        public string AnimationName => animationName;
        public float FadeTime => fadeTime;
        public int Layer => layer;
    }
}