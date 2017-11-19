using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	public int health, maxHealth, meleeDamage, rangeDamage, defence;
	public int level;
	public float speed;
    public bool dead;
	void Start () {
		
	}
	public void fullHealth()
	{
		health = maxHealth;
	}
	public void calcMeleeDamage(int weaponStat)
	{
		meleeDamage = (level * 2 + weaponStat) * 2;
	}
	public void calcRangeDamage(int weaponStat)
	{
		rangeDamage = level * 2 + weaponStat;
	}
	public void setMeleeDamge(int desiredDamage)
	{
		meleeDamage = desiredDamage;
	}
	public void setRangeDamge(int desiredDamage)
	{
		rangeDamage = desiredDamage;
	}
	public void meleeAttackAgainst(stats other) //the "stats" you give this function attack the health of this "stats"
	{
		takeDamage (other.getMeleeDamage ());
	}
	public int getMeleeDamage()
	{
		return meleeDamage;
	}
	public void rangeAttackAgainst(stats other)
	{
		takeDamage (other.getRangeDamage ());
	}
	public int getRangeDamage()
	{
		return rangeDamage;
	}
	public int getHealth()
	{
		return health;
	}
	public int getMaxHealth()
	{
		return maxHealth;
	}
	public void setHealth(int statIn)
	{
		health = statIn;
	}
	public void setMaxHealth(int statIn)
	{
		maxHealth = statIn;
	}
	public void setDefence(int strongness)
	{
		defence = strongness;
	}
	public void setLevel(int newLevel)
	{
		level = newLevel;
	}
	public bool isDead()
	{
		return dead;
	}
	public void bringToLife()
	{
		dead = false;
	}
	public void setSpeed(float hasteiness)
	{
		speed = hasteiness;
	}
	public float getSpeed()
	{
		return speed;
	}
	public void takeDamage(int power)// deals damage to this bundle of stats, minus defence. Slightly random. Returns true if dead.
	{
		power = power - defence;
		if (power < 0)
		{
			power = 1;
		}
		if (health <= 0) {
			dead = true;
		} 
		else 
		{
			dead = false;
		}
		health = health - power + Random.Range(-4,4);
	}
	public bool heal(int power)
	{
 
		if (health == maxHealth || dead) 
		{
			return false;
		}
		health = health + power;
		if (health > maxHealth) 
		{
			health = maxHealth;
		}
		return true;

	}
	// Update is called once per frame
	void Update () {
		
	}
}
