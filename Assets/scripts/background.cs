using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    public GameObject watertile;
    public int x = 0;
    public int y = 0;

	void Start()
    {
        for (int i = 0; i <= x; i++)
        {
            for (int j = 0; j <= y; j++)
            {
                GameObject tileGO = Instantiate(watertile, watertile.transform.position, transform.rotation) as GameObject;
                tileGO.transform.position = new Vector3(transform.position.x + i, transform.position.y - j, 0);
            }
        }
    }
	
}
