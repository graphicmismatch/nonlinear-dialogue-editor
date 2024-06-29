using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float dragtime = 0.1f;
    public static ScrollRect sr;

    private void Awake()
    {
        sr = FindFirstObjectByType<ScrollRect>();
    }
}