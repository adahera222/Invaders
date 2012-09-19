using UnityEngine;
using System.Collections;

public class tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		qtkEventDispatcher.GetInstance().Subscribe("OnInvaderKilled", this.gameObject);
		qtkEventDispatcher.GetInstance().Subscribe("OnFleetKilled", this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnInvaderKilled()
	{
		float a = Mathf.Sqrt(Mathf.PI);
	}
	
	void OnFleetKilled()
	{
		float b = Mathf.Sin(34.8574674f);	
	}
}
