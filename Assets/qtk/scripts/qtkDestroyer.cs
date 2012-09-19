using UnityEngine;
using System.Collections;

/// <summary>
/// Attach this script to any game object in order to destroy it based on some settings.
/// </summary>
public class qtkDestroyer : MonoBehaviour {
	
	/// <summary>
	/// Destroys the game object after this delay.
	/// </summary>
	public float Delay;
	
	private float timeSinceSpawn = 0;
	
	/// <summary>
	/// Called before the first Update().
	/// </summary>
	void Start () 
	{
		timeSinceSpawn = 0;	
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update () 
	{
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn >= Delay)
			Destroy(this.gameObject);
	}
}
