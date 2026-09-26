using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

public enum ETransition
{
    Angry,
    Hmm,
    Fade
}

public class TransitionManager : Singleton<TransitionManager>
{
    [OdinSerialize] private Dictionary<ETransition, Animator> animatorTransition = new Dictionary<ETransition, Animator>();

    public void StartTransition(ETransition transitionType)
    {
        animatorTransition[transitionType].gameObject.SetActive(true);
        animatorTransition[transitionType].SetTrigger("Start");
    }

    public void EndTransition(ETransition transitionType)
    {
        animatorTransition[transitionType].SetTrigger("End");
    }
}