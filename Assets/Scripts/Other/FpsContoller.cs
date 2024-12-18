using System;
using UnityEngine;

public class FpsContoller : MonoBehaviour
{
    [SerializeField] private TARGETFPS targetFPS;

    void Awake()
    {
        int fps = Convert.ToInt32(targetFPS);
        //Application.targetFrameRate = fps;
    }
}

public enum TARGETFPS
{
    SIXTY = 60,
    HUNDREDTWENTY = 120
}