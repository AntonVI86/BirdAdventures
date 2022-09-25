using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuTransition : MonoBehaviour
{
    [SerializeField] private Button _toMainMenu;

    private const string _mainMenuName = "MainMenu";

    private void OnEnable()
    {
        _toMainMenu.onClick.AddListener(OnToMainMenu);
    }

    private void OnDisable()
    {
        _toMainMenu.onClick.RemoveListener(OnToMainMenu);
    }

    private void OnToMainMenu()
    {
        SceneManager.LoadScene(_mainMenuName);
    }
}
