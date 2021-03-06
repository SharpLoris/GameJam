﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {

	public GameObject room;
	public GameObject stairs;
	public GameObject door;
	public GameObject wall;

	public int roomSize = 5;
	public int roomSizeH = 2;
	public double worldWidth = 5;
	public double worldHeight = 5;

	GameObject[] _rooms;

	// Use this for initialization
	void Start () {
		if (worldHeight % 2 == 0) {
			worldHeight++;
		}
		if (worldWidth % 2 == 0) {
			worldWidth++;
		}

		_rooms = new GameObject[(int)worldWidth * (int)worldHeight];
		genworld ();
	}


	void genworld()
	{
		for (int x = 1; x <=worldWidth; x++)
		{
			for (int y = 1; y <=worldHeight; y++)
			{
				double level = (worldWidth/2)+0.5;

				if(x == 1)
				{
					_rooms[x] = (GameObject)Instantiate(room,new Vector3((0+room.GetComponent<roomData>().size)*x,(0+roomSizeH)*y,0),Quaternion.identity);
					GameObject wallObj = (GameObject)Instantiate(wall,new Vector3((room.GetComponent<roomData>().size)*x,(0+roomSizeH)*y,0),Quaternion.identity);
					wallObj.transform.parent = this.transform;
				}
				else if(x == worldWidth)
				{
					_rooms[x] = (GameObject)Instantiate(room,new Vector3((0+room.GetComponent<roomData>().size)*x,(0+roomSizeH)*y,0),Quaternion.identity);
				}
				if(x != level)
				{
					_rooms[x] = (GameObject)Instantiate(room,new Vector3((0+room.GetComponent<roomData>().size)*x,(0+roomSizeH)*y,0),Quaternion.identity);

				}
				else
				{
					_rooms[x] = (GameObject)Instantiate(stairs,new Vector3((0+roomSize)*x,(0+roomSizeH)*y,0),Quaternion.identity);
				}

				_rooms[x].gameObject.transform.parent = this.transform;
			}
		}
	}

	int[] splitInt(int n)
	{
		List<int> digits = new List<int> ();
		while (n > 0) 
		{
			digits.Add(n%10);
			n/=10;
		}
		digits.Reverse ();
		return digits.ToArray();
	}

	string printArray(int[] i)
	{
		string s = "";
		foreach(int p in i)
		{
			s += p;
		}
		return s;
	}
}
