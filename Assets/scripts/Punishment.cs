using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punishment : MonoBehaviour {
	const int punishmentCount = 0;
	// Use this for initialization
	void Start () {
		
	}
	int punish(Player victim)
	{
		int punishment = Random.Range (0, punishmentCount);
		switch (punishment) 
		{
		case 0:
			
			break;
		default :
			victim.takeDamage (5);
			break;
		}
		return punishment;

	}
	// Update is called once per frame
	void Update () {
			
	}
}
