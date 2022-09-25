using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelName : MonoBehaviour
{
    [SerializeField] private Level _level;
    private Text _name;
    private float _timeToFade = 2;

    private void Awake()
    {
        _name = GetComponent<Text>();       
    }

    private void Start()
    {
        _name.text = _level.Name;
        Invoke("Fade", _timeToFade);
    }

    private void Fade()
    {
        _name.DOFade(0, _timeToFade);
    }
}
