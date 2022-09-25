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
        if (PlayerPrefs.HasKey("HorizontalSpeed"))
            _horizontalSpeed = PlayerPrefs.GetFloat("HorizontalSpeed");
        else
            _horizontalSpeed = _baseHorizontalSpeed;

        if (PlayerPrefs.HasKey("VerticalSpeed"))
            _verticalSpeed = PlayerPrefs.GetFloat("VerticalSpeed");
        else
            _verticalSpeed = _baseVerticalSpeed;

        if (PlayerPrefs.HasKey("MaxFullness"))
            _maxFullness = PlayerPrefs.GetFloat("MaxFullness");
        else
            _maxFullness = _baseMaxFullness;

        if (PlayerPrefs.HasKey("Recharge"))
            _timeBetweenShoot = PlayerPrefs.GetFloat("Recharge");
        else
            _timeBetweenShoot = _baseTimeBetweenShoot;

        if (PlayerPrefs.HasKey("Stars"))
        {
            PlayerPrefs.GetInt("Stars");
        }
        else
        {
            _stars = 0;
        }
    }

    private void SaveStats()
    {
        PlayerPrefs.SetFloat("HorizontalSpeed", _horizontalSpeed);
        PlayerPrefs.SetFloat("VerticalSpeed", _verticalSpeed);
        PlayerPrefs.SetFloat("MaxFullness", _maxFullness);
        PlayerPrefs.SetFloat("Recharge", _timeBetweenShoot);
        PlayerPrefs.SetInt("Stars", _stars);
    }

    public void AddStars(int earnedStars)
    {
        _stars += earnedStars;
        StarsValueChanged?.Invoke(_stars);
        PlayerPrefs.SetInt("Stars", _stars);
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

        _stars -= cost;
        StarsValueChanged?.Invoke(_stars);
        temp = PlayerPrefs.GetInt("SpendStars");
        temp += cost;
        PlayerPrefs.SetInt("SpendStars", temp);
    }
}
