using UnityEngine;
using UnityEngine.UI;

public class ButtonTransitioner : MonoBehaviour
{
    [SerializeField] private CanvasGroup _itsCanvasGroup;
    [SerializeField] private CanvasGroup _anotherCanvasGroup;
    [SerializeField] private Button _buttonTransitioner;
     
    private void OnEnable()
    {
        _buttonTransitioner.onClick.AddListener(MakeTransition);
    }

    private void OnDisable()
    {
        _buttonTransitioner.onClick.RemoveListener(MakeTransition);
    }

    private void MakeTransition()
    {
        EnableAnotherCanvasGroup();
        DisableItsCanvasGroup();
    }

    private void DisableItsCanvasGroup() 
    {
        _itsCanvasGroup.alpha = 0;
        _itsCanvasGroup.interactable = false;
        _itsCanvasGroup.blocksRaycasts = false;
    }    
     
    protected virtual void EnableAnotherCanvasGroup() 
    {
        _anotherCanvasGroup.alpha = 1;
        _anotherCanvasGroup.interactable = true;
        _anotherCanvasGroup.blocksRaycasts = true;
    }
}