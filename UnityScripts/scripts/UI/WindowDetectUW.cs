﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WindowDetectUW : WindowDetect {
	
	/// <summary>
	/// Is the game using experimental room manager code.
	/// </summary>
	public static bool UsingRoomManager =false;	
	
	public override void Start ()
	{
		base.Start ();
		JustClicked=false;
		WindowWaitCount=0;
	}

	/// <summary>
	/// Cancel all click input for a few seconds.
	/// </summary>
	/// <param name="waitTime">Wait time.</param>
	public void UWWindowWait(float waitTime)
	{
		JustClicked=true;//Prevent catching something I have just thrown.
		WindowWaitCount=waitTime;
	}


		/// <summary>
		/// General Combat UI interface. Controls attack charging
		/// </summary>
	void Update ()
	{
		if (GameWorldController.instance.playerUW.isRoaming==true)
		{//No inventory use while using wizard eye spell
				return;
		}
		if (JustClicked==true)
		{//Wait until the timer has gone down before allowing further clicks
			WindowWaitCount=WindowWaitCount-Time.deltaTime;
			if (WindowWaitCount<=0)
			{
					JustClicked=false;
			}
			return;
		}

		//Choose what actions to take.
		switch (UWCharacter.InteractionMode)
		{
			case UWCharacter.InteractionModeAttack:
			{
				if (GameWorldController.instance.playerUW.PlayerMagic.ReadiedSpell!="")								
				{//Player has spell to fire off first
						return;
				}
				if (GameWorldController.instance.playerUW.PlayerCombat.AttackExecuting==true)
				{//No attacks can be started while executing the last one.
					return;
				}
				if  ((WindowDetectUW.CursorInMainWindow==false))
					{
					MouseHeldDown=false;
					GameWorldController.instance.playerUW.PlayerCombat.AttackCharging=false;
					}
				if ((MouseHeldDown==true)  )
				{
					if(GameWorldController.instance.playerUW.PlayerCombat.AttackCharging==false)
					{//Begin the attack
						GameWorldController.instance.playerUW.PlayerCombat.CombatBegin();
					}
					if ((GameWorldController.instance.playerUW.PlayerCombat.AttackCharging==true) && (GameWorldController.instance.playerUW.PlayerCombat.Charge<100))
					{//While still charging increase the charge by the charge rate.
						GameWorldController.instance.playerUW.PlayerCombat.CombatCharging ();
					}
					return;
				}
				else if (GameWorldController.instance.playerUW.PlayerCombat.AttackCharging==true)
				{
					//Player has been building an attack up and has released it.
					GameWorldController.instance.playerUW.PlayerCombat.ReleaseAttack();
				}
				break;
			}
			default:
			{
				break;
			}
		}
	}

		/// <summary>
		/// Detects if the mouse if over the window
		/// </summary>
	public void OnMouseEnter()
	{				
		CursorInMainWindow=true;
	}

		/// <summary>
		/// Detects if the mouse has left the window.
		/// </summary>
	public void OnMouseExit()
	{				
		CursorInMainWindow=false;
	}


		/// <summary>
		/// Raises the mouse down event.
		/// </summary>
		/// <param name="evnt">Evnt.</param>
	public void OnMouseDown(BaseEventData evnt)
	{
			PointerEventData pntr = (PointerEventData)evnt;
			OnPress(true,pntr.pointerId);
	}

		/// <summary>
		/// Releases the mouse up event.
		/// </summary>
		/// <param name="evnt">Evnt.</param>
	public void OnMouseUp(BaseEventData evnt)
	{
			PointerEventData pntr = (PointerEventData)evnt;
			OnPress(false,pntr.pointerId);
	}

		/*public void OnHover ()
		{
				//base.OnHover (isOver);

				if(! CursorInMainWindow )
				{
						GameWorldController.instance.playerUW.PlayerCombat.AttackCharging=false;
						GameWorldController.instance.playerUW.PlayerCombat.Charge=0;
						if (UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack)
						{
								UWHUD.instance.wpa.SetAnimation= GameWorldController.instance.playerUW.PlayerCombat.GetWeapon () +"_Ready_" + GameWorldController.instance.playerUW.PlayerCombat.GetRace () + "_" + GameWorldController.instance.playerUW.PlayerCombat.GetHand();
						}
						else
						{
								UWHUD.instance.wpa.SetAnimation= "WeaponPutAway";
						}
				}
		}*/

/*	protected override void OnHover (bool isOver)
	{
		base.OnHover (isOver);

		if(! isOver )
		{
			GameWorldController.instance.playerUW.PlayerCombat.AttackCharging=false;
			GameWorldController.instance.playerUW.PlayerCombat.Charge=0;
			if (UWCharacter.InteractionMode==UWCharacter.InteractionModeAttack)
			{
				UWHUD.instance.wpa.SetAnimation= GameWorldController.instance.playerUW.PlayerCombat.GetWeapon () +"_Ready_" + GameWorldController.instance.playerUW.PlayerCombat.GetRace () + "_" + GameWorldController.instance.playerUW.PlayerCombat.GetHand();
			}
			else
			{
				UWHUD.instance.wpa.SetAnimation= "WeaponPutAway";
			}
		}
	}*/

	protected override void OnPress (bool isPressed, int PtrID)
	{
		if (GameWorldController.instance.playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}
		base.OnPress(isPressed,PtrID);
		if(CursorInMainWindow==false)
		{
			return;
		}
		if (JustClicked==true)
		{
			return;
		}
		switch (UWCharacter.InteractionMode)
		{
			case UWCharacter.InteractionModePickup:
				ClickEvent(PtrID);
				break;
			default:
				break;
		}
	}

		public void OnClick(BaseEventData evnt)
		{
			PointerEventData pntr = (PointerEventData)evnt;
			OnClick(pntr.pointerId);
		}


	public void OnClick(int ptrID)
	{
		if (GameWorldController.instance.playerUW.isRoaming==true)
		{//No inventory use while using wizard eye.
				return;
		}				
		if (JustClicked==true)
		{
			return;
		}
		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModePickup:
			break;
		default:
			ClickEvent(ptrID);
			break;
		}
	}

		/// <summary>
		/// Handles click events on the main window
		/// </summary>
		/// <param name="ptrID">Ptr I.</param>
	void ClickEvent(int ptrID)
	{
		if ((GameWorldController.instance.playerUW.PlayerMagic.ReadiedSpell!="" ) ||(JustClicked==true))
		{
			//Debug.Log("player has a spell to cast");
			return;
		}

		switch (UWCharacter.InteractionMode)
		{
		case UWCharacter.InteractionModeOptions://Options mode
			return;//do nothing
		case UWCharacter.InteractionModeTalk://Talk
			GameWorldController.instance.playerUW.TalkMode();
			break;
		case UWCharacter.InteractionModePickup://Pickup
			if (GameWorldController.instance.playerUW.gameObject.GetComponent<PlayerInventory>().ObjectInHand!="")
			{
				UWWindowWait(1.0f);
				ThrowObjectInHand();
			}
			else
			{
				GameWorldController.instance.playerUW.PickupMode(ptrID);
			}			
			break;
		case UWCharacter.InteractionModeLook://look
			GameWorldController.instance.playerUW.LookMode();//do nothing
			break;
		case UWCharacter.InteractionModeAttack:	//attack
			break;
		case UWCharacter.InteractionModeUse://Use
			if (GameWorldController.instance.playerUW.gameObject.GetComponent<PlayerInventory>().ObjectInHand!="")
			{
				GameWorldController.instance.playerUW.UseMode();
			}
			else
			{
				GameWorldController.instance.playerUW.UseMode();
			}
			break;
		}
	}

		/// <summary>
		/// Throws the object in hand along a vector in the 3d view.
		/// </summary>
	protected override void ThrowObjectInHand ()
	{
		base.ThrowObjectInHand ();
		if (GameWorldController.instance.playerUW.playerInventory.GetObjectInHand()!="")
		{//The player is holding something
			if (GameWorldController.instance.playerUW.playerInventory.JustPickedup==false)//To prevent the click event dropping an object immediately after pickup
			{
				//Determine what is directly in front of the player via a raycast
				//If something is in the way then cancel the drop
				//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				Ray ray ;
				if (GameWorldController.instance.playerUW.MouseLookEnabled==true)
				{
					ray =Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
				}
				else
				{
					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				}
				
				
				RaycastHit hit = new RaycastHit(); 
				float dropRange=0.5f;
				if (!Physics.Raycast(ray,out hit,dropRange))
				{//No object interferes with the drop
					//Calculate the force based on how high the mouse is
					float force = Input.mousePosition.y/Camera.main.pixelHeight *200;
					//float force = Camera.main.ViewportToWorldPoint(Input.mousePosition).y/Camera.main.pixelHeight *200;
					

					//Get the object being dropped and moved towards the end of the ray
				
					GameObject droppedItem = GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand(); //GameObject.Find(GameWorldController.instance.playerUW.playerInventory.ObjectInHand);

					droppedItem.GetComponent<ObjectInteraction>().PickedUp=false;	//Back in the real world
					droppedItem.GetComponent<ObjectInteraction>().UpdateAnimation();

					if (droppedItem.GetComponent<Container>()!=null)
					{//Set the picked up flag recursively for container items.
						Container.SetPickedUpFlag(droppedItem.GetComponent<Container>(),false);
						Container.SetItemsParent(droppedItem.GetComponent<Container>(),GameWorldController.instance.LevelMarker());
						Container.SetItemsPosition (droppedItem.GetComponent<Container>(),GameWorldController.instance.playerUW.playerInventory.InventoryMarker.transform.position);
					}
					droppedItem.transform.position=ray.GetPoint(dropRange-0.1f);//GameWorldController.instance.playerUW.transform.position;
					droppedItem.transform.parent = GameWorldController.instance.LevelMarker();
					GameWorldController.UnFreezeMovement(droppedItem);
					if (Camera.main.ScreenToViewportPoint (Input.mousePosition).y>0.4f)
					{//throw if above a certain point in the view port.
						Vector3 ThrowDir = ray.GetPoint(dropRange) - ray.origin;
						//Apply the force along the direction.
						droppedItem.GetComponent<Rigidbody>().AddForce(ThrowDir*force);
					}
					
					//Clear the object and reset the cursor
					UWHUD.instance.CursorIcon= UWHUD.instance.CursorIconDefault;
					GameWorldController.instance.playerUW.playerInventory.SetObjectInHand("");
				}
				
			}
			else
			{				
				GameWorldController.instance.playerUW.playerInventory.JustPickedup=false;//The next click event will allow dropping.
			}
		}
	}


	/// <summary>
	/// Sets the full screen mode.
	/// </summary>
	public void SetFullScreen()
	{
		FullScreen=true;
		setPositions();

		UWHUD.instance.EnableDisableControl(UWHUD.instance.main_window,false);
		RectTransform pos= this.GetComponent<RectTransform>();
		pos.localPosition = new Vector3(0f,0f,0f);
		pos.sizeDelta = new Vector3(0f, 0f);
		GameWorldController.instance.playerUW.playerCam.rect= new Rect(0.0f,0.0f,1.0f,1.0f);
		UWHUD.instance.RefreshPanels(-1);//refresh controls
	}

		/// <summary>
		/// Unsets full screen mode.
		/// </summary>
	public void UnSetFullScreen()
	{
		FullScreen=false;
		setPositions();
		UWHUD.instance.EnableDisableControl(UWHUD.instance.main_window,true);
		RectTransform pos= this.GetComponent<RectTransform>();
		pos.localPosition = new Vector3(-22f,25f,0f);
		pos.sizeDelta = new Vector3(-148f, -88f);
		GameWorldController.instance.playerUW.playerCam.rect= new Rect(0.163f,0.335f,0.54f,0.572f);
		UWHUD.instance.RefreshPanels(-1);//refresh controls
	}


		/// <summary>
		/// Controls the display mode of the mouse cursor and calls switching between full and windowed screen.
		/// </summary>
	void OnGUI()
	{//Controls switching between Mouselook and interaction and sets the cursor icon
		if (Conversation.InConversation==true)
		{
			GameWorldController.instance.playerUW.XAxis.enabled=false;
			GameWorldController.instance.playerUW.YAxis.enabled=false;
			GameWorldController.instance.playerUW.MouseLookEnabled=false;
			Cursor.lockState = CursorLockMode.None;
			CursorPosition.center = Event.current.mousePosition;
			GUI.DrawTexture (CursorPosition,UWHUD.instance.CursorIcon);
			UWHUD.instance.MouseLookCursor.texture= UWHUD.instance.CursorIconBlank;
		}
		else
		{
			if (WindowDetect.InMap==false)
			{
				if ((Event.current.Equals(Event.KeyboardEvent("f")) && (WaitingForInput==false)))
				{//Toggle full screen.
					if (FullScreen==true)
					{
						UnSetFullScreen();
					}
					else
					{
						SetFullScreen();
					}
				}

				if ((Event.current.Equals(Event.KeyboardEvent("e"))) && (WaitingForInput==false))
				{			
					if (GameWorldController.instance.playerUW.MouseLookEnabled==false)
					{//Switch to mouse look.
						GameWorldController.instance.playerUW.YAxis.enabled=true;
						GameWorldController.instance.playerUW.XAxis.enabled=true;
						GameWorldController.instance.playerUW.MouseLookEnabled=true;
						Cursor.lockState = CursorLockMode.Locked;						
						UWHUD.instance.MouseLookCursor.texture=UWHUD.instance.CursorIcon;
					}
					else
					{
						GameWorldController.instance.playerUW.XAxis.enabled=false;
						GameWorldController.instance.playerUW.YAxis.enabled=false;
						GameWorldController.instance.playerUW.MouseLookEnabled=false;
						Cursor.lockState = CursorLockMode.None;
						UWHUD.instance.MouseLookCursor.texture= UWHUD.instance.CursorIconBlank;	
					}
				}
			}
			
			if (GameWorldController.instance.playerUW.MouseLookEnabled == false)
			{
				if ((WindowDetectUW.InMap==true) && (MapInteraction.InteractionMode==2))
				{
					CursorPosition.center = MapInteraction.CursorPos+MapInteraction.caretAdjustment;	
				}
				else
				{
					CursorPosition.center = Event.current.mousePosition;						
				}
				GUI.DrawTexture (CursorPosition,UWHUD.instance.CursorIcon);
			}	
			else
				{
					if (UWHUD.instance.MouseLookCursor.texture.name != UWHUD.instance.CursorIcon.name)	
					{
						UWHUD.instance.MouseLookCursor.texture=UWHUD.instance.CursorIcon;	
					}
				}	
		}
	}
}