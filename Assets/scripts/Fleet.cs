using UnityEngine;
using System.Collections;

public class Fleet : MonoBehaviour {
	
	public GameObject InvaderOne;
	public GameObject InvaderZero;
	
	public int InvaderCount = 0;
	public bool Attacking = false;
	
	// Use this for initialization
	void Start () 
	{
		// Spawn invaders
		GameObject invader = (GameObject)Instantiate(InvaderZero, transform.position, Quaternion.identity);
		invader.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnFlyInAnimationDone()
	{
		print ("fly in done");
		Attacking = true;
	}
	
	public void InvaderKilled()
	{
		InvaderCount--;
		if (InvaderCount <= 0)
		{
			// Tell the game that the fleed was killed
			GameObject.FindGameObjectWithTag("game").GetComponent<Game>().FleetKilled();
		}
	}
}
