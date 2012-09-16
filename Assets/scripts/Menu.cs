using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.RightBracket))
		{
			Hide ();	
		}
		if (Input.GetKeyDown(KeyCode.LeftBracket))
		{
			Show ();	
		}
	}
	
	public void Show()
	{
		GetComponent<Animation>().Play("MenuAnimationIn");	
	}
	
	public void Hide()
	{
		GetComponent<Animation>().Play("MenuAnimationOut");	
	}
}
