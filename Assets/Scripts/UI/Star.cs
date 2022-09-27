using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Star : MonoBehaviour
{
    private Image _star;
    private float _duration = 1f;

    private void Awake()
    {
        _star = GetComponent<Image>();

        _star.rectTransform.DOScale(1f, _duration);
    }
}
