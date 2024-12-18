using UnityEngine;

public class ClearPrefs : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Cleared");
    }
}