using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {

	
	public float moveSpeed = -5f;
	

	// Update is called once per frame
	void Update () {

		transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
		transform.position.y);

		DestoyObstacle();
	}
	private void DestoyObstacle()
	{
		if (transform.position.x< -12)
			Destroy (gameObject);
	}
}
