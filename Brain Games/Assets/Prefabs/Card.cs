using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card{
  private string imgLoc;
  private string color;
  private static string[] colors = {"white", "red", "blue"};
  private static IDictionary<string, string[]> decks = new Dictionary<string, string[]>(){
    {"Number", new string[] {"Number/DummyNum"}},
    {"Shape", new string[]  {"Shape/DummyShape"}},
    {"Text", new string[] {"Text/DummyText"}}
  };

  public Card(string imgL, string c){
    imgLoc = imgL;
    color = c;
  }

  public static Card generateRandomCard(string[] decks, string[] colors){
    // returns a random card with a random color from
    int cardIndex = Random.Range(0, decks.Length);
    int colorIndex = Random.Range(0, colors.Length);

    return new Card(decks[cardIndex], colors[colorIndex]);
  }

	public static Card[,] makeSquareGrid(string difficulty, int n){
	// returns an NxN array of Card objects based on DIFFICULTY
		switch(difficulty){
			case "easy":
				return makeGrid(decks["Number"], Utilities.slice(colors, 0, 1), n, n);
			case "medium":
				return makeGrid(Utilities.concatenate<string>(decks["Number"], decks["Shape"]),
                        Utilities.slice(colors, 0, 2), n, n);
			case "hard":
				return makeGrid(Utilities.concatenate<string>(
                        Utilities.concatenate<string>(decks["Number"], decks["Shape"]),
                        decks["Text"]), Utilities.slice(colors, 0, 3), n, n);
			default:
				throw new System.ArgumentException("Difficulty must be: 'easy', 'medium', or 'hard'");

		}
	}

	public static Card[,] makeGrid(string[] decks, string[] colors,
                    int rows, int columns){
	// returns a ROWSxCOLUMNS array of Card objects based on NUMOFDECKS and COLORS

  Card[,] grid = new Card[rows, columns];
	for(int i = 0; i < rows; i++){
		for(int j = 0; j < columns; j++){
			grid[i,j] = generateRandomCard(decks, colors);
		}
	}
	return grid;
	}

  // Getters
  public string getImgLoc(){
    return imgLoc;
  }

  public string getColor(){
    return color;
  }
}
