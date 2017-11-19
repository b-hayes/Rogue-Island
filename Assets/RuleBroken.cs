using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleBroken : MonoBehaviour {
	public Text broken;
	// Use this for initialization
	void Start () {
		broken.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Data.brokenRule) {
			broken.text = "You broke a rule! Next Level Up Weakened!";
		}
	}
}
