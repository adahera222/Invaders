using UnityEngine;
using System.Collections;

public class Invader : MonoBehaviour {
	
	public GameObject Bullet;
	
	public float MaxTimeBetweenShots = 5;
	public float MinTimeBetweenShots = 1;
	
	private float timeUntilNextShot = 5;
	private float timeSinceLastShot = 0;
	
	private Transform turret;
	
	// Use this for initialization
	void Start () 
	{
		turret = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Shoot
		if (timeSinceLastShot >= timeUntilNextShot)
		{
			Instantiate(Bullet, turret.position, turret.rotation);
			timeUntilNextShot = Random.Range(MinTimeBetweenShots, MaxTimeBetweenShots);
			timeSinceLastShot = 0;		
		}
		else
		{
			timeSinceLastShot += Time.deltaTime;
		}
	}
}
