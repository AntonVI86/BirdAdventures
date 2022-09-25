using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _hited;
    public event UnityAction Strucked;

    private BossAttacker _attacker;
    private BossMover _mover;

    private void Awake()
    {
        _attacker = GetComponent<BossAttacker>();
        _mover = GetComponent<BossMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bullet bullet))
        {
            _hited?.Invoke();
            _health--;

            if(_health <= 0)
            {
                Strucked?.Invoke();
                _attacker.enabled = false;
                _mover.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
