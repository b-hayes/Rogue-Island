using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAI : MonoBehaviour
{

    public GameObject player;
    public float speed = 1;
    public float rotationOffset = 0;

	// Use this for initialization
	void Start () {
	    if (player == null)
	    {
	        player = GameObject.Find("Player");
	    }
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

	    //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
	    Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

	    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset);

    }
}
