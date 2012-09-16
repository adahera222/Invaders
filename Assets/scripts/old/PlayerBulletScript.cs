using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {
	
	public float BulletSpeed = 10.0f;
	public float Damage = 52.0f;
	
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
		if (transform.position.y > 15 || transform.position.y < -15)
			Destroy(gameObject);
	}
	
	// Called when collision triggers
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "invader")
		{
			// Apply damage to the invader
			InvaderScript invaderScript = other.gameObject.GetComponent<InvaderScript>();
			invaderScript.ApplyDamage(Damage);
			
			// Destroy this bullet
			Destroy(gameObject);
		}
	}
}
