using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : stats 
{
	public int xp;
	public bool armour;
    public AudioSource death;
    // Use this for initialization
    void Start () {
        startingValues();
		health = Data.MaxHealth;
		maxHealth = Data.MaxHealth;
	    Data.player = gameObject;
        death = GetComponent<AudioSource>();
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

    public void levelUp(int difficulty, bool ruleBroken)
    {
		
		if (!Data.brokenRule)
        {
            maxHealth = maxHealth + difficulty * 4;
            rangeDamage = rangeDamage + difficulty * 2;
            speed = speed + .05f;
        }
        else
        {
            maxHealth = maxHealth + difficulty * 3;
            rangeDamage = rangeDamage + difficulty;
            speed = speed + .01f;

        }
		Data.MaxHealth = maxHealth;
		Data.brokenRule = false;
        fullHealth();
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
                death.Play();
                Destroy(transform.gameObject,4.101f);
                Data.player = null;
				Data.endGame (false);
            }
            //detro bullet
            Destroy(coll.gameObject);
        }
    }

    public void displayStats(Text display)
    {
        display.text += "health : " + health + "\n";

    }
}
