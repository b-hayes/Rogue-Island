using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {


    public Text islandText;
    // Use this for initialization
    void Start ()
    {
        this.islandText.text = "You have completed: " + Data.IslandCompleted.ToString() + " Islands";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
