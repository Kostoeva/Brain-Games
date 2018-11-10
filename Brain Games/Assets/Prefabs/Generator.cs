using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator{
	private string difficulty;
	private int n;
	public GameObject cardObject;
	public GameObject[] cards;
	int position;

	float localScaleX = 0.64f;
	float localScaleZ = 0.89f;

	float cardY = 1.4f;
	float cardZ = 1.2f;

	public Generator(string diff, int size){
		difficulty = diff;
		n = size;
		cardObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

		float scalar = Mathf.Pow(0.8f, size);
		float scalar2 = 3f/n;
		localScaleX = 0.64f * scalar2;
		localScaleZ = 0.89f * scalar2;

		cardObject.transform.localScale = new Vector3(localScaleX, 0.004F, localScaleZ);
		cardObject.transform.Translate(new Vector3(100F, 100F, 100F));

		BoxCollider bc = cardObject.AddComponent<BoxCollider>() as BoxCollider;
		bc.size = new Vector3(1.0F, 1.0F, 1.0f);

		Rigidbody rb = cardObject.AddComponent<Rigidbody>() as Rigidbody;
		rb.useGravity = false;

		OVRGrabbable so = cardObject.AddComponent<OVRGrabbable>();

		Object.Destroy(cardObject);

		cards = new GameObject[n * n];
		position = 0;

		cardY = localScaleZ + scalar;
		cardZ = localScaleX + scalar;

		generateGrid();
	}

	public void generateGrid(){
		// creates a grid of cards in the environment
		Card[,] grid = Card.makeSquareGrid(difficulty, n);

		// Get list of random cards #s to be init cards
		System.Random rand = new System.Random();
		ArrayList initCards = new ArrayList();
		for (int numCardsInited = 0; numCardsInited < n; numCardsInited++) {
			int randomNumber = rand.Next(0, n*n);
			if (!initCards.Contains(randomNumber)) {
				initCards.Add(randomNumber);
			}
		}

		int currCard = 0;

		for(int i = 0; i < grid.GetLength(0); i++){
			for(int j = 0; j < grid.GetLength(1); j++){
				GameObject card = Object.Instantiate(cardObject, new Vector3(0 , i * cardY, j * cardZ), Quaternion.Euler(90, 0, 90));
				changeMatWithLoc(card, grid[i, j].getImgLoc());
				Card cardScript = cardObject.AddComponent<Card>();
				cards[position++] = card;



				if (initCards.Contains(currCard)) {
					// If card # in initCards, set Init = true via Card.cs setter
					cardScript.setInit(true);
					Debug.Log(currCard);
					initCards.Remove(currCard);
				}
				currCard++;
			}
		}

	}

	void changeMatWithLoc(GameObject obj,string local_address){
		obj.GetComponent<Renderer>().material = Resources.Load(local_address, typeof(Material)) as Material;
	}

}
