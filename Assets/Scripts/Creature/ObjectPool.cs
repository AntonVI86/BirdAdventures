using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public void Init(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public void Init(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int index = Random.Range(0, prefabs.Length);

            var spawned = Instantiate(prefabs[index], transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
