using UnityEngine;
using System.Collections;

public class obj2 : MonoBehaviour {
	
	public GameObject Dispatcher;
	
	private EventDispatcher dispatcher;
	
		public string TestProperty
	{
		get {return "hello";}	
	}
	
	// Use this for initialization
	void Start () 
	{
		dispatcher = Dispatcher.GetComponent<EventDispatcher>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		dispatcher.Broadcast("OnTest", this.gameObject);
	}
}
