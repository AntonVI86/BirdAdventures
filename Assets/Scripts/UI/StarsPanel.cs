using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarsPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextSceneButton;
    [SerializeField] private Level _level;
    [SerializeField] private GameObject[] _stars;

    private int _earnedLevelStars = 0;

    private const string _mapSceneName = "Map";

    private void OnEnable()
    {
        _level.CountStars(PlayerPrefs.GetInt("Score"));
        _earnedLevelStars = PlayerPrefs.GetInt("CurrentStars" + _level.LoadingName);
        StartCoroutine(ActivateStars());
        _restartButton.onClick.AddListener(OnRestartScene);
        _nextSceneButton.onClick.AddListener(OnNextScene);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartScene);
        _nextSceneButton.onClick.RemoveListener(OnNextScene);
    }

    private void OnRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnNextScene()
    {
        SceneManager.LoadScene(_mapSceneName);
    }

    private IEnumerator ActivateStars()
    {
        float time = 0.5f;
        var delay = new WaitForSeconds(time);

        for (int i = 0; i < _earnedLevelStars; i++)
        {
            _stars[i].SetActive(true);
            yield return delay;
        }
    }
}
