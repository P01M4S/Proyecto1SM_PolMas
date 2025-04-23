using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawn Enemigos")]
    [SerializeField] private GameObject[] _enemysPrefab;
    [SerializeField] private int _enemysToSpawn;
    [SerializeField] private Transform _spawnPoint;
    private BoxCollider2D _collider;
    private int _enemyIndex;

    // Update is called once per frame
    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    void SpawnEnemy()
    {
        _enemyIndex = Random.Range(0, 2);
        Instantiate(_enemysPrefab[_enemyIndex], _spawnPoint.position, _spawnPoint.rotation);
        _enemysToSpawn--;
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _collider.enabled = false;
            InvokeRepeating("SpawnEnemy", 0, 2);
        }
    }

    void Update()
    {
        if(_enemysToSpawn <= 0)
        {
            CancelInvoke();
        }
    }
}
