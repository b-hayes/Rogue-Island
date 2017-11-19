using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAI : MonoBehaviour
{
    public GameObject player;
    public float rotationOffset = 0;
    public int Dif;
    public AudioSource death;
    protected Enemy self;

    public Sprite deathSprite;
    public Sprite shootSprite;

    public Sprite normalSprite;

    private bool shooting = false;
    private float shootTime = 0.2f;

    public float speed = 1f;

    // Use this for initialization
    void Start ()
    {
        normalSprite = GetComponent<SpriteRenderer>().sprite;
        Dif = Data.Difficulty;
        self = this.GetComponent<Enemy>();
        self.genEnemy(Data.CurrentIsland, Data.Difficulty);               //generates the stats for this guy :)
	    if (player == null)
	    {
	        player = GameObject.Find("Player");
	    }
        death = GetComponent<AudioSource>();
        self.speed = speed;

    }
	
	// Update is called once per frame
	void Update () {
        if (self.dead) { return;}
	    if (shooting)
	    {
	        shootTime -= Time.deltaTime;
	        if (shootTime < 0)
	        {
	            shooting = false;
	            GetComponent<SpriteRenderer>().sprite = normalSprite;
	        }
	    }

	    if (player == null) {
			return;
		}
		gameObject.GetComponent<Rigidbody2D> ().transform.position = Vector3.MoveTowards (transform.position, player.transform.position, self.speed * Time.deltaTime);
        //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

	    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset);

	    if (self.rangeWeapon)
	    {
	        //shoot if the monster has a shooter..
	        Shoot[] shooters = GetComponentsInChildren<Shoot>();
	        foreach (Shoot gun in shooters)
	        {
                //works if multiple guns/shooters are found on the monster
	            //gun.cooldown = 1f / Data.Difficulty;
	            //gun.speed = self.speed * 10;
	            if (gun.shoot())
	            {
	                if (shootSprite != null)
	                {
	                    GetComponent<SpriteRenderer>().sprite = shootSprite;
                    }
                    shooting = true;
	                shootTime = 0.2f;
	            }
            }
        }
        
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "bulletinthehead") {
		    Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            if (bullet.hurts == gameObject.tag)
		    {
		        self.health = self.health - (int)bullet.damage;
		    }
		    
		    if (self.health < 0)
		    {
                //no health left do die!
		        self.dead = true;
		        Collider2D[] colls = gameObject.GetComponents<Collider2D>();
		        foreach (Collider2D col in colls)
		        {
		            col.enabled = false;
		        }

                death.Play();

		        if (deathSprite != null)
		        {
		            GetComponent<SpriteRenderer>().sprite = deathSprite;
		        }
		        self.speed = 0;

		        Data.EnemiesAlive--;
		        if (Data.EnemiesAlive == 0)
		        {
		            Data.endGame(true);
		        }
		        Destroy (transform.gameObject,0.4f);
            }
            //detro bullet
		    Destroy(coll.gameObject);
        }
    }

}
