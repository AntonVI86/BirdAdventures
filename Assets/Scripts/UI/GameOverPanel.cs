using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _denyButton;

    private const string _mapSceneName = "Map";

    private void OnEnable()
    {
        _acceptButton.onClick.AddListener(OnRestartScene);
        _denyButton.onClick.AddListener(OnDeniedButtonClick);
    }

    private void OnDisable()
    {
        _acceptButton.onClick.RemoveListener(OnRestartScene);
        _denyButton.onClick.RemoveListener(OnDeniedButtonClick);
    }

    private void OnRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDeniedButtonClick()
    {
        SceneManager.LoadScene(_mapSceneName);
    }
}
