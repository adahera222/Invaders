using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	// Possible game states
	enum GameState
	{
		Menu,
		NewGame,
		Playing,
		GameOver
	}
	
	// Public variables
	public Transform Player;
	public Transform Fleet;
	public Transform Menu;
	public float MenuSpeed = 2.0f;
	
	// Static variables
	public static int Score = 0;
	
	// Private variables
	private GameState state;
	private GameObject player;
	private GameObject fleet;
	private GameObject menu = null;
	private bool menuDown = false;
	
	private bool doMenu = false;
	private bool doGame = false;
	private bool doPause = false;

	// Use this for initialization
	void Start () 
	{
		doMenu = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Get general input
		if (Input.GetKeyDown(KeyCode.P))
		{
			doPause = true;	
		}
		
		// Paused
		if (doPause)
		{
			
			return;
		}
		
		// Menu
		if (doMenu)
		{
			SetupMenu();
			return;
		}
		
		// Game
		
		
		/*
		switch (state)
		{
			
		case GameState.Menu:
			
			if (!menuDown)
			{
				if (menu.transform.position.y <= 0)
					menuDown = true;
				else
					menu.transform.Translate(0, -MenuSpeed*Time.deltaTime, 0);
			}
			else
			{
				
			}
			
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
		*/
	}
	
	void OnGUI()
	{
		//GUI.Label(new Rect(10, 10, 200, 100), Score.ToString());	
		
	}
	
	private void SetupMenu()
	{
		if (menu != null)
			return;
		
		// Instantiate the menu object
		Instantiate(Menu, new Vector3(0,0,0), Quaternion.identity);
		
		// Get a handle to the menu game object
		menu = GameObject.FindGameObjectWithTag("menu");
		menuDown = false;
	}
	
	private void SetupGame()
	{
		
	}
}
