using TMPro;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Creature : CreatureAnimator
{
    [SerializeField] private int _startReward;
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private UnityEvent _hited;
    [SerializeField] private UnityEvent _soiled;

    [SerializeField] private bool _isSoil;
    private int _totalReward;
    [SerializeField]private RectTransform _textPosition;
    [SerializeField]private Color _textColorAlpha;

    public event UnityAction<int, Creature> GiveReward;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _scoreText.gameObject.SetActive(false);
        _isSoil = false;
        _textColorAlpha = _scoreText.color;
        _textPosition = _scoreText.rectTransform;
    }

    private void OnDisable()
    {
        _scoreText.color = _textColorAlpha;
        _scoreText.rectTransform.position = _textPosition.position;
    }

    public void CalculateTotalReward(float distance)
    {
        _totalReward = (int)(_startReward * distance/2);
    }  

    public void Clear()
    {
        _isSoil = false;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bullet bullet))
        {
            CalculateTotalReward(bullet.DistanceToTarget);
            _hited?.Invoke();

            if(_isSoil == false)
            {
                Animator.SetTrigger(SoiledHash);
                _soiled?.Invoke();
                GiveReward?.Invoke(_totalReward, this);
                AnimateDisplayScoreText();
                _isSoil = true;
            }

            Destroy(bullet.gameObject);
        }
        else if(collision.TryGetComponent(out Border border))
        {
            gameObject.SetActive(false);
        }       
    }

    private void AnimateDisplayScoreText()
    {
        float distance = 0.3f;
        float lifeTime = 1f;

        _scoreText.gameObject.SetActive(true);
        _scoreText.text = $"+ {_totalReward}";
        _scoreText.transform.DOMoveY(distance, lifeTime).OnComplete(() => _scoreText.transform.DOMoveY(-distance, 0));
        _scoreText.DOFade(0, lifeTime).OnComplete(() => _scoreText.gameObject.SetActive(false)); 
        ResetScoreText();
    }

    private void ResetScoreText()
    {
        _scoreText.rectTransform.anchoredPosition = new Vector2(0, 0);
    }
}
