using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvaderController : MonoBehaviour {

	public float Health;
	public GameObject Bullet;
	public GameObject HitParticles;
	public GameObject KilledParticles;
	public AudioClip HitSound;
	public AudioClip KilledSound;
	public AudioClip ShootSound;
	
	public int SpriteIDOne = 5;
	public int SpriteIDZero = 6;
	
	void Start ()
	{
		if (Random.Range(-10,10) < 0)
			GetComponent<tk2dSprite>().spriteId = SpriteIDOne;
		else
			GetComponent<tk2dSprite>().spriteId = SpriteIDZero;
		
		Health = 100.0f;
	}

	#region Events
	
	public void OnShoot()
	{
		// Play sound
		AudioSource.PlayClipAtPoint(ShootSound, transform.position);
		
		// Create a bullet
		Instantiate(Bullet, transform.position + new Vector3(0, -35, 0), Quaternion.identity);
	}
	
	public void OnHit(float amount)
	{
		// Take damage
		Health -= amount;
		
		// Play animation
		Instantiate(HitParticles, transform.position, Quaternion.identity);
		
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
		mleEventDispatcher.GetInstance().Dispatch("OnInvaderKilled", this.gameObject);
		
		// Play animation
		Instantiate(KilledParticles, transform.position, Quaternion.identity);
		
		// Play sound
		AudioSource.PlayClipAtPoint(KilledSound, transform.position);
		
		// Destroy this game object
		Destroy(this.gameObject);
	}
	
	#endregion
	
	#region Event Handlers
	
	
	
	#endregion

}