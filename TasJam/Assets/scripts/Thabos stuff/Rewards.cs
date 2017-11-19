using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Items islandReward(int currentLocation)
	{
		Items bonus = new Items();
		bonus.itemType = Random.Range (1, 4);
		if (bonus.itemType == 3) 
		{
			bonus.itemStat = Random.Range (0, 5);	
		} 
		else if (bonus.itemType == 2 || bonus.itemType == 1) 
		{
			bonus.itemStat = Random.Range (currentLocation, currentLocation + 10);
		}
		return bonus;

	}

}
