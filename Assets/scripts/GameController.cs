using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject Player;
	public GameObject Fleet;
	
	private int playerLives;
	
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		mleEventDispatcher.GetInstance().Subscribe("OnNewGame", this.gameObject);
		mleEventDispatcher.GetInstance().Subscribe("OnQuit", this.gameObject);
		mleEventDispatcher.GetInstance().Subscribe("OnResume", this.gameObject);
	}
	
	/// <summary>
	/// Update this instance.
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
		mleEventDispatcher.GetInstance().Dispatch("OnPause", this.gameObject);
	}
	
	/// <summary>
	/// The game is over.
	/// </summary>
	void GameOver()
	{
	
	}
	
	/// <summary>
	/// Spawns the player.
	/// </summary>
	void SpawnPlayer()
	{
		GameObject p = (GameObject)GameObject.FindGameObjectWithTag("TagPlayer");
		if (p) Destroy(p);
		
		Instantiate(Player);
		mleEventDispatcher.GetInstance().Subscribe("OnPlayerKilled", this.gameObject);
	}
	
	/// <summary>
	/// Spawns the fleet.
	/// </summary>
	void SpawnFleet()
	{
		GameObject f = (GameObject)GameObject.FindGameObjectWithTag("TagFleet");
		if (f) Destroy(f);
		
		Instantiate(Fleet);
		mleEventDispatcher.GetInstance().Subscribe("OnFleetKilled", this.gameObject);
	}
	
	#region Event Handlers
	
	/// <summary>
	/// Event handler for resuming the game from pause. Fired by menu.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnResume(GameObject sender)
	{
		print ("resume");
	}
	
	/// <summary>
	/// Event handler for a new game. This is most likely fired by a menu.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnNewGame(GameObject sender)
	{
		gameObject.GetComponent<AudioSource>().Stop();
		
		playerLives = 3;
		
		// Spawn the player
		SpawnPlayer();
		
		// Spawn the fleet
		SpawnFleet();
	}
	
	/// <summary>
	/// Event handler for quitting the game. THis is most likely fired by a menu.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnQuit(GameObject sender)
	{
		Application.Quit();	
	}
	
	/// <summary>
	/// Event handler for the player being killed. Fired by the player.
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
	/// Event handler for the fleet being killed, fired by the fleet.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnFleetKilled(GameObject sender)
	{
		mleEventDispatcher.GetInstance().Unsubscribe("OnFleetKilled", this.gameObject);
		SpawnFleet();
	}
	
	#endregion
	

}