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
	
	private Transform turret;
	
	// Use this for initialization
	void Start () 
	{
		turret = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Player movement
		float transH = Input.GetAxis("Horizontal") * HorizontalSpeed * Time.deltaTime;
		float transV = Input.GetAxis("Vertical") * VerticalSpeed * Time.deltaTime;
		transform.Translate((int)transH, (int)transV, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, HorizontalMin, HorizontalMax), Mathf.Clamp(transform.position.y, VerticalMin, VerticalMax), 0);
	
		// Shoot
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(Bullet, turret.position, Quaternion.identity);	
		}
	}
}
