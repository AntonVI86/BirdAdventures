using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Create/Level", fileName = "new Level")]
public class Level : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _loadingName;
    [SerializeField] private int[] _scoreToStar;
    [SerializeField] private int _earnedStars;
    [SerializeField] private bool _isUnlocked;

    public string Name => _name;
    public string LoadingName => _loadingName;
    public bool IsUnlocked => _isUnlocked;

    public void CountStars(int score)
    {
        _earnedStars = 0;

        for (int i = 0; i < _scoreToStar.Length; i++)
        {
            if(score >= _scoreToStar[i])
            {
                _earnedStars++;
            }
        }

        PlayerPrefs.SetInt("CurrentStars" + _loadingName, _earnedStars);
        
        if(_earnedStars > PlayerPrefs.GetInt("EarnedStars" + _loadingName))
        {
            PlayerPrefs.SetInt("EarnedStars" + _loadingName, _earnedStars);
        }
    }

    public void SetStartMaxValueProgressBar(Slider slider)
    {
        slider.maxValue = _scoreToStar[_scoreToStar.Length-1];
    }

    public void ReachTargetScoreValue(int score, Image fill, Color[] color)
    {
        for (int i = 0; i < _scoreToStar.Length; i++)
        {
            if(score >= _scoreToStar[i])
            {
                fill.color = color[i];
            }
        }
    }

    public void UnlockLevel()
    {
        _isUnlocked = true;
    }

    public void ResetButton()
    {
        _isUnlocked = false;
    }
}
