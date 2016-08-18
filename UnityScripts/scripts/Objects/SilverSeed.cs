﻿using UnityEngine;
using System.Collections;

public class SilverSeed : object_base {


	public override bool PickupEvent ()
	{
		base.PickupEvent ();
		if (objInt().item_id==458)
		{//The seed is a sapling
			//Turn it into a seed.
			//objInt().ChangeType(290,objInt().GetItemType());
			objInt().item_id=290;
			objInt().WorldDisplayIndex=290;
			objInt().InvDisplayIndex=290;
			AnimationOverlay animo =this.GetComponent<AnimationOverlay>();
			if (animo!=null)
			{
				animo.Stop ();
			}
			objInt().UpdateAnimation();//Update the inventory display
			UWHUD.instance.CursorIcon = objInt().GetInventoryDisplay().texture;
			GameWorldController.instance.playerUW.ResurrectPosition=Vector3.zero;
			objInt().SetWorldDisplay(objInt().GetInventoryDisplay());
			UWHUD.instance.MessageScroll.Add (StringController.instance.GetString (1,9));

			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool use ()
	{
		if (GameWorldController.instance.playerUW.playerInventory.ObjectInHand=="")
		{
		if ((objInt().item_id==290) && (objInt().PickedUp==true))
			{
				//I'll test positioning later. For now just place it at the players position
				//Turn it into a sapling.
				objInt().item_id=458;
				objInt().WorldDisplayIndex=458;
				objInt().InvDisplayIndex=458;
				AnimationOverlay animo =this.GetComponent<AnimationOverlay>();
				if (animo!=null)
				{
					animo.Stop ();
				}
				objInt().UpdateAnimation();//Update the inventory display
				objInt().SetWorldDisplay(objInt().GetInventoryDisplay());
				UWHUD.instance.MessageScroll.Add(StringController.instance.GetString (1,12));


				UWHUD.instance.CursorIcon = UWHUD.instance.CursorIconDefault;
				GameWorldController.instance.playerUW.ResurrectPosition=GameWorldController.instance.playerUW.transform.position;
				GameWorldController.instance.playerUW.ResurrectLevel=GameWorldController.instance.LevelNo;
				int tileX= GameWorldController.instance.Tilemap.visitTileX;
				int tileY= GameWorldController.instance.Tilemap.visitTileY;
				objInt().gameObject.transform.parent=GameWorldController.instance.LevelMarker();
				
			//	objInt().gameObject.transform.position = new Vector3( 
			//			(((float)GameWorldController.instance.Tilemap.visitTileX) *1.2f)+0.6f, 
			//			(float)GameWorldController.instance.Tilemap.GetFloorHeight(GameWorldController.instance.LevelNo,tileX,tileY)  * 0.15f,
			//			(((float)GameWorldController.instance.Tilemap.visitTileY) *1.2f)+0.6f 
			//	);
				objInt().gameObject.transform.position=GameWorldController.instance.Tilemap.getTileVector(GameWorldController.instance.Tilemap.visitTileX,GameWorldController.instance.Tilemap.visitTileY);

				//objInt().transform.position= new Vector3 (x,z,y);
				//GameWorldController.instance.playerUW.transform.position;//TODO:Position the tree properly
				GameWorldController.instance.playerUW.playerInventory.RemoveItemFromEquipment(objInt().gameObject.name);
				GameWorldController.instance.playerUW.playerInventory.GetCurrentContainer().RemoveItemFromContainer(objInt().gameObject.name);
				GameWorldController.instance.playerUW.playerInventory.Refresh ();

				objInt().PickedUp=false;
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return ActivateByObject(GameWorldController.instance.playerUW.playerInventory.GetGameObjectInHand());
		}
	}
}