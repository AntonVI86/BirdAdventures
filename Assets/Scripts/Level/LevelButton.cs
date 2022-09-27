using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private GameObject[] _stars;

    private int _receivedStars = 0;
    private Level _level;
    private Button _currentButton;

    private void Awake()
    {
        _currentButton = GetComponent<Button>();
    }

    private void Start()
    {
        if (_level.IsUnlocked)
        {
            _currentButton.interactable = true;
        }
        else
        {
            _currentButton.interactable = false;
        }
    }

    private void OnEnable()
    {   
        _currentButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _currentButton.onClick.RemoveListener(OnButtonClick);
    }

    public void SetLevel(Level level)
    {
        _level = level;
    }

    public void SetName(int number)
    {
        _levelName.text = number.ToString();
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_level.LoadingName);
    }

    public void SaveReceivedStarsValue()
    {
        const string EarnedStarsString = "EarnedStars";
        const string ReceivedStarsString = "ReceivedStars";

        int stars = PlayerPrefs.GetInt(EarnedStarsString + _level.LoadingName);
        _receivedStars = PlayerPrefs.GetInt(ReceivedStarsString + _level.LoadingName);

        if (_receivedStars < stars)
        {
            _receivedStars = stars;

            PlayerPrefs.SetInt(ReceivedStarsString + _level.LoadingName, _receivedStars);
        }
    }

    public void ActivateStars()
    {
        for (int i = 0; i < _receivedStars; i++)
        {
            _stars[i].SetActive(true);
        }
    }
}
