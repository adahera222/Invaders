using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	
	//public GameObject Bullet;
	public float Speed = 100;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Show()
	{
		GetComponent<Animation>().Play("TitleIn");
	}
	
	public void Hide()
	{
		transform.Translate(0, 500, 0);
	}
	
}
