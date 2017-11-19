using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	int player_x, player_y;
	public bool playerTurn = true;
	public bool moving = false;
	public float speed = 5.0f;
	public float moveDistance = 32;
	float dX, dY;
    public float rotationOffset = 0;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		if (x != 0) {
			Data.MovedLeftRight = true;
		}
		var y = Input.GetAxis ("Vertical") * Time.deltaTime * speed;
		if (y != 0) {
			Data.MovedUpDown = true;
		}

		GetComponent<Rigidbody2D> ().MovePosition (new Vector2(transform.position.x + x, transform.position.y + y));

        //look at the mouse position
	    Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	    diff.Normalize();
	    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.Euler(0f, 0f, rot_z + rotationOffset);
    }

}
