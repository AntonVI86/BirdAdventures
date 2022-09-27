using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))] 
public class FullnessDisplay : MonoBehaviour
{
    [SerializeField] private BirdAttacker _bird;
    [SerializeField] private Slider _fullnessBar;
    [SerializeField] private TMP_Text _fullnessText;
    [SerializeField] private PlayerAbilities _abilities;

    private float _fillSpeed = 15;

    private void Start()
    {
        _fullnessBar.maxValue = _abilities.MaxFulness;
        _fullnessBar.value = _fullnessBar.maxValue;
        _fullnessText.text = $"{_bird.CurrentFullness} / {_abilities.MaxFulness}";
    }

    private void OnEnable()
    {
        _bird.FullnessChanged += OnChangedFullness;
    }

    private void OnDisable()
    {
        _bird.FullnessChanged -= OnChangedFullness;
    }

    private void OnChangedFullness(float value)
    {
        StartCoroutine(ChangeValue());
        _fullnessText.text = $"{_bird.CurrentFullness} / {_abilities.MaxFulness}";
    }

    private IEnumerator ChangeValue()
    {
        while (_fullnessBar.value != _bird.CurrentFullness)
        {
            _fullnessBar.value = Mathf.MoveTowards(_fullnessBar.value, _bird.CurrentFullness, _fillSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
