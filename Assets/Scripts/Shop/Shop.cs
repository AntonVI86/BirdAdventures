using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Ability> _abilities;
    [SerializeField] private AbilityView _viewTemplate;
    [SerializeField] private PlayerAbilities _player;
    [SerializeField] private Transform _container;
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private AudioClip _errorSound;
    [SerializeField] private AudioClip _upgradeSound;

    private void Awake()
    {
        GetAbilities();
        CreateAbilities();
    }

    private void GetAbilities()
    {
        Object[] objects = Resources.LoadAll("Abilities", typeof(Ability));

        for (int i = 0; i < objects.Length; i++)
        {
            Ability newAbility = (Ability)objects[i];
            _abilities.Add(newAbility);
        }
    }

    private void CreateAbilities()
    {
        for (int i = 0; i < _abilities.Count; i++)
        {
            AbilityView newView = Instantiate(_viewTemplate, _container);

            newView.SellButtonClick += OnSellButtonClick;
            _abilities[i].ShowLevel();
            newView.ShowUpgradeLevel(_abilities[i]);
            newView.ShowInfo(_abilities[i]);
        }
    }

    private void OnSellButtonClick(Ability ability, AbilityView view)
    {
        TrySellAbility(ability, view);
    }

    private void TrySellAbility(Ability ability, AbilityView view)
    {
        if(_player.Stars >= ability.Cost)
        {
            if(ability.CurrentValue < ability.LimitValue)
            {
                _player.ImproveAbility(ability.AbilityName, ability.StepAddition);
                _player.SpendStars(ability.Cost);
                ability.AddLevel();
                view.DisplayUpgradeLine();
                _audioPlayer.PlaySound(_upgradeSound);
            }
            else
            {
                view.SellButtonClick -= OnSellButtonClick;
                _audioPlayer.PlaySound(_errorSound);
            }
        }
        else
        {
            _audioPlayer.PlaySound(_errorSound);
        }
    }
}
