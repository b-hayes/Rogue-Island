using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : stats {
	public bool rangeWeapon;
	// Use this for initialization
	void Start () {
		
	}
	public void genEnemy(int island, int difficulty)
	{
		setLevel (island);
		setMaxHealth ((island * 4) + difficulty * Random.Range (9, 11) + Random.Range (4, 14));
		calcMeleeDamage(difficulty*Random.Range(2,6));
		if (Random.Range (1, 100) < island * 4 + 10) 
		{
			setRangeDamge (0);
			rangeWeapon = false;
		} 
		else 
		{
			calcRangeDamage (difficulty * Random.Range (0, 10));
			rangeWeapon = true;
		}
		setDefence((island+difficulty)*Random.Range(0,4));
		setSpeed((float)Random.Range(1,5)*(((float)((level+difficulty))/3.0f)));
		fullHealth ();	
	}
	public void attackedMelee (Player attacker)
	{
		takeDamage (attacker.getMeleeDamage ());
	}
	public void attackedRange (Player attacker)
	{
		takeDamage (attacker.getRangeDamage ());
	}
}
