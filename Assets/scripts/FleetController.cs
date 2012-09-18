using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetController : MonoBehaviour {

	public float Speed;
	public GameObject Invader;
	
	private int invaderCount;
	
	void Start ()
	{
		// spawn invader
		GameObject go = (GameObject)Instantiate(Invader, transform.position + new Vector3(0,0,0), Quaternion.identity);
		go.transform.parent = transform;
		
		// register with killed event
		mleEventDispatcher.GetInstance().Subscribe("OnInvaderKilled", this.gameObject);
	}
	
	void Update ()
	{

	}
	
	void OnDestroy()
	{
		//EventDispatcher.GetInstance().Unsubscribe("OnInvaderKilled", this.gameObject);	
	}
	
	#region Events
	
	public void OnKilled()
	{
		// Broadcast event
		mleEventDispatcher.GetInstance().Dispatch("OnFleetKilled", this.gameObject);
		
		// Destroy this game object
		Destroy(this.gameObject);
	}
	
	#endregion
	
	#region Event Handlers
	
	public void OnInvaderKilled(GameObject sender)
	{
		if (--invaderCount <= 0)
		{
			OnKilled();
		}
	}
	
	#endregion
	
}