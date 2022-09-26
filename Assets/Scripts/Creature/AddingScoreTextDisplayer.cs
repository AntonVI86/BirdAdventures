using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class AddingScoreTextDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private RectTransform _textPosition;
    private Color _textColorAlpha;

    private void Awake()
    {
        _scoreText.gameObject.SetActive(false);

        _textColorAlpha = _scoreText.color;
        _textPosition = _scoreText.rectTransform;
    }

    private void OnDisable()
    {
        _scoreText.color = _textColorAlpha;
        _scoreText.rectTransform.position = _textPosition.position;
    }

    public void AnimateDisplayScoreText(int reward)
    {
        float distance = 0.3f;
        float lifeTime = 1f;

        _scoreText.gameObject.SetActive(true);
        _scoreText.text = $"+ {reward}";
        _scoreText.transform.DOMoveY(distance, lifeTime).OnComplete(() => _scoreText.transform.DOMoveY(-distance, 0));
        _scoreText.DOFade(0, lifeTime).OnComplete(() => _scoreText.gameObject.SetActive(false));
        ResetScoreText();
    }

    private void ResetScoreText()
    {
        _scoreText.rectTransform.anchoredPosition = new Vector2(0, 0);
    }
}
