using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _score;

    public int Score => _score;

    public event UnityAction<int> ScoreChanged;

    private const string ScoreString = "Score";

    private void Start()
    {
        _score = 0;
        PlayerPrefs.SetInt(ScoreString, _score);
        ScoreChanged?.Invoke(_score);
    }

    public void AddScore(int reward)
    {
        _score += reward;
        ScoreChanged?.Invoke(_score);
        PlayerPrefs.SetInt(ScoreString, _score);
    }
}
