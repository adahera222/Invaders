using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	
	public float Speed = 1200;
	public float MaxY = 800;
	public float MinY = 0;
	public float Damage = 55;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, (int)(Speed * Time.deltaTime), 0);
		
		if (transform.position.y > MaxY || transform.position.y < MinY)
			Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<InvaderController>())
		{
			other.gameObject.GetComponent<InvaderController>().OnHit(Damage);	
			Destroy(this.gameObject);
		}	
	}
}
