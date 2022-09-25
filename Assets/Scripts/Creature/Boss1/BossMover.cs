using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossMover : MonoBehaviour
{
    [SerializeField] private Transform[] _borders;
    [SerializeField] private float _speed;

    private Transform _target;
    private int index;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        index = Random.Range(0, _borders.Length - 1);
        _target = _borders[0];
    }

    private void Update()
    {
        if (transform.position != _target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
        {
            index = Random.Range(0, _borders.Length -1);
            _target = _borders[index];
            SetDirection();
            StartCoroutine(PrepareToShoot());
        }
    }

    private void SetDirection()
    {
        if(transform.position.x > _target.position.x)
        {
            transform.localScale = new Vector2(-1,1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private IEnumerator PrepareToShoot()
    {
        _animator.Play("Shoot");
        _speed = 0;
        yield return new WaitForSeconds(1.5f);
        _speed = 2;
    }
}
