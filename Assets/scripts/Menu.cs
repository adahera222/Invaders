using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () 
	{
		qtkEventDispatcher.GetInstance().Subscribe("OnNewGame", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnPause", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnResume", this.gameObject);
	}
	
	public void OnNewGame(GameObject sender)
	{
		animation.Play("MenuOut");
	}
	
	public void OnPause(GameObject sender)
	{
		transform.Find("btnResume").gameObject.active = true;
		animation.Play("MenuIn");	
	}
	
	public void OnResume(GameObject sender)
	{
		animation.Play("MenuOut");
	}
	
}
