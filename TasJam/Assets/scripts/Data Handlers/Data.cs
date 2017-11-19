using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data {
	public static GameObject player;
	public static int Difficulty = 1;
    public static int IslandCompleted = 0;
    public static int CurrentIsland = 1;
    public static int EnemiesAlive = -1;
	public static bool MovedUpDown = false, MovedLeftRight = false;
	public static bool brokenRule = false;
	public static int MaxHealth = 50;

	public static void setPlayer(GameObject p) {
		player = p;
	}

	public static GameObject getPlayer() {
		return player;
	}

	public static int getDifficulty() {
		return Difficulty;
	}

	public static void setDifficulty(int Diff) {
		Difficulty = Diff;
	}

	public static void resetRules() {
		MovedLeftRight = false;
		MovedUpDown = false;
		brokenRule = true;
	}

	public static void resetIslands() {
		CurrentIsland = 1;
		IslandCompleted = 0;
	}

	public static void setMovedUpDown(bool value) {
		MovedUpDown = value;
	}

	public static void setMovedLeftRight(bool value) {
		MovedLeftRight = value;
	}

    public static void endGame(bool victory)
    {
        if (victory == true)
        {
            player.GetComponent<Player>().levelUp(Difficulty, false);
			IslandCompleted++;
			CurrentIsland++;
            //TODO: load scene
			Scenes.SwitchScene("world map");
        }
        else
        {
            //do death scene here...
			Scenes.SwitchScene("Death");
        }
    }
}
