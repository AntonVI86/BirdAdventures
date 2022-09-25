using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonCreator : MonoBehaviour
{
    [SerializeField] private LevelButton _prefabLevelButton;
    [SerializeField] private List<Level> _levels;
    [SerializeField] private PlayerAbilities _abilities;

    private List<LevelButton> _levelButtons = new List<LevelButton>();

    private const string _pathName = "Levels";

    private void Awake()
    {
        GetAllLevels();

        for (int i = 0; i < _levels.Count; i++)
        {
            if(i != 0)
            {
                _levels[i].ResetButton();
            }

            LevelButton newButton = Instantiate(_prefabLevelButton, transform);
            _levelButtons.Add(newButton);
            
        }

        GetLevelStarsCount();
    }

    private void Start()
    {
        SetBlockingLevel();
        ConfigureLevelButtons();
    }

    private void GetAllLevels()
    {
        Object[] objects = Resources.LoadAll(_pathName, typeof(Level));

        foreach (var element in objects)
        {
            Level level = (Level)element;
            _levels.Add(level);
        }
    }

    private void GetLevelStarsCount()
    {
        int stars = 0;
        int temp = PlayerPrefs.GetInt("SpendStars");

        foreach (var level in _levels)
        {
            stars += PlayerPrefs.GetInt("EarnedStars" + level.LoadingName);
        }

        stars -= temp;
        _abilities.AddStars(stars);
    }

    private void SetBlockingLevel()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            if (PlayerPrefs.GetInt("EarnedStars" + _levels[i].LoadingName) > 0)
            {
                if (i != _levels.Count - 1)
                    _levels[i + 1].UnlockLevel();
            }
        }
    }

    private void ConfigureLevelButtons()
    {
        for (int i = 0; i < _levelButtons.Count; i++)
        {
            _levelButtons[i].SetLevel(_levels[i]);
            _levelButtons[i].SaveReceivedStarsValue();
            _levelButtons[i].ActivateStars();

            if (_levels[i].IsUnlocked)
            {
                _levelButtons[i].SetName(i + 1);
            }
        }
    }
}
