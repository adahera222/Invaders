using UnityEngine;
using System.Collections;

public class Invader : MonoBehaviour {
	
	public GameObject Bullet;
	public GameObject Explosion;
	public GameObject Damage;
	
	public float MaxTimeBetweenShots = 5;
	public float MinTimeBetweenShots = 1;
	public float MinTurrentAngle = -2;
	public float MaxTurrentAngle = 2;
	public float InitialShotDelay = 2;
	
	private float timeUntilNextShot = 5;
	private float timeSinceLastShot = 0;
	
	private Transform turret;
	private float health = 100;
	
	// Use this for initialization
	void Start () 
	{
		turret = transform.GetChild(0);
		timeUntilNextShot = Random.Range(MinTimeBetweenShots, MaxTimeBetweenShots) + InitialShotDelay;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Shoot
		if (timeSinceLastShot >= timeUntilNextShot)
		{
			// Randomize the turrent angle
			//turret.Rotate(0, 0, Random.Range(MinTurrentAngle, MaxTurrentAngle));
			
			// Fire a bullet
			Instantiate(Bullet, turret.position, turret.rotation);
			timeUntilNextShot = Random.Range(MinTimeBetweenShots, MaxTimeBetweenShots);
			timeSinceLastShot = 0;		
		}
		else
		{
			timeSinceLastShot += Time.deltaTime;
		}
	}
	
	public void TakeDamage(float amount)
	{
		// Take damage
		health -= amount;
		if (health <= 0)
		{
			// Play death animation
			Instantiate(Explosion, transform.position, Quaternion.identity);
			
			// Play death sound
			
			// Tell the Fleet that this invader has died
			GameObject.FindGameObjectWithTag("fleet").GetComponent<Fleet>().InvaderKilled();
			
			// Destroy the player 
			Destroy(gameObject);
		}
		else
		{
			// Play damage animation
			Instantiate(Damage, transform.position, Quaternion.identity);
			
			// Play damage sound
			
		}
	}
	
}
