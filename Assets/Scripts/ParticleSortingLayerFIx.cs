﻿using UnityEngine;
using System.Collections;

public class ParticleSortingLayerFIx : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "RocketPlayer";
		particleSystem.renderer.sortingOrder = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
