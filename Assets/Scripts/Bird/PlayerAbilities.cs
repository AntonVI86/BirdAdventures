using UnityEngine;
using UnityEngine.Events;

public class PlayerAbilities : MonoBehaviour
{
    private float _baseHorizontalSpeed = 0.8f;
    private float _baseVerticalSpeed = 0.5f;
    private float _baseMaxFullness = 30f;
    private float _baseTimeBetweenShoot = 2f;
    private float _horizontalSpeed;
    private float _verticalSpeed;
    private float _maxFullness;
    private float _timeBetweenShoot;

    [SerializeField] private int _stars;

    public event UnityAction<int> StarsValueChanged;

    public float HorizontalSpeed => _horizontalSpeed;
    public float VerticalSpeed => _verticalSpeed;
    public float MaxFulness => _maxFullness;
    public float TimeBetweenShoot => _timeBetweenShoot;
    public int Stars => _stars;

    private const string HorizontalSpeedString = "HorizontalSpeed";
    private const string VerticalSpeedString = "VerticalSpeed";
    private const string MaxFullnessString = "MaxFullness";
    private const string RechargeString = "Recharge";
    private const string StarsString = "Stars";

    private void Awake()
    {
        LoadStats();
        SaveStats();
    }

    private void Start()
    {
        StarsValueChanged?.Invoke(_stars);
    }

    private void LoadStats()
    {
        if (PlayerPrefs.HasKey(HorizontalSpeedString))
            _horizontalSpeed = PlayerPrefs.GetFloat(HorizontalSpeedString);
        else
            _horizontalSpeed = _baseHorizontalSpeed;

        if (PlayerPrefs.HasKey(VerticalSpeedString))
            _verticalSpeed = PlayerPrefs.GetFloat(VerticalSpeedString);
        else
            _verticalSpeed = _baseVerticalSpeed;

        if (PlayerPrefs.HasKey(MaxFullnessString))
            _maxFullness = PlayerPrefs.GetFloat(MaxFullnessString);
        else
            _maxFullness = _baseMaxFullness;

        if (PlayerPrefs.HasKey(RechargeString))
            _timeBetweenShoot = PlayerPrefs.GetFloat(RechargeString);
        else
            _timeBetweenShoot = _baseTimeBetweenShoot;

        if (PlayerPrefs.HasKey(StarsString))
        {
            PlayerPrefs.GetInt(StarsString);
        }
        else
        {
            _stars = 0;
        }
    }

    private void SaveStats()
    {
        PlayerPrefs.SetFloat(HorizontalSpeedString, _horizontalSpeed);
        PlayerPrefs.SetFloat(VerticalSpeedString, _verticalSpeed);
        PlayerPrefs.SetFloat(MaxFullnessString, _maxFullness);
        PlayerPrefs.SetFloat(RechargeString, _timeBetweenShoot);
        PlayerPrefs.SetInt(StarsString, _stars);
    }

    public void AddStars(int earnedStars)
    {
        _stars += earnedStars;
        StarsValueChanged?.Invoke(_stars);
        PlayerPrefs.SetInt(StarsString, _stars);
    }

    public void ImproveAbility(string abilityName, float step)
    {
        float tempValue = PlayerPrefs.GetFloat(abilityName);
        tempValue += step;
        PlayerPrefs.SetFloat(abilityName, tempValue);
    }

    public void SpendStars(int cost)
    {
        int temp = 0;
        const string SpendStars = "SpendStars";

        _stars -= cost;
        StarsValueChanged?.Invoke(_stars);
        temp = PlayerPrefs.GetInt(SpendStars);
        temp += cost;
        PlayerPrefs.SetInt(SpendStars, temp);
    }
}
