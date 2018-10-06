using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMain : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// The following code demonstrates the use of changeMatWithLoc
		if (Input.GetKey(KeyCode.UpArrow)){
			changeMatWithLoc("Number/DummyNum");
		}

		if (Input.GetKey(KeyCode.DownArrow)){
			changeMatWithLoc("Shape/DummyShape");
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			changeMatWithLoc("Text/DummyText");
		}
	}

	// Other Functions

	void changeMatWithLoc(string local_address){
		GetComponent<Renderer>().material = Resources.Load(local_address, typeof(Material)) as Material;
	}
}
