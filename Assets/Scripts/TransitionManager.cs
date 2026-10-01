using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

public enum ETransition
{
    Angry,
    AngryRev,
    Hmm,
    Fade,
    Versus,
    BoatView,
    Shoot,
    HalfHalf,
    Win,
    Lose,
    Dishonorable
}

public class TransitionManager : Singleton<TransitionManager>
{
    [OdinSerialize] private Dictionary<ETransition, Animator> animatorTransition = new Dictionary<ETransition, Animator>();

    public void StartTransition(string transitionType)
    {
        if(Enum.TryParse(transitionType, out ETransition result)) StartTransition(result);
    }

    public void StartTransition(ETransition transitionType)
    {
        animatorTransition[transitionType].gameObject.SetActive(true);
        animatorTransition[transitionType].SetTrigger("Start");
    }

    public void EndTransition(ETransition transitionType, bool force = false, bool disableObject = false)
    {
        animatorTransition[transitionType].gameObject.SetActive(!disableObject);
        animatorTransition[transitionType].SetTrigger(!force ? "End" : "ForceEnd");

    }

    public void EndAllTransitions()
    {
        foreach(var entry in animatorTransition) entry.Value.gameObject.SetActive(false);
    }
}