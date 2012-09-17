using UnityEngine;
using System.Collections;

public class SoundDirector : MonoBehaviour {
	
	public static SoundDirector GetInstance()
	{
		SoundDirector sd = (SoundDirector)GameObject.FindObjectOfType(typeof(SoundDirector));
		return sd;
	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
