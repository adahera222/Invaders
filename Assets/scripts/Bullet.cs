using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float BulletSpeed = 1200;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, (int)(BulletSpeed * Time.deltaTime), 0);
		
		// Destroy the bullet if it goes out of bounds
		if (transform.position.y < -10 || transform.position.y > 700)
		{
			Destroy(gameObject);
		}
	}
}
