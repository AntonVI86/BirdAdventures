using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bird : AnimatorHash
{
    [SerializeField] private UnityEvent _died;

    public event UnityAction Died;

    private SpriteRenderer _renderer;
    private Animator _animator;

    public SpriteRenderer Renderer => _renderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Damager damager))
        {
            _animator.Play(EmptyHash);
            Died?.Invoke();
            _died?.Invoke();
        }
    }
}
