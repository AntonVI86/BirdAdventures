using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelStateChanger : MonoBehaviour
{   
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    [SerializeField] private Image _fog;

    [SerializeField] private float _speed;

    [SerializeField] private GameObject _starsPanel;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _spawner;

    [SerializeField] private BirdAttacker _birdAttacker;
    [SerializeField] private BirdInput _birdInput;
    [SerializeField] private Bird _bird;

    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private AudioClip _visibleSound;
    [SerializeField] private AudioClip _damageSound;

    private float _timeToFade = 2f;
    private float _timeToFlyTarget = 3f;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        Time.timeScale = 1;
        _fog.gameObject.SetActive(true);
        _audioPlayer.PlaySound(_visibleSound);
        _bird.transform.DOMove(_startPoint.position, _timeToFlyTarget).OnComplete(() => { ResetObjects(true); });
        _fog.DOFade(0, _timeToFade);
    }

    private void OnEnable()
    {
        _birdAttacker.FullnessIsEmpty += OnEndLevel;
        _bird.Died += OnGameOver;
    }

    private void OnDisable()
    {
        _birdAttacker.FullnessIsEmpty -= OnEndLevel;
        _bird.Died -= OnGameOver;
    }

    public void OnEndLevel()
    {
        _audioPlayer.StopMusic();
        ResetObjects(false);
        _audioPlayer.PlaySound(_visibleSound);
        _bird.transform.DOMove(_endPoint.position, _timeToFlyTarget).OnComplete(() => { FadeIn(); });
    }

    private void OnGameOver()
    {
        float timeToFade = 0.6f;

        _audioPlayer.StopMusic();
        ResetObjects(false);
        _audioPlayer.PlaySound(_damageSound);
        _bird.Renderer.DOFade(0, timeToFade);

        _fog.DOFade(1, 1f).OnComplete(() => { _menu.SetActive(true); Time.timeScale = 0; });
    }

    private void FadeIn()
    {
        _fog.DOFade(1, _timeToFade).OnComplete(() => { _starsPanel.SetActive(true); });
    }

    private void ResetObjects(bool value)
    {
        _birdAttacker.enabled = value;
        _birdInput.enabled = value;
        _spawner.SetActive(value);
    }
}