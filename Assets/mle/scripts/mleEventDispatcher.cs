using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mleEventDispatcher : MonoBehaviour {
	
	/// <summary>
	/// A dictionary of message names and their owners.
	/// </summary>
	private Dictionary<string, List<GameObject>> handlers;
	
	/// <summary>
	/// Keep track of a single instance of this object.
	/// </summary>
	private static mleEventDispatcher instance = null;
	public static mleEventDispatcher GetInstance()
	{
		if (instance == null)
		{
			instance = (mleEventDispatcher)FindObjectOfType(typeof(mleEventDispatcher));	
		}
		return instance;
	}
	
	/// <summary>
	/// Runs when awake.
	/// </summary>
	void Awake()
	{
		if (instance != null)
		{
			
		}
		
		instance = this;
		
		handlers = new Dictionary<string, List<GameObject>>();
	}
	
	/// <summary>
	/// Runs when the object is destroyed.
	/// </summary>
	void OnDestroy()
	{
		instance = null;
	}
	
	/// <summary>
	/// Dispatch the specified message to all subscribers.
	/// </summary>
	/// <param name='message'>
	/// Message.
	/// </param>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	public void Dispatch(string message, GameObject sender)
	{
		if (handlers.ContainsKey(message))
		{
			for (int i = 0; i < handlers[message].Count; i++)
			{
				if (handlers[message][i] == null)
				{
					// Remove any subscribers that are now null
					handlers[message].RemoveAt(i);
				}
				else
				{
					// Send the message
					handlers[message][i].SendMessage(message, sender);	
				}
			}
		}
	}
	
	/// <summary>
	/// Subscribe to the specified message.
	/// </summary>
	/// <param name='message'>
	/// Message.
	/// </param>
	/// <param name='subscriber'>
	/// Subscriber.
	/// </param>
	public void Subscribe(string message, GameObject subscriber)
	{
		if (!handlers.ContainsKey(message))
		{
			handlers.Add(message, new List<GameObject>());	
		}
		handlers[message].Insert(0, subscriber);
	}
	
	/// <summary>
	/// Unsubscribe from the specified message.
	/// </summary>
	/// <param name='message'>
	/// Message.
	/// </param>
	/// <param name='subscriber'>
	/// Subscriber.
	/// </param>
	public void Unsubscribe(string message, GameObject subscriber)
	{
		if (handlers.ContainsKey(message))
		{
			handlers[message].Remove(subscriber);
			if (handlers[message].Count <= 0)
			{
				handlers.Remove(message);	
			}
		}
	}

}