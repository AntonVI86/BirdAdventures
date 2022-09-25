using TMPro;
using UnityEngine;

public class PlayerStars : MonoBehaviour
{
    [SerializeField] private TMP_Text _starsText;
    [SerializeField] private PlayerAbilities _player;

    private void OnEnable()
    {
        _player.StarsValueChanged += OnDisplayStarsCount;
    }

    private void OnDisable()
    {
        _player.StarsValueChanged -= OnDisplayStarsCount;
    }

    public void OnDisplayStarsCount(int stars)
    {
        _starsText.text = $"{stars}";
    }
}
