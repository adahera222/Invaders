using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public GameObject BulletHitExplosion;
	public float BulletSpeed = 1200;
	public float Damage = 25;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Move the bullet
		transform.Translate(0, (int)(BulletSpeed * Time.deltaTime), 0);
		
		// Destroy the bullet if it goes out of bounds
		if (transform.position.y < -10 || transform.position.y > 700)
		{
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		// Check who we collided with
		if (other.GetComponent<Invader>())
			other.GetComponent<Invader>().TakeDamage(Damage);
		else if (other.GetComponent<Player>())
			other.GetComponent<Player>().TakeDamage(Damage);
		else
		{
			// Play 2 bullet collide animation
			Instantiate(BulletHitExplosion, transform.position, Quaternion.identity);
			
			// Play 2 bullets collide sound
			
		}
		
		Destroy(gameObject);
	}
}
