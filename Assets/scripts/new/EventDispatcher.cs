using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventDispatcher : MonoBehaviour {
	
	public delegate void EventHandler(GameObject obj);
	
	private Dictionary<string, List<EventHandler>> handlers;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void Add(string evnt, EventHandler handler)
	{
		if (handlers == null)
			handlers = new Dictionary<string, List<EventHandler>>();
		
		if (handlers.ContainsKey(evnt))
		{
			handlers[evnt].Add(handler);	
		}
		else
		{
			handlers.Add(evnt, new List<EventHandler>());
			handlers[evnt].Add(handler);
		}
	}
	
	public void Broadcast(string evnt, GameObject obj)
	{
		if (handlers.ContainsKey(evnt))
		{
			foreach (EventHandler handler in handlers[evnt])
			{
				handler(obj);	
			}
		}
	}
	

}
