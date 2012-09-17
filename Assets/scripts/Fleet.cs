using UnityEngine;
using System.Collections;

public class Fleet : MonoBehaviour {
	
	public GameObject InvaderOne;
	public GameObject InvaderZero;
	
	public int InvaderCount = 0;
	public bool Attacking = false;
	
	private bool paused = false;
	
	// Use this for initialization
	void Start () 
	{
		// Spawn invaders
		for (int i=0;i<25;i++)
		{
			GameObject invader;
			if (Random.Range(-10, 10) < 0)
				invader = (GameObject)Instantiate(InvaderZero, transform.position + new Vector3(-400+i*30,0,0), Quaternion.identity);
			else
				invader = (GameObject)Instantiate(InvaderOne, transform.position + new Vector3(-400+i*30,0,0), Quaternion.identity);
			
			invader.transform.parent = gameObject.transform;
			InvaderCount++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (paused)
			return;
	}
	
	void OnFlyInAnimationDone()
	{
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
	
		public void OnPause()
	{
		paused = true;
	}
	
	public void OnResume()
	{
		paused = false;
	}
}
