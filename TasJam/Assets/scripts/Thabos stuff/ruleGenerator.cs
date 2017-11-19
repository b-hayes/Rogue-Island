using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ruleGenerator:  MonoBehaviour
{

    public Text ruleDisplay;
	List<int> activeRules;
	int maxRule;
	bool doomed;
	string[] rulenames;
	void Start ()
	{
		activeRules = new List<int>();
		maxRule = 4;
        
		rulenames = new string[maxRule + 1];
		rulenames [4] = "Stay above half health";
		rulenames [2] = "Don't move up or down";
		rulenames [3] = "Don't move left or right";
		rulenames [1] = "Don't move";
		setupRules(Data.Difficulty);
	}
	public void setupRules(int ruleCount)
	{
		int[] usedRules = new int[ruleCount];
		for (int i = 0; i < ruleCount; i++) 
		{
			bool used;
			int hat;
			do
			{
				// Actually change
				hat = Random.Range(0,maxRule+1);
				used = false;
				for (int j = 0; j < ruleCount; j++)
				{
					if (usedRules[j] == hat)
					{
						used = true;
					}
				}
			} while(used);
			activeRules.Add (hat);
			undoom ();
			displayRules ();
		}
	}

	public bool applyRules(Player dangerStats)
	{
		bool breached = false;
		for (int i=0;i<activeRules.Count;i++)
		{ 
			switch (activeRules[i])
			{
			case 4:
				breached = underHealth (dangerStats);
				break;
			case 2:
				breached = Data.MovedUpDown;
				break;
			case 3:
				breached = Data.MovedLeftRight;
				break;
			case 1:
				breached = Data.MovedUpDown && Data.MovedLeftRight;
				break;
			default:
				breached = false;
				break;
			}
			if (breached)
			{
				doomed = breached;
				return breached;
			}
		}
		return breached;
	}
	bool underHealth(Player theStats)
	{
		
		return theStats.getHealth () < (theStats.getMaxHealth ()/2);
	}
	bool ruleBreaker()
	{
		return doomed;
	}
	public void undoom()
	{
		doomed = false;
	}

    void displayRules()
    {
        if (activeRules != null)
        {
			
			for(int i=0;i<activeRules.Count;i++)
            {
				
				this.ruleDisplay.text = rulenames [activeRules [i]];
			

            }
			Debug.Log (ruleDisplay);
        }
    }
	void Update()
	{
		if (Data.player != null) {
			Data.brokenRule = applyRules (Data.player.GetComponent<Player> ());
		}
	}
	void punish(Player victim)
	{
		int punishment = Random.Range (0, 0);
		switch (punishment) 
		{
		default :
			victim.takeDamage (50);
			break;
		}

	}
}