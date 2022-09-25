using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _rate;
    [SerializeField] private int _quality;

    private Rigidbody2D _rigidbody;
    private float _distanceToTarget;
    private float _force = 100;

    public float Rate => _rate;
    public float DistanceToTarget => _distanceToTarget;
    public int Quality => _quality;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void PushOut(BirdAttacker bird, Transform point)
    {
        float distance = 10f;

        RaycastHit2D hit = Physics2D.Raycast(point.position, transform.TransformDirection(Vector2.down), distance);
        _rigidbody.AddForce(Vector2.right * _force, ForceMode2D.Force);
        _distanceToTarget = hit.distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Damager damager))
        {
            Destroy(gameObject);
        }
    }
}
