using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPView : MonoBehaviour {
	public Text hp;
	// Use this for initialization
	void Start() {
		if (Data.player != null) {
			hp.text = "HP : " + Data.player.GetComponent<Player> ().health;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Data.player != null) {
			hp.text = "HP : " + Data.player.GetComponent<Player> ().health;
		}
	}
}
