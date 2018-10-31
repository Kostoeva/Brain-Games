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
		cardObject.transform.localScale = new Vector3(6.4F, 0.04F, 8.9f);
		cards = new GameObject[n * n];
		position = 0;
		generateGrid();
	}

	public void generateGrid(){
		// creates a grid of cards in the environment
		Card[,] grid = Card.makeSquareGrid(difficulty, n);

		for(int i = 0; i < grid.GetLength(0); i++){
			for(int j = 0; j < grid.GetLength(1); j++){
				GameObject card = Object.Instantiate(cardObject, new Vector3(i * 8.4F, 0, j * 10.9F), Quaternion.identity);
				changeMatWithLoc(card, grid[i, j].getImgLoc());
				cards[position++] = card;
			}
		}

	}

	void changeMatWithLoc(GameObject obj,string local_address){
		obj.GetComponent<Renderer>().material = Resources.Load(local_address, typeof(Material)) as Material;
	}

}
