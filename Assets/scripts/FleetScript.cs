using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleetScript : MonoBehaviour {
	
	public GameObject Invader;
	public int NumberOfInvaders = 10;
	public float InvaderSpacing = .75f;
	public float FleetSpeed = 1.0f;
	public static bool IsAlive = true;
	public static int Wave = 0;
	public static int InvaderCount = 0;
	
	// Use this for initialization
	void Start () 
	{		
		FleetSpeed = 1.0f;
		
		switch (Wave)
		{
		case 0:
			for (int i=0;i<NumberOfInvaders;i++)
			{
				GameObject go = (GameObject)Instantiate(Invader, transform.position + new Vector3(-NumberOfInvaders * InvaderSpacing / 2 + InvaderSpacing * i, 0, 0), Quaternion.identity);
				go.transform.parent = transform;
				InvaderCount++;
			}
			break;
			
		default:
			for (int i=0;i<10;i++)
			{
				for (int j=0;j<2;j++)
				{
					GameObject go = (GameObject)Instantiate(Invader, transform.position + new Vector3(-NumberOfInvaders * InvaderSpacing / 2 + InvaderSpacing * i, -j * .75f, 0), Quaternion.identity);
					go.transform.parent = transform;
					InvaderCount++;
				}
			}
			break;
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (transform.position.y > 3)
		{
			// MOve in from top
			transform.Translate(0, -4.0f * Time.deltaTime, 0);	
		}
		else
		{
			// Move side to side
			transform.Translate(FleetSpeed * Time.deltaTime, 0, 0);	
			if (transform.position.x > 3 && FleetSpeed > 0)
				FleetSpeed *= -1;
			else if (transform.position.x < -3 && FleetSpeed < 0)
				FleetSpeed *= -1;
		}
		
		// Check for all invaders killed
		if (gameObject.transform.childCount <= 0)
		{
			IsAlive = false;
			Destroy(gameObject);
			InvaderCount--;
		}
	}
}
