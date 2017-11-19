using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data {
	public static GameObject player;
	public static int Difficulty = 1;
    public static int IslandCompleted = 0;
    public static int CurrentIsland = 1;
    public static int EnemiesAlive = -1;

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

    public static void endGame(bool victory)
    {
        if (victory)
        {
            player.GetComponent<Player>().levelUp(Difficulty, false);
            //TODO: load scene
        }
        else
        {
            //do death scene here... thingie is making one
            
        }
    }
}
