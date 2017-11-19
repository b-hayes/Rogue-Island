using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : stats 
{
	public int xp;
	public bool armour;
    
	// Use this for initialization
	void Start () {
        startingValues();
	}
	public void startingValues ()
	{
	    speed = 1.2f;
	    maxHealth = 50;
	    rangeDamage = 10;
	    defence = 1;
	    fullHealth();
    }
	public void attackedMelee (Enemy attacker)
	{
		takeDamage (attacker.getMeleeDamage ());
	}
	public void attackedRange (Enemy attacker)
	{
		takeDamage (attacker.getRangeDamage ());
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletinthehead")
        {
            Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            if (bullet.hurts == gameObject.tag)
            {
                health = health - (int)bullet.damage;
            }

            if (health < 0)
            {
                //no health left do die!
                Destroy(transform.gameObject);
            }
            //detro bullet
            Destroy(coll.gameObject);
        }
    }
}
