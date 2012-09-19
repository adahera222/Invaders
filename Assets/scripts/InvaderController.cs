using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvaderController : MonoBehaviour {
	
	public string SpriteZeroName = "zero";
	public string SpriteOneName = "one";
	public float Health;
	public GameObject Bullet;
	public GameObject HitParticles;
	public GameObject KilledParticles;
	public AudioClip HitSound;
	public AudioClip KilledSound;
	public AudioClip ShootSound;
	
	private int spriteIdZero = -1;
	private int spriteIdOne = -1;
	
	/// <summary>
	/// Called before the first Update().
	/// </summary>
	void Start ()
	{
		// Get the sprite Id's
		spriteIdZero = GetComponent<tk2dSprite>().GetSpriteIdByName(SpriteZeroName);
		spriteIdOne = GetComponent<tk2dSprite>().GetSpriteIdByName(SpriteOneName);
		
		// Randomize the sprite
		if (Random.Range(-10,10) < 0)
			GetComponent<tk2dSprite>().spriteId = spriteIdZero;
		else
			GetComponent<tk2dSprite>().spriteId = spriteIdOne;
		
		Health = 100.0f;
	}
	
	/// <summary>
	/// Fire the weapon.
	/// </summary>
	public void Shoot()
	{
		// Play sound
		AudioSource.PlayClipAtPoint(ShootSound, transform.position);
		
		// Create a bullet
		Instantiate(Bullet, transform.position + new Vector3(0, -35, 0), Quaternion.identity);
	}
	
	/// <summary>
	/// Called when the invader is hit.
	/// </summary>
	/// <param name='amount'>
	/// Amount.
	/// </param>
	public void Hit(float amount)
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
			Killed();
		}		
	}
	
	/// <summary>
	/// Called when the invader is killed.
	/// </summary>
	public void Killed()
	{
		// Broadcast event
		qtkEventDispatcher.GetInstance().Dispatch("OnInvaderKilled", this.gameObject);
		
		// Play animation
		Instantiate(KilledParticles, transform.position, Quaternion.identity);
		
		// Play sound
		AudioSource.PlayClipAtPoint(KilledSound, transform.position);
		
		// Destroy this game object
		Destroy(this.gameObject);
	}

}