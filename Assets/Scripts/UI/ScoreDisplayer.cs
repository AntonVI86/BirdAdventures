using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ScoreCounter))]
public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Level _level;
    [SerializeField] private Color[] _barColor;
    [SerializeField] private Image _fillImage;

    private ScoreCounter _counter;

    private void Awake()
    {
        _counter = GetComponent<ScoreCounter>();

        _level.SetStartMaxValueProgressBar(_progressBar);
        _progressBar.value = 0;
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _level.ReachTargetScoreValue(_counter.Score, _fillImage, _barColor);
        StartCoroutine(ChangeProgressBarValue());
        _score.text = $"{score} / {_progressBar.maxValue}";
    }

    private IEnumerator ChangeProgressBarValue()
    {
        float fillSpeed = 20f;

        while (_progressBar.value != _counter.Score)
        {
            float normalizeValue = _counter.Score / _progressBar.maxValue;

            _progressBar.value = Mathf.MoveTowards(_progressBar.value, _counter.Score, fillSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
