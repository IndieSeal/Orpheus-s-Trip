using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public static class Utilities
{
    public static T GetRandomOf<T>(this List<T> myList)
    {
        if (myList.Count == 0) return default;

        return myList[myList.GetRandomIndexOf()];
    }
    public static int GetRandomIndexOf<T>(this List<T> myList) => Random.Range(0, myList.Count);

    public static Vector2 GetRandomPoint(Vector2 start, Vector2 end) => new Vector2(Random.Range(start.x, end.x), Random.Range(start.y, end.y));
    public static void PlayVaried(this AudioSource audioSource, float min = 0.8f, float max = 1.2f)
    {
        audioSource.pitch = Random.Range(min, max);
        audioSource.Play();
    }
}