using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _Enemies;
    public float _scrollSpeed = 10f;
    [SerializeField]
    private Transform enemieSpawnPoint;
    private float _counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if(_counter <= 0)
        {
            GenerateEnemies();
        }
        else
        {
            _counter -= Time.deltaTime;
        }
        /*
        GameObject currentChild;
        for(int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollEnemies(currentChild);

            if (currentChild.transform.position.x <= -9.702356)
            {
                Destroy(currentChild);
            }
        }
        */
    }

    private void GenerateEnemies()
    {
        GameObject newEnemy = Instantiate(_Enemies[UnityEngine.Random.Range(0, _Enemies.Length)], enemieSpawnPoint.position, Quaternion.identity);
        newEnemy.transform.parent = transform;
        _counter = 2f;
    }
/*
    private void ScrollEnemies(GameObject currentEnemy)
    {
        currentEnemy.transform.position += Vector3.left * _scrollSpeed * Time.deltaTime;
    }
    */
}
