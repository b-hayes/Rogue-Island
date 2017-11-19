using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hardness : MonoBehaviour {
	public int pain;
	public Text difficultyText;
		
	public void setRandomHardness()
	{
		pain = Random.Range (1, 4);
		switch(pain)
		{
			case 1:
			this.difficultyText.text = "easy";
				break;
			case 2:
			this.difficultyText.text = "medium";
				break;
			case 3:
			this.difficultyText.text = "hard";
				break;
			default:
			this.difficultyText.text = "easy";
				break;
		}
	
	}

    public void sendPain()
    {
        Data.Difficulty = pain;
    }
	// Use this for initialization
	void Start () 
	{
		setRandomHardness ();	
	
	}



	// Update is called once per frame
	void Update () {
		
	}
}
