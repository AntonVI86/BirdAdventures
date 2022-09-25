using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAbilities))]
public class BirdAttacker : AnimatorHash
{
    [SerializeField] private Bullet _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _rayPoint;

    public event UnityAction<float> FullnessChanged;
    public event UnityAction FullnessIsEmpty;

    private PlayerAbilities _abilities;
    private float _currentFullness;
    private float _elapsedTime;
    private Animator _animator;

    public float CurrentFullness => _currentFullness;

    private void Awake()
    {
        _abilities = GetComponent<PlayerAbilities>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentFullness = _abilities.MaxFulness;
        FullnessChanged?.Invoke(_currentFullness);
    }

    public void CreateBullet()
    {
        if (_elapsedTime <= 0 && _currentFullness > 0)
        {
            _animator.SetTrigger("Empty");

            Bullet newBullet = Instantiate(_template, _spawnPoint);
            newBullet.PushOut(this, _rayPoint);
            ChangeFullnessValue(newBullet.Rate);
            _elapsedTime = _abilities.TimeBetweenShoot;
            StartCoroutine(CountDown());
        }
    }

    private void ChangeFullnessValue(float value)
    {
        _currentFullness -= value;
        FullnessChanged?.Invoke(_currentFullness);
    }

    private IEnumerator CountDown()
    {
        while(_elapsedTime > 0)
        {
            _elapsedTime -= Time.deltaTime;
            yield return null;
        }

        if (_currentFullness <= 0)
        {
            FullnessIsEmpty?.Invoke();
        }
    }
}
