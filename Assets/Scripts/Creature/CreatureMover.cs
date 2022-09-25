using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CreatureMover : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private SpriteRenderer _renderer;
    private float _speed;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _speed = _startSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    public void ResetCreature()
    {
        _speed = _startSpeed;
    }

    public void SetDirection(Bird bird)
    {
        if (transform.position.x < bird.transform.position.x)
        {
            _renderer.flipX = false;

            if (_speed > 0)
                _speed *= -1;
        }
        else if (transform.position.x > bird.transform.position.x)
        {
            _renderer.flipX = true;

            if (_speed < 0)
                _speed *= -1;
        }
    }

    public void ChangeDirection()
    {
        float soiledSpeed = -0.55f;

        _speed = soiledSpeed;
    }
}
