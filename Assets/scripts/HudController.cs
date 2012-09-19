using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HudController : MonoBehaviour 
{
	
	/// <summary>
	/// Called before the first Update().
	/// </summary>
	void Start ()
	{
		// Subscribe to events
		qtkEventDispatcher.GetInstance().Subscribe("OnPlayerHit", this.gameObject);
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{

	}
	
	#region Event Handlers
	
	/// <summary>
	/// Called when the "OnPlayerHit" event is dispatched.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnPlayerHit(GameObject sender)
	{
		print ("player health: " + sender.GetComponent<PlayerController>().Health.ToString());
	}
	
	#endregion
	
}