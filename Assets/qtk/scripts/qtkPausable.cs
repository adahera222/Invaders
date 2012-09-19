using UnityEngine;
using System.Collections;

/// <summary>
/// A quick and easy way to add pausing behavior to a MonoBehavior script. Simply
/// inherit from qtkPausable and check for 'paused' before doing an Update().
/// </summary>
public class qtkPausable : MonoBehaviour 
{
	
	public string OnPauseEventName = "OnPause";
	public string OnResumeEventName = "OnResume";
	
	public bool Paused = false;
	
	// Use this for initialization
	void Start () 
	{
		qtkEventDispatcher.GetInstance().Subscribe(OnPauseEventName, this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe(OnResumeEventName, this.gameObject);
	}
	
	void OnDestroy()
	{
		qtkEventDispatcher.GetInstance().Unsubscribe(OnPauseEventName, this.gameObject);
		qtkEventDispatcher.GetInstance().Unsubscribe(OnResumeEventName, this.gameObject);
	}
	
	public void OnPause(GameObject sender)
	{
		Paused = true;
	}
	
	public void OnResume(GameObject sender)
	{
		Paused = false;
	}
}
