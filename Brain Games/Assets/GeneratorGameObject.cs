using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int n = 2;
		Generator gen = new Generator("hard", n);
	}

	// Update is called once per frame
	void Update () {

	}
}
