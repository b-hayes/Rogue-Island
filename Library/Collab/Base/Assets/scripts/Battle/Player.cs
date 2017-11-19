using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : stats 
{
	public int xp;
	public bool armour;
	// Use this for initialization
	void Start () {
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

}
