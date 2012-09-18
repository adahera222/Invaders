using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public float Health;
	public float Speed;
	public float HorizontalSpeed = 600;
	public float VerticalSpeed = 600;
	public float HorizontalMin = 10;
	public float HorizontalMax = 790;
	public float VerticalMin = 10;
	public float VerticalMax = 300;
	public float BulletOffsetY = 25;
	public GameObject Bullet;
	public GameObject HitParticles;
	public GameObject KilledParticles;
	public AudioClip HitSound;
	public AudioClip KilledSound;
	public AudioClip ShootSound;
	
	void Start ()
	{
		Health = 100.0f;
	}
	
	void Update ()
	{
		// Movement
		float transH = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
		float transV = Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;
		transform.Translate((int)transH, (int)transV, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, HorizontalMin, HorizontalMax), Mathf.Clamp(transform.position.y, VerticalMin, VerticalMax), 0);
	
		// Shooting
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnShoot();
		}
	}
	
	#region Events
	
	public void OnShoot()
	{
		// Play sound
		AudioSource.PlayClipAtPoint(ShootSound, transform.position);
		
		// Create a bullet
		Instantiate(Bullet, transform.position + new Vector3(0, BulletOffsetY, 0), Quaternion.identity);
	}
	
	public void OnHit(float amount)
	{
		// Take damage
		Health -= amount;
		
		// Broadcast event
		mleEventDispatcher.GetInstance().Dispatch("OnPlayerHit", this.gameObject);
		
		// Play animation
		Instantiate(HitParticles, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
		
		// Play sound
		AudioSource.PlayClipAtPoint(HitSound, transform.position);
		
		// Check if killed
		if (Health <= 0)
		{
			OnKilled();
		}		
	}
	
	public void OnKilled()
	{
		// Broadcast event
		mleEventDispatcher.GetInstance().Dispatch("OnPlayerKilled", this.gameObject);
		
		// Play animation
		Instantiate(KilledParticles, transform.position + new Vector3(0, 15, 0), Quaternion.identity);
		
		// Play sound
		AudioSource.PlayClipAtPoint(KilledSound, transform.position);
		
		// Destroy this game object
		Destroy(this.gameObject);
	}
	
	#endregion
	
	#region Event Handlers
	
	
	
	#endregion

}