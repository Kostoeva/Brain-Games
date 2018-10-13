using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMain : MonoBehaviour {


	// Use this for initialization
	void Start () {

		// Tests the makeSquareGrid method along with all the methods used in the process
		Card[,] grid = Card.makeSquareGrid("hard", 2);
		for(int k = 0; k < grid.GetLength(0); k++){
			for(int l = 0; l < grid.GetLength(0); l++){
				Debug.Log(grid[k, l].getImgLoc());
				Debug.Log(grid[k, l].getColor());
			}
		}

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
