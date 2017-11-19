using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTile : MonoBehaviour {
	public int tileLeft;
	public int tileRight;
	public int tileDown;
	public int tileUp;
	public int startX;
	public int startY;
	float tileGap = 1.0f;
	public bool useCurrentPosition;

	public Transform prefab;
	// Use this for initialization
	void Start()
	{
		if (useCurrentPosition) {
			startX = (int)transform.position.x;
			startY = (int)transform.position.y;
		}
		for (int i = 0; i < tileLeft; i++)
		{
			Instantiate(prefab, new Vector3((i * -tileGap)+startX, startY, 0), Quaternion.identity);
		}

		for (int i = 0; i < tileRight; i++)
		{
			Instantiate(prefab, new Vector3(i * tileGap + startX, startY, 0), Quaternion.identity);
		}

		for (int i = 0; i < tileDown; i++)
		{
			Instantiate(prefab, new Vector3(startX, (i * -tileGap)+ startY, 0), Quaternion.identity);
		}

		for (int i = 0; i < tileUp; i++)
		{
			Instantiate(prefab, new Vector3(startX, (i * tileGap) + startY, 0), Quaternion.identity);
		}
	}
}
