using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject Bullet;
	
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
	
	// Use this for initialization
	void Start () 
	{
		turret = transform.GetChild(0);
		health = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
			Instantiate(Bullet, turret.position, turret.rotation);	
		}
	}
	
	public void TakeDamage(float amount)
	{
		if (timeSinceSpawn < SpawnDownTime)
			return;
		
		// Animate
		
		// Play sound
		
		// Take damage
		health -= amount;
		if (health <= 0)
		{
			print ("player killed");
			// Play death animation
			
			// Play death sound
			
			// Tell the Game that the player has died
			GameObject.FindGameObjectWithTag("game").GetComponent<Game>().PlayerKilled();
			
			// Destroy the player 
			Destroy(gameObject);
		}
	}
}
