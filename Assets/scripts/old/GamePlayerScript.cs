using UnityEngine;
using System.Collections;

public class GamePlayerScript : MonoBehaviour {
	
	public GameObject Bullet;
	public GameObject Damage;
	public GameObject Explosion;
	
	public float Health;
	
	// Use this for initialization
	void Start () 
	{
		Health = 100.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void TakeDamage(float amount)
	{
		Instantiate(Damage, transform.position, Quaternion.identity);
		Health -= amount;	
	}
	
	public void Kill()
	{
		Instantiate(Explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
