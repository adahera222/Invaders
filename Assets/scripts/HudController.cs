using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HudController : MonoBehaviour {

	void Start ()
	{
		// Player hit events
		mleEventDispatcher.GetInstance().Subscribe("OnPlayerHit", this.gameObject);
		
	
	}
	
	void Update ()
	{

	}
	
	void OnDestroy()
	{
		mleEventDispatcher.GetInstance().Unsubscribe("OnPlayerHit", this.gameObject);	
	}
	
	#region Events
	
	
	
	#endregion
	
	#region Event Handlers
	
	public void OnPlayerHit(GameObject sender)
	{
		print ("player health: " + sender.GetComponent<PlayerController>().Health.ToString());
	}
	
	#endregion
	
}