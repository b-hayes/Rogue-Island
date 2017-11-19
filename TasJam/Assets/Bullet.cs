using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
	public float speed = 5.0f; //this is set by the shooter
    public float damage = 1; //this is set by the shooter
    public string hurts = "monster"; // just incase we us ethe same bullet prefab for monsters..
	Rigidbody2D bullet;

	void Start() {
		bullet = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
        //shooter sets the postionion orientation and scale!
		bullet.AddForce (transform.up*speed); //position the shooter acordingly for this to work
	}
}
