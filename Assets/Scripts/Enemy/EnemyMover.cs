using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isLongFly;
    [SerializeField] private Animator _animator;

    private int _longFlying = Animator.StringToHash("LongTopDown");
    private int _shortFlying = Animator.StringToHash("TopDown");

    private void Start()
    {
        if (_isLongFly)
        {
            _animator.Play(_longFlying);
        }
        else
        {
            _animator.Play(_shortFlying);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
