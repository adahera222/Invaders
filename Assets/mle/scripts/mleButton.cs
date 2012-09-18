using UnityEngine;
using System.Collections;

public class mleButton : MonoBehaviour {
	
	/// <summary>
	/// The name of the button. This is also the name of the event that the EventDispatcher will fire.
	/// If the button name is "NewGame", the Event will be "OnNewGame".
	/// </summary>
	public string ButtonName = "NewGame";
	
	public string ButtonSprite = "newgame";
	public string ButtonOverSprite = "newgame_dn";
	
	private int btnSpriteId = -1;
	private int btnOverSpriteId = -1;
	
	private tk2dBaseSprite sprite;
	private Camera myCamera;
	
	private bool over = false;
	private bool pressed = false;
	
	// Use this for initialization
	void Start () 
	{
		// Get the sprite component
		sprite = GetComponent<tk2dBaseSprite>();
		if (!sprite)
			return;
		
		// Get the camera from the scene, must be a tk2dCamera
		myCamera = tk2dCamera.inst.camera;
		if (!myCamera)
			return;
		
		// Make sure we have a collider
		if (collider == null)
		{
			BoxCollider newCollider = gameObject.AddComponent<BoxCollider>();
			Vector3 colliderExtents = newCollider.extents;
			colliderExtents.z = 0.2f;
			newCollider.extents = colliderExtents;
		}
		
		// Get the sprite id's
		btnSpriteId = sprite.GetSpriteIdByName(ButtonSprite);
		btnOverSpriteId = sprite.GetSpriteIdByName(ButtonOverSprite);
		
		// Set the default sprite
		sprite.spriteId = btnSpriteId;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Hover
		Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (!over){
			if (collider.Raycast(ray, out hit, 1.0e8f))
			{
				sprite.spriteId = btnOverSpriteId;
				over = true;
			}
		}
		else
		{
			if (!collider.Raycast(ray, out hit, 1.0e8f))
			{
				sprite.spriteId = btnSpriteId;
				over = false;
			}
		}
		
		// Pressed
		if (over && Input.GetMouseButtonDown(0))
		{
			pressed = true;
		}
		
		// Released
		if (over && pressed && Input.GetMouseButtonUp(0))
		{
			pressed = false;
			
			mleEventDispatcher.GetInstance().Dispatch("On"+ButtonName, this.gameObject);
		}
	}
	
}
