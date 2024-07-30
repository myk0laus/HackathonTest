using UnityEngine;

public class FPSSetter : MonoBehaviour
{
    [SerializeField] private FPSOptions options;

    private void Awake()
    {
        int fps = (int)options;
        Application.targetFrameRate = fps;
    }
}

public enum FPSOptions
{
    SIXTY = 60,
    HUNDREDTWENTY = 120
}