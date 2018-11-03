using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator{
	private string difficulty;
	private int n;
	public GameObject cardObject;
	public GameObject[] cards;
	int position;

	public Generator(string diff, int size){
		difficulty = diff;
		n = size;
		cardObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cardObject.transform.localScale = new Vector3(0.64F, 0.004F, 0.89f);
		cardObject.transform.Translate(new Vector3(100F, 100F, 100F));

		BoxCollider bc = cardObject.AddComponent<BoxCollider>() as BoxCollider;
		bc.size = new Vector3(1.0F, 1.0F, 1.0f);

		Rigidbody rb = cardObject.AddComponent<Rigidbody>() as Rigidbody;
		rb.useGravity = false;

		OVRGrabbable so = cardObject.AddComponent<OVRGrabbable>();

		Object.Destroy(cardObject);

		cards = new GameObject[n * n];
		position = 0;
		generateGrid();
	}

	public void generateGrid(){
		// creates a grid of cards in the environment
		Card[,] grid = Card.makeSquareGrid(difficulty, n);

		for(int i = 0; i < grid.GetLength(0); i++){
			for(int j = 0; j < grid.GetLength(1); j++){
				GameObject card = Object.Instantiate(cardObject, new Vector3(i * 0.8F, 0, j * 1F), Quaternion.identity);
				changeMatWithLoc(card, grid[i, j].getImgLoc());
				Card cardScript = cardObject.AddComponent<Card>();
				cards[position++] = card;
			}
		}

	}

	void changeMatWithLoc(GameObject obj,string local_address){
		obj.GetComponent<Renderer>().material = Resources.Load(local_address, typeof(Material)) as Material;
	}

}
