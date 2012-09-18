using UnityEngine;
using System.Collections;

public class InvaderBullet : MonoBehaviour {

	public float Speed = 200;
	public float MaxY = 800;
	public float MinY = -10;
	public float Damage = 26;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, (int)(-Speed * Time.deltaTime), 0);
		
		if (transform.position.y > MaxY || transform.position.y < MinY)
			Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PlayerController>())
		{
			other.gameObject.GetComponent<PlayerController>().OnHit(Damage);	
			Destroy(this.gameObject);
		}
	}
}
