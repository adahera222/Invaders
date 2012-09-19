using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Quick and easy event dispatching. This script can be attached to an Empty GameObject
/// and added to the scene to provide a simple to use, fast means of sending messages 
/// from one GameObject to another.
/// 
/// Example:
/// GameObject scoreKeeper needs to know when GameObject enemy is killed so it can increase the score:
/// 
/// in scoreKeeper.cs
/// ...
/// qtkEventDispatcher.GetInstance().Subscribe("OnEnemyKilled", this.gameObject);
/// ...
/// void OnEnemyKilled(GameObject sender)
/// {
///		print ("enemy killed");
/// }
/// 
/// in enemy.cs
/// ...
/// void OnKilled()
/// {
/// 	qtkEventDispatcher.GetInstance().Dispatch("OnEnemyKilled", this.gameObject);
/// }
/// 
/// </summary>
public class qtkEventDispatcher : MonoBehaviour 
{
	
	/// <summary>
	/// A dictionary of message names and their owners.
	/// </summary>
	private Dictionary<string, List<GameObject>> handlers;
	
	/// <summary>
	/// Keep track of a single instance of this object.
	/// </summary>
	private static qtkEventDispatcher instance = null;
	public static qtkEventDispatcher GetInstance()
	{
		if (instance == null)
		{
			instance = (qtkEventDispatcher)FindObjectOfType(typeof(qtkEventDispatcher));	
		}
		return instance;
	}
	
	/// <summary>
	/// Runs when the object is being loaded.
	/// </summary>
	void Awake()
	{
		instance = this;
		handlers = new Dictionary<string, List<GameObject>>();
	}
	
	/// <summary>
	/// Runs when the object is destroyed.
	/// </summary>
	void OnDestroy()
	{
		//instance = null;
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
			foreach(GameObject go in handlers[message])
			{
				if (go != null)
				{
					//print ("qtkEventDispatcher: dispatched " + message + " to " + go.name);
					go.SendMessage(message, sender, SendMessageOptions.DontRequireReceiver);	
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
			//print (subscriber + " unsubscribed from " + message);
		}

	}

}