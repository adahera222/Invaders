using UnityEngine;
using System.Collections;

public class InvaderScript : MonoBehaviour 
{
	public float Health = 100.0f;
	public GameObject Bullet;
	public GameObject Explosion;
	public GameObject Damage;
	public float MaxShootDelay = 10.0f;
	public float MinShootDelay = 2.0f;
	
	
	float timeSinceLastShot = 0.0f;
	float randomShootDelay;
	
	// Use this for initialization
	void Start () 
	{
		randomShootDelay = Random.Range(MinShootDelay, MaxShootDelay);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Shoot
		timeSinceLastShot += Time.deltaTime;
		if (timeSinceLastShot >= randomShootDelay)
		{
			Instantiate(Bullet, transform.position, Quaternion.identity);
			timeSinceLastShot = 0.0f;	
			randomShootDelay = Random.Range(MinShootDelay, MaxShootDelay);
		}
		
		// Test for death
		if (Health <= 0.0)
		{
			// Play death animation
			Instantiate(Explosion, transform.position, Quaternion.identity);
			
			// Play death sound
			
			// Destroy the game object
			Destroy(gameObject);
			
			// Add score
			GameManager.Score += 50;
		}
		
		// Individual movement 
		if (FleetScript.Wave >= 0 && FleetScript.InvaderCount < 5)
		{
			
		}
	}
	
	public void ApplyDamage(float amount)
	{
		Health -= amount;
		
		// Play damage animation
		Instantiate(Damage, transform.position, Quaternion.identity);
		
		// Play damage sound
		
		// Add score
		GameManager.Score += 25;
	}
}
