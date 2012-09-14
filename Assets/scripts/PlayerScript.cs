using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public float HorizontalSpeed = 10.0f;
	public float VerticalSpeed = 10.0f;
	public float HorizontalMin = -6.35f;
	public float HorizontalMax = 6.35f;
	public float VerticalMin = -3.70f;
	public float VerticalMax = 0.0f;
	public Transform Bullet;
	public float Health = 100.0f;
	public int Lives = 3;
	public GameObject Explosion;
	public GameObject Damage;
	
	// Use this for initialization
	void Start () 
	{
		Health = 100.0f;
		Lives = 3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Player movement
		float transH = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
		float transV = Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;
		transform.Translate(transH, transV, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, HorizontalMin, HorizontalMax), Mathf.Clamp(transform.position.y, VerticalMin, VerticalMax), 0);
	
		// Player shoot
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(Bullet, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
		}
		
		// Check for death
		if (Health <= 0.0f)
		{
			// Play death animation

			// Play death sound
			
			// Remove a life
			Lives -= 1;
			
			// Check for game over
			if (Lives <= 0)
			{
				
			}
			
			Health = 100.0f;
		}
	}
	
	public void ApplyDamage(float amount)
	{
		Health -= amount;
		
		// Animate damage
		Instantiate(Damage, transform.position, Quaternion.identity);
			
		// Play damage sound
	}
}
