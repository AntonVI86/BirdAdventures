using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Bird : AnimatorHash
{
    [SerializeField] private UnityEvent _died;

    public event UnityAction Died;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Damager damager))
        {
            _animator.Play("Empty");
            Died?.Invoke();
            _died?.Invoke();
        }
    }
}
