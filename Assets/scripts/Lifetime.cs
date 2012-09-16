using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {
	
	public float TimeToDestroy = 2;
	
	private float timeSinceSpawn = 0;
	
	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn >= TimeToDestroy)
			Destroy(gameObject);
	}
}
