using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isLongFly;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (_isLongFly)
        {
            _animator.Play("LongTopDown");
        }
        else
        {
            _animator.Play("TopDown");
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
