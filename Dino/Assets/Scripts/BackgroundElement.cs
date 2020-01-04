using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour
{

    [SerializeField] private float _Speed;
    [SerializeField] private Transform _neighbour;

    //Move elements to left
    public void move()
    {
        transform.Translate(Vector2.left * _Speed * Time.smoothDeltaTime);  
    }

    //snap the element to end of the neighbour
    public void snapToNeighbour()
    {
        transform.position = new Vector2(_neighbour.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Reset")
        {
            snapToNeighbour();
        }
    }
}
