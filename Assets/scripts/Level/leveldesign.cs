using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveldesign : MonoBehaviour
{
    public GameObject floortile;
    public GameObject bordertile;
    public GameObject watertile;
    public GameObject spawner;
    public GameObject[] tile;
    public int number_spawners;
    public int distance;
    public int borderamount = 0;
    int xMax = 0;
    int yMax = 0;
    public ruleGenerator theRules;

    void Start()
    {
        xMax = Random.Range(10, 50);
        yMax = Random.Range(10, 50);
        transform.position = new Vector3(((xMax / 2) + 0.5f) * -1, ((yMax / 2) + 0.5f), 0);
        drawMap();
        createSpawnPoint();
		Data.resetRules ();
        // theRules.setupRules (1);
    }

    void lookAt2D(Vector3 target, GameObject tile)
    {
        Vector3 diff = target - tile.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        tile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }

    void instantiateTile(GameObject tile, int xpos,int ypos,bool rotate)
    {
        GameObject tileGO = Instantiate(tile, tile.transform.position, transform.rotation) as GameObject;
        tileGO.transform.position = new Vector3(transform.position.x + xpos, transform.position.y - ypos, 0);

        if(rotate)
        {
            lookAt2D(new Vector3(0, 0, 0), tileGO);
        }

    }

    void drawMap()
    {
        int RNJesus = 0;
        int counter = 0;
        for (int i = -borderamount; i <= xMax + borderamount; i++)
        {
            for (int j = -borderamount; j <= yMax + borderamount; j++)
            {
                RNJesus = Random.Range(0, tile.Length);
                if (i == 0 || i == xMax)
                {
                    //then should be a border tile but we could be in the ocean still
                    if (j >= 0 && j <= yMax)
                    {
                        //then were still on land so
                        //draw border tile
                        instantiateTile(bordertile, i, j,true);
                      /*  if(number_spawners > 0 && transform.position.x>distance)
                        {
                            
                        }*/
                        /*if (i % 5 == 0)
                        {
                            GameObject spawnerGO = Instantiate(spawner, spawner.transform.position, transform.rotation) as GameObject;
                            spawnerGO.transform.position = new Vector3(transform.position.x + i, transform.position.y,0);
                            number_spawners--;
                        }*/
                    }
                    else
                    {
                        //water tiles outside the island
                        instantiateTile(watertile, i, j, false);
                        
                    }
                }
                else if (j == 0 || j == yMax)
                {
                    //then should be a border tile but we could be in the ocean still
                    if (i >= 0 && i <= xMax)
                    { 
                        //then were still on land so
                        //draw border tile
                        instantiateTile(bordertile, i, j, true);
                    }
                    else
                    {
                        //water tiles outside the island
                        instantiateTile(watertile, i, j, false);
                    }
                }
                else if ((i < 0 || j < 0) || (i > xMax || j > yMax))
                {
                    //water tiles outside the island
                    instantiateTile(watertile, i, j, false);
                }
                else
                {
                    //the island
                    instantiateTile(floortile, i, j, false);
                    counter++;
                    if (counter % Random.Range(3, 6) == 0)
                    {
                        instantiateTile(tile[RNJesus], i, j,false);
                        counter = 0;
                    }
                }


            }
        }
    }

    void createSpawnPoint()
    {
        //ocean spawners
        Vector3 pos = new Vector3(0, yMax-1, 0);
        Debug.Log(pos);
        GameObject spawnerGO = Instantiate(spawner, spawner.transform.position, transform.rotation) as GameObject;
        spawnerGO.transform.position = pos;
        pos.y *= -1;
        Debug.Log(pos);
        spawnerGO = Instantiate(spawner, spawner.transform.position, transform.rotation) as GameObject;
        spawnerGO.transform.position = pos;
        pos.y = 0;
        pos.x = xMax-1;
        spawnerGO = Instantiate(spawner, spawner.transform.position, transform.rotation) as GameObject;
        spawnerGO.transform.position = pos;
        pos.x *= -1;
        Debug.Log(pos);
        spawnerGO = Instantiate(spawner, spawner.transform.position, transform.rotation) as GameObject;
        spawnerGO.transform.position = pos;
    }
}