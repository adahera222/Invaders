using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetController : MonoBehaviour {

	public float Speed;
	public GameObject Invader;
	
	private int invaderCount;
	
	/// <summary>
	/// Called before the first Update().
	/// </summary>
	void Start ()
	{
		// spawn invader
		GameObject go = (GameObject)Instantiate(Invader, transform.position + new Vector3(0,0,0), Quaternion.identity);
		go.transform.parent = transform;
		
		// Subscribe to invader killed event
		qtkEventDispatcher.GetInstance().Subscribe("OnInvaderKilled", this.gameObject);
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		// Move the fleet
	}
	
	/// <summary>
	/// Called when the fleet is killed.
	/// </summary>
	public void Killed()
	{
		// Broadcast event
		qtkEventDispatcher.GetInstance().Dispatch("OnFleetKilled", this.gameObject);
		
		// Destroy this game object
		Destroy(this.gameObject);
	}
	
	#region Event Handlers
	
	/// <summary>
	/// Called when the "OnInvaderKilled" event is dispatched.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void OnInvaderKilled(GameObject sender)
	{
		if (--invaderCount <= 0)
		{
			Killed();
		}
	}
	
	#endregion
	
}