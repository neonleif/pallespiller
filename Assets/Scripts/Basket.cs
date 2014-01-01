﻿using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour
{
	int currPos = 2;
	public GameObject[] spawns;

	void Start ()
	{
		spawns = GameObject.FindWithTag("GameController").GetComponent<GameController>().spawns;
//		iTween.MoveTo (this.gameObject, iTween.Hash (
//			"position", new Vector3 (spawns [2].transform.position.x, -1f, 0f), 
//			"easetype", iTween.EaseType.spring, 
//			"time", 2f));
	}

	void Update ()
	{
		// get input
		if (Input.GetKeyDown("left"))
		{
			MoveLeft();
		}
		else if (Input.GetKeyDown("right"))
		{
			MoveRight();
		}
	}

	void MoveLeft ()
	{
		//only move 
		if (currPos > 0) {
			currPos--;
			//do the movement
			Move ();
		}
	}

	void MoveRight ()
	{
		if (currPos < spawns.Length-1) {
			currPos++;
			//do the movement
			Move ();
		}
	}

	void Move ()
	{
		if (!GameController.playing) {
			Instructions.Hide();
			GameController.playing = true;
		}
		iTween.MoveTo (this.gameObject, iTween.Hash (
			"position", new Vector3 (spawns [currPos].transform.position.x, -1f, 0f), 
			"easetype", iTween.EaseType.spring, 
			"time", .5f));
	}
}