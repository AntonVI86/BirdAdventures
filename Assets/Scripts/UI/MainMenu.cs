using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _continue;
    [SerializeField] private Button _exit;

    private const string MapSceneName = "Map";

    private void OnEnable()
    {
        _newGame.onClick.AddListener(OnNewGame);
        _continue.onClick.AddListener(OnContinue);
        _exit.onClick.AddListener(OnExit);
    }

    private void OnDisable()
    {
        _newGame.onClick.RemoveListener(OnNewGame);
        _continue.onClick.RemoveListener(OnContinue);
        _exit.onClick.RemoveListener(OnExit);
    }

    private void OnNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(MapSceneName);
    }

    private void OnContinue()
    {
        SceneManager.LoadScene(MapSceneName);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
