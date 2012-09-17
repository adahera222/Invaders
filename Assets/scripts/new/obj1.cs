using UnityEngine;
using System.Collections;

public class obj1 : MonoBehaviour {

	public GameObject Dispatcher;
	
	private EventDispatcher dispatcher;
	

	
	// Use this for initialization
	void Start () 
	{
		dispatcher = Dispatcher.GetComponent<EventDispatcher>();
		dispatcher.Add("OnTest", new EventDispatcher.EventHandler(OnTest));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	public void OnTest(GameObject obj)
	{
		print ("test: " + obj.GetComponent<obj2>().TestProperty);	
	}
}
