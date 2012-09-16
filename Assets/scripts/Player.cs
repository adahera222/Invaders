using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject Bullet;
	public GameObject Explosion;
	public GameObject Damage;
	
	public AudioClip ShootSound;
	public AudioClip DamageSound;
	public AudioClip ExplodeSound;
	
	public float HorizontalSpeed = 600;
	public float VerticalSpeed = 600;
	public float HorizontalMin = 10;
	public float HorizontalMax = 790;
	public float VerticalMin = 10;
	public float VerticalMax = 300;
	public float SpawnDownTime = 1;
	
	private Transform turret;
	private float health;
	private float timeSinceSpawn = 0;
	private bool paused = false;
	
	// Use this for initialization
	void Start () 
	{
		turret = transform.GetChild(0);
		health = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (paused)
			return;
		
		// Invincible and can't move for 2 sec after spawn
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn < SpawnDownTime)
		{
			return;	
		}
		
		// Player movement
		float transH = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
		float transV = Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;
		transform.Translate((int)transH, (int)transV, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, HorizontalMin, HorizontalMax), Mathf.Clamp(transform.position.y, VerticalMin, VerticalMax), 0);
	
		// Shoot
		if (Input.GetKeyDown(KeyCode.Space))
		{
			gameObject.GetComponent<AudioSource>().clip = ShootSound;
			gameObject.GetComponent<AudioSource>().Play();
			Instantiate(Bullet, turret.position, turret.rotation);	
		}
	}
	
	public void TakeDamage(float amount)
	{
		if (timeSinceSpawn < SpawnDownTime)
			return;
		
		// Take damage
		health -= amount;
		if (health <= 0)
		{
			// Play death animation
			Instantiate(Explosion, transform.position + new Vector3(0, 25, 0), Quaternion.identity);
			
			// Play death sound
			gameObject.GetComponent<AudioSource>().clip = ExplodeSound;
			gameObject.GetComponent<AudioSource>().Play();
			
			// Tell the Game that the player has died
			GameObject.FindGameObjectWithTag("game").GetComponent<Game>().PlayerKilled();
			
			// Destroy the player 
			Destroy(gameObject);
		}
		else
		{		
			// Animate
			Instantiate(Damage, transform.position + new Vector3(0, 25, 0), Quaternion.identity);
		
			// Play sound	
			gameObject.GetComponent<AudioSource>().clip = DamageSound;
			gameObject.GetComponent<AudioSource>().Play();
		}
	}
	
	public void OnPause()
	{
		paused = true;
	}
	
	public void OnResume()
	{
		paused = false;
	}
}
