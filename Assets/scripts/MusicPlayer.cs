using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	public AudioClip Channel1;
	public AudioClip Channel2;
	
	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<AudioSource>().clip = Channel1;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void Play(int channel)
	{
		if (channel == 1)
		{
			gameObject.GetComponent<AudioSource>().Stop();	
			gameObject.GetComponent<AudioSource>().clip = Channel1;	
			gameObject.GetComponent<AudioSource>().Play();	
		}
		else
		{
			gameObject.GetComponent<AudioSource>().Stop();	
			gameObject.GetComponent<AudioSource>().clip = Channel2;	
			gameObject.GetComponent<AudioSource>().Play();	
		}
	}
	
	public void Stop()
	{
		gameObject.GetComponent<AudioSource>().Stop();
	}
}
