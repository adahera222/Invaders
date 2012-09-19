using UnityEngine;
using System.Collections;

public class InvaderBullet : MonoBehaviour 
{

	public float Speed = 200;
	public float MaxY = 800;
	public float MinY = -10;
	public float Damage = 26;
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update () 
	{
		if (GetComponent<qtkPausable>().Paused)
			return;
		
		// Move the bullet
		transform.Translate(0, (int)(-Speed * Time.deltaTime), 0);
		
		// Destroy it if out of bounds
		if (transform.position.y > MaxY || transform.position.y < MinY)
			Destroy(this.gameObject);
	}
	
	/// <summary>
	/// Called when this Collider collides with another.
	/// </summary>
	/// <param name='other'>
	/// Other.
	/// </param>
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerController>())
		{
			other.gameObject.GetComponent<PlayerController>().Hit(Damage);	
			Destroy(this.gameObject);
		}
	}
}
