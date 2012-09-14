using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	enum GameState
	{
		Menu,
		NewGame,
		Playing,
		GameOver
	}
	
	public GameObject Player;
	public GameObject Fleet;
	
	public static int Score = 0;
	
	GameState state;

	// Use this for initialization
	void Start () 
	{
		state = GameState.NewGame;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (state)
		{
		case GameState.Menu:
			break;
			
		case GameState.NewGame:
			
			// create objects
			Instantiate(Player, new Vector3(0, -3.5f, 0), Quaternion.identity);
			Instantiate(Fleet, new Vector3(0, 7, 0), Quaternion.identity);

			state = GameState.Playing;
			
			break;
			
		case GameState.Playing:
			
			if (!FleetScript.IsAlive)
			{
				print ("fleet destroyed");
				FleetScript.IsAlive = true;
				FleetScript.Wave++;
				
				Instantiate(Fleet, new Vector3(0, 7, 0), Quaternion.identity);
				
				// increase fleet speed 
				if (Fleet.GetComponent<FleetScript>().FleetSpeed <= 3)
					Fleet.GetComponent<FleetScript>().FleetSpeed += .5f;
			}
			
			break;
			
		case GameState.GameOver:
			break;
		}
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 200, 100), Score.ToString());	
	}
}
