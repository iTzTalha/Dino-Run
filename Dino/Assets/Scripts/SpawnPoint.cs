using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-1.5f, 3f), 0);
    }
}
