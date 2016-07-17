﻿using UnityEngine;
using System.Collections;

public class Anvil : object_base {

	/// <summary>
	/// The anvil becomes a special object in hand
	/// </summary>
	/// Actual anvil repairs handled by Equipment
	public override bool use ()
	{
		if (playerUW.playerInventory.ObjectInHand=="")
		{
			BecomeObjectInHand();
			GameWorldController.instance.playerUW.playerHud.MessageScroll.Set("Use Anvil on what?");
			return true;
		}
		else
		{
			return ActivateByObject(playerUW.playerInventory.GetGameObjectInHand());
		}		
	}
}
