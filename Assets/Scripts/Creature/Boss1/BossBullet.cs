using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BossBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Bird bird, Transform spawnPoint)
    {
        Vector2 offset = bird.gameObject.transform.position - spawnPoint.position;
        transform.parent = null;
        _rigidbody.AddForce(offset.normalized * _speed, ForceMode2D.Impulse);
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bird bird))
        {
            Destroy(gameObject);
        }
    }
}
