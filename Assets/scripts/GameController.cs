using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject Player;
	public GameObject Fleet;
	
	public float MusicVolumeInMenu = .5f;
	public float MusicVolumeInGame = .15f;
	
	private int playerLives;
	
	
	/// <summary>
	/// Called before the first Update().
	/// </summary>
	void Start ()
	{
		// Set the music volume
		GetComponent<AudioSource>().volume = MusicVolumeInMenu;
		
		// Register with events
		qtkEventDispatcher.GetInstance().Subscribe("OnNewGame", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnQuit", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnResume", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnPlayerKilled", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnFleetKilled", this.gameObject);
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P))
			Pause();
	}
	
	/// <summary>
	/// Pause the game.
	/// </summary>
	void Pause()
	{
		GetComponent<AudioSource>().volume = MusicVolumeInMenu;
		qtkEventDispatcher.GetInstance().Dispatch("OnPause", this.gameObject);
	}
	
	/// <summary>
	/// The game is over.
	/// </summary>
	void GameOver()
	{
	
	}
	
	/// <summary>
	/// Spawn the player.
	/// </summary>
	void SpawnPlayer()
	{
		GameObject p = (GameObject)GameObject.FindGameObjectWithTag("TagPlayer");
		if (p) Destroy(p);
		
		Instantiate(Player);
	}
	
	/// <summary>
	/// Spawn the fleet.
	/// </summary>
	void SpawnFleet()
	{
		GameObject f = (GameObject)GameObject.FindGameObjectWithTag("TagFleet");
		if (f) Destroy(f);
		
		Instantiate(Fleet);
	}
	
	#region Event Handlers
	
	/// <summary>
	/// Event handler for resuming the game from pause.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnResume(GameObject sender)
	{
		GetComponent<AudioSource>().volume = MusicVolumeInGame;
		print ("resume");
	}
	
	/// <summary>
	/// Event handler for a new game.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnNewGame(GameObject sender)
	{
		GetComponent<AudioSource>().volume = MusicVolumeInGame;
		
		playerLives = 3;
		
		// Spawn the player
		SpawnPlayer();
		
		// Spawn the fleet
		SpawnFleet();
	}
	
	/// <summary>
	/// Event handler for quitting the game.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnQuit(GameObject sender)
	{
		Application.Quit();	
	}
	
	/// <summary>
	/// Event handler for the player being killed.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnPlayerKilled(GameObject sender)
	{
		if (--playerLives <= 0)
		{
			GameOver();
		}
	}
	
	/// <summary>
	/// Event handler for the fleet being killed.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnFleetKilled(GameObject sender)
	{
		SpawnFleet();
	}
	
	#endregion
	

}