using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _abilityLevel;
    [SerializeField] private Button _sellButton;

    [SerializeField] private Transform _container;

    private Ability _ability;

    public event UnityAction<Ability, AbilityView> SellButtonClick;

    public Button SellButton => _sellButton;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void ShowInfo(Ability ability)
    {
        _ability = ability;
        _label.text = ability.Name;
        _icon.sprite = ability.Icon;
        _cost.text = ability.Cost.ToString();
    }

    public void ShowUpgradeLevel(Ability ability)
    {
        for (int i = 1; i <= ability.CurrentValue; i++)
        {
            Instantiate(_abilityLevel, _container);
        }
    }

    public void DisplayUpgradeLine()
    {
        Instantiate(_abilityLevel, _container);
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_ability, this);
    }
}
