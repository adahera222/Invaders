using UnityEngine;
using System.Collections;

public class InvaderBulletScript : MonoBehaviour 
{

	public float BulletSpeed = -5.0f;
	public float Damage = 26.0f;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// Movement
		transform.Translate(0, BulletSpeed * Time.deltaTime, 0);
		
		// Check if the bullet is within the view frustum
		if (transform.position.y > 10 || transform.position.y < -5)
			Destroy(gameObject);
	}
	
	// Called when collision triggers
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "player")
		{
			// Apply damage to the invader
			PlayerScript playerScript = other.gameObject.GetComponent<PlayerScript>();
			playerScript.TakeDamage(Damage);
			
			// Destroy this bullet
			Destroy(gameObject);
		}
	}
}
