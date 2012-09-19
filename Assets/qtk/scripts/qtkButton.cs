using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a button that dispatches an event when pressed.
/// </summary>
public class qtkButton : MonoBehaviour {
	
	/// <summary>
	/// The name of the qtkEvent that will get dispatched when the button is pressed.
	/// </summary>
	public string EventName = "OnNewGame";
	
	/// <summary>
	/// The name of the tk2Dsprite to use for the button idle state.
	/// </summary>
	public string ButtonSprite = "newgame";
	
	/// <summary>
	/// The name of the tk2Dsprite to use for the button over state.
	/// </summary>
	public string ButtonOverSprite = "newgame_dn";
	
	// Sprite Id's
	private int btnSpriteId = -1;
	private int btnOverSpriteId = -1;
	
	// The base tk2dSprite
	private tk2dBaseSprite sprite;
	
	// The camera rendering this button
	private Camera myCamera;
	
	// Keep track of button states
	private bool over = false;
	private bool pressed = false;
	
	/// <summary>
	/// Called before the first Update().
	/// </summary>
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
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
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
			
			qtkEventDispatcher.GetInstance().Dispatch(EventName, this.gameObject);
		}
	}
	
}
