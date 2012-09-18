using UnityEngine;
using System.Collections;

public class mleDestroyer : MonoBehaviour {
	
	public float Delay;
	
	private float timeSinceSpawn = 0;
	
	// Use this for initialization
	void Start () 
	{
		timeSinceSpawn = 0;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn >= Delay)
			Destroy(this.gameObject);
	}
}
