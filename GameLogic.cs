using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour{
  private string[] rules = {"Rule1", "Rule2"};
  private GameObject[] answer;
  private GameObject[] attempt;
  private Generator gen;
  public int ruleNumber;


  void Start(){
    displayRule(rules[ruleNumber]);
    newGame();
  }

  void Update(){
    // replace attempt with the current PickedCard
    attempt = new GameObject[]{new GameObject(), new GameObject()};

    if (checkAnswer(attempt)){
      youWin();
      newGame();
    }
  }

  public bool checkAnswer(GameObject[] attempt){
    return attempt == answer;
  }

  public void newGame(){
    gen = new Generator("hard", 3);

    switch(ruleNumber){
      case 1:
        //answer = ;
        break;
      case 2:
        //answer = ;
        break;
    }
  }

  public void displayRule(string rule){
    // Display the rule for user
    Debug.Log(rule);
  }

  public void youWin(){
    Debug.Log("You Win!");
  }
}
