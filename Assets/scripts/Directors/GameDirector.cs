using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {

	/// <summary>
	/// The main menu prefab.
	/// </summary>
	public GameObject MainMenuPrefab;
	
	/// <summary>
	/// The pause menu prefab.
	/// </summary>
	public GameObject PauseMenuPrefab;
	
	/// <summary>
	/// The player prefab.
	/// </summary>
	public GameObject PlayerPrefab;
	
	/// <summary>
	/// The invader shaped as a zero prefab.
	/// </summary>
	public GameObject InvaderZeroPrefab;
	
	/// <summary>
	/// The invader shaped as a one prefab.
	/// </summary>
	public GameObject InvaderOnePrefab;
	
	/// <summary>
	/// The menu.
	/// </summary>
	private Menu mainMenu;
	
	/// <summary>
	/// The player.
	/// </summary>
	private Player player;
	
	/// <summary>
	/// The sound director.
	/// </summary>
	private SoundDirector soundDirector;
	
	/// <summary>
	/// Is the game paused.
	/// </summary>
	private bool paused = false;
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>
	/// The instance.
	/// </returns>
	public static GameDirector GetInstance()
	{
		GameDirector gd = (GameDirector)GameObject.FindObjectOfType(typeof(GameDirector));
		return gd;
	}
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		// Create the Menu
		Instantiate(MainMenuPrefab);
		mainMenu = (Menu)GameObject.FindObjectOfType(typeof(Menu));
		
		// Enter the main menu scene
		ShowMainMenu();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Pause();	
		}
	}
	
	public void ShowMainMenu()
	{
		// Show the menu
		mainMenu.Show();	
		
		// Show the other stuff
	}
	
	public void ShowPauseMenu()
	{
		
	}
	
	public void ShowGameScreen()
	{
		// Hide the menu
		mainMenu.Hide();
		
		// Hide the other stuff
	}
	
	/// <summary>
	/// Raises the pause event.
	/// </summary>
	public void Pause()
	{
		// Tell all game objects we are paused
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) 
		{
			go.SendMessage ("OnPause", SendMessageOptions.DontRequireReceiver);
		}	
		
		// Show the paused menu
	}
	
	/// <summary>
	/// Raises the resume event.
	/// </summary>
	public void Resume()
	{
		// Hide the paused menu
		
		// Tell all game objects we are resuming
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("OnResume", SendMessageOptions.DontRequireReceiver);
		}	
	}	
	
	/// <summary>
	/// Raises the quit event.
	/// </summary>
	public void Quit()
	{
		Application.Quit();
	}	
	
	public void NewGame()
	{

	}
	

	

	
}
