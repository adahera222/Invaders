using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	
	public float Speed = 1200;
	public float MaxY = 800;
	public float MinY = 0;
	public float Damage = 55;
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update () 
	{
		// Move the bullet
		transform.Translate(0, (int)(Speed * Time.deltaTime), 0);
		
		// Destroy it if out of bounds
		if (transform.position.y > MaxY || transform.position.y < MinY)
			Destroy(this.gameObject);
	}
	
	/// <summary>
	/// Called when the Collider collides with another.
	/// </summary>
	/// <param name='other'>
	/// Other.
	/// </param>
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<InvaderController>())
		{
			other.gameObject.GetComponent<InvaderController>().Hit(Damage);	
			Destroy(this.gameObject);
		}	
	}
}
