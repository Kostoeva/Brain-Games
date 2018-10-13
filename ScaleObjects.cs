using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleObjects : MonoBehaviour {
    public GameObject card;
    public CameraZoom cam;

    public List<GameObject> cards = new List<GameObject>();
    public int initial_number = 2;
    public int scaled_number = 4;

    public float distance_between_cards = 5f;
    public float zoom_distance;

    public Slider difficulty_slider;
    public int easy_scaled_number = 2;
    public int medium_scaled_number = 4;
    public int hard_scaled_number = 8;
    public string difficulty = "Easy";
    
	// Use this for initialization
	void Start () {
        SpawnObjects(initial_number);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            zoom_distance = scaled_number * distance_between_cards;
            print(zoom_distance);
            cam.Zoomout(zoom_distance);
            DeleteObjects();
            SpawnObjects(scaled_number);
        }
    }

    void SpawnObjects(int number)
    {
        if(number%2 == 0)
        {
            float start_pos = 0.5f * distance_between_cards - number/2* distance_between_cards;
            print(start_pos);
            for(int row = 0; row<number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    Vector3 spawn_position = new Vector3(start_pos+col* distance_between_cards, 0f, start_pos + row * distance_between_cards);
                    print(start_pos + col * distance_between_cards);
                    GameObject c = Instantiate(card, spawn_position, new Quaternion(0, 0, 0, 0));
                    cards.Add(c);
                }
            }
        }
        else
        {
            float start_pos = -number / 2 * distance_between_cards;
            print(start_pos);
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    Vector3 spawn_position = new Vector3(start_pos + col * distance_between_cards, 0f, start_pos + row * distance_between_cards);
                    print(start_pos + col * distance_between_cards);
                    GameObject c = Instantiate(card, spawn_position, new Quaternion(0, 0, 0, 0));
                    cards.Add(c);
                }
            }
        }
        
    }

    void DeleteObjects()
    {
        foreach(GameObject c in cards)
        {
            Destroy(c);
        }
    }

    public void UpdateDifficulty()
    {
        print(difficulty_slider.value);
        if (difficulty_slider.value == 0)
        {
            scaled_number = easy_scaled_number;
        }
        if (difficulty_slider.value == 1)
        {
            scaled_number = medium_scaled_number;
        }
        if (difficulty_slider.value == 2)
        {
            scaled_number = hard_scaled_number;
        }
    }
}
