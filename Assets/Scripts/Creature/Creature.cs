using TMPro;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AddingScoreTextDisplayer))]
public class Creature : CreatureAnimator
{
    [SerializeField] private int _startReward;
    [SerializeField] private UnityEvent _hited;
    [SerializeField] private UnityEvent _soiled;
    [SerializeField] private bool _isSoil;

    public event UnityAction<int, Creature> GiveReward;

    private int _totalReward;
    private AddingScoreTextDisplayer _scoreDisplayer;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _scoreDisplayer = GetComponent<AddingScoreTextDisplayer>();

        _isSoil = false;
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
                _scoreDisplayer.AnimateDisplayScoreText(_totalReward);
                _isSoil = true;
            }

            Destroy(bullet.gameObject);
        }
        else if(collision.TryGetComponent(out Border border))
        {
            gameObject.SetActive(false);
        }       
    }
}
