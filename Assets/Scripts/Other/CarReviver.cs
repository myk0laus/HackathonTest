using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CarReviver : MonoBehaviour
{
    [SerializeField] private Button _rewardedAdButton;
    [SerializeField] private MeshRenderer[] _blinksMeshes;
    [SerializeField] private Collider[] _obstacles;
    [SerializeField] private Collider[] _carColliders;
    [SerializeField] private CollisionHandler _vehicleCollisionHandler;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CanvasGroup _loseGroup;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private float _blinkingTime;
    [SerializeField] private int _maxBlinkCount; 
    private int _currentBlinkCount = 0;

    public void ReviveProcess()
    {
        DisableObstacleColliders();
        Time.timeScale = 1.0f;
        DisableLosePanel();
        SetCarOnRoad();
        EnablePauseButton();
        StartCoroutine(nameof(BlinkMeshes));
        Music.Instance.ResumeMusic();
    }

    private void SetCarOnRoad()
    {
        _vehicleCollisionHandler.transform.position = new Vector3(0, 0.2f, _vehicleCollisionHandler.transform.position.z);
        _vehicleCollisionHandler.transform.rotation = Quaternion.Euler(0, 0, 0);

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    private IEnumerator BlinkMeshes()
    {
        while (_currentBlinkCount < _maxBlinkCount)
        {
            _currentBlinkCount++;
            DisableMeshes();
            yield return new WaitForSeconds(_blinkingTime);
            EnableMeshes();
            yield return new WaitForSeconds(_blinkingTime);
        }

        ActivateLosePanel();
        EnableObstacleColliders();
        _vehicleCollisionHandler.enabled = true;
        _vehicleCollisionHandler.Collided = false;
    }

    private void DisableLosePanel()
    {
        _loseGroup.alpha = 0f;
        _loseGroup.interactable = false;
        _loseGroup.blocksRaycasts = false;
    }

    private void ActivateLosePanel()
    {
        _loseGroup.GetComponent<LosePanel>().MakeSubscription();
    }

    private void DisableObstacleColliders()
    {
        foreach (Collider obstacle in _obstacles)
            obstacle.enabled = false;
    }

    private void EnableObstacleColliders()
    {
        foreach (Collider obstacle in _obstacles)
            obstacle.enabled = true;
    }

    private void EnablePauseButton()
    {
        _pauseButton.interactable = true;
    }

    private void EnableMeshes()
    {
        foreach (MeshRenderer renderer in _blinksMeshes)
            renderer.enabled = true;
    }

    private void DisableMeshes()
    {
        foreach (MeshRenderer renderer in _blinksMeshes)
            renderer.enabled = false;
    }
}