﻿using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnParticleCollision (GameObject obj)
	{
		if (obj.CompareTag("Bat"))
		{
			Debug.Log ("hit!");
		}
	}
}
