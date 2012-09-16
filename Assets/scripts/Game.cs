using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public GameObject Fleet;
	public GameObject Player;
	
	
	public float FleetSpeed = 100.0f;
	public int Wave = 0;
	
	private bool playing = false;
	private GameObject fleet;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// Handle pause
		if (Input.GetKeyDown(KeyCode.P))
		{
			playing = false;
			GameObject.FindGameObjectWithTag("menu").GetComponent<Menu>().Show();
		}
		
		// Check for pause
		if (!playing)
			return;
		
		// Move the fleet if it is attacking
		if (fleet.GetComponent<Fleet>().Attacking)
		{
			if (fleet.transform.position.x >= 790)
				FleetSpeed *= -1;
			if (fleet.transform.position.x <= 10)
				FleetSpeed *= -1;
			
			// We truncate to integer to make pixel art sprites render nicely
			fleet.transform.Translate((int)(FleetSpeed * Time.deltaTime), 0, 0);
		}
	}
	
	public void NewGamePressed()
	{
		print ("new game");	
		
		// Hide the menu
		GameObject.FindGameObjectWithTag("menu").GetComponent<Menu>().Hide();
		
		// Spawn the first wave
		SpawnFleet();
		
		playing = true;
	}
	
	public void QuitPressed()
	{
		print ("quit");
		Application.Quit();
	}
	
	private void SpawnFleet()
	{
		Wave++;
		
		// Destroy the current fleet object
		Destroy(GameObject.FindGameObjectWithTag("fleet"));
		
		// Instantiate a new fleet way off screen
		fleet = (GameObject)Instantiate(Fleet);
	}
	

}
