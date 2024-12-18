using System;
using UnityEngine;

public class ScreenshotInGame : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ScreenCapture.CaptureScreenshot("Screenshot" + DateTime.Now.ToString("yyyy-MM-dd-mm-ss") + ".png", 4);
        }
    }
}