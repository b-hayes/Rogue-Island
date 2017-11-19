using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsDisplay : MonoBehaviour {
    public Text stats;
	// Use this for initialization
	void Start () {
        this.stats.text = "You completed: " + Data.IslandCompleted + " island";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
