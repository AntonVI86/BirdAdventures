using UnityEngine;

public class EnemyCollisionDetected : MonoBehaviour
{
    [SerializeField] private GameObject _parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Border border))
        {
            _parent.SetActive(false);
        }
    }
}
