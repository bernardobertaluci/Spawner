using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField]private GameObject _template;

    private Transform[] _spawners;
    private Transform _parent;

    private float _delay = 2f;

    private void Start()
    {
        _parent = GetComponent<Transform>();
        GetChildTransform();

        StartCoroutine(SpawnEnemy());
    }

    private void GetChildTransform()
    {
        _spawners = new Transform[_parent.childCount];

        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i] = _parent.GetChild(i);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        for (int i = 0; i < _spawners.Length; i++)
        {
            Instantiate(_template, _spawners[i].position, Quaternion.identity);

            yield return waitForSeconds;
        } 
    }
}
