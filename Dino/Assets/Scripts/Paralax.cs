using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    private float _length, _startPosition;
    public GameObject cam;
    public float paralaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1-paralaxEffect));

        float distance = (cam.transform.position.x * paralaxEffect);
        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if(temp > _startPosition + _length)
        {
            _startPosition += _length;
        }
        else if(temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }

    }
}
