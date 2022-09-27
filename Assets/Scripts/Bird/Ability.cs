using UnityEngine;

[CreateAssetMenu(menuName = "Create/Ability", fileName = "NewAbility")]
public class Ability : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _discription;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _cost;
    [SerializeField] private int _limitValue;
    [SerializeField] private float _stepAddition;
    [SerializeField] private string _abilityName;

    private int _currentValue;

    public string Name => _name;
    public string AbilityName => _abilityName;
    public string Discription => _discription;
    public Sprite Icon => _icon;
    public int Cost => _cost;
    public int LimitValue => _limitValue;
    public int CurrentValue => _currentValue;
    public float StepAddition => _stepAddition;

    private const string AbilityLevel = "AbilityLevel";

    public void AddLevel()
    {
        ShowLevel();

        _currentValue++;
        PlayerPrefs.SetInt(AbilityLevel + _abilityName, _currentValue);
    }

    public void ShowLevel()
    {
        if (PlayerPrefs.HasKey(AbilityLevel + _abilityName))
        {
            _currentValue = PlayerPrefs.GetInt(AbilityLevel + _abilityName);
        }
    }
}
