﻿using UnityEngine;
using System.Collections;

public class CutsceneAnimation : HudAnimation {
	/*Gui element for the small window animations*/

	/*Is also responsible for calling the resurrection sequence in UW1*/

//	public Camera maincam;

	public void PreAnimPlay()
	{//Called by events in certain animations when starting playing
		GameWorldController.instance.playerUW.playerCam.cullingMask=0;//Stops the camera from rendering.
		return;
	} 
	
	public void PostAnimPlay()
	{//Called by events in certain animations when finished playing

		switch (SetAnimation)
		{
		case "FadeToBlackSleep":
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			Bedroll.WakeUp (GameWorldController.instance.playerUW);
			break;
		case "ChasmMap":
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		case "Death_With_Sapling"://Resurrection
		//	MusicController mus = GameObject.Find("MusicController").GetComponent<MusicController>();
			if (GameWorldController.instance.mus!=null)
			{
				GameWorldController.instance.playerUW.CurVIT=GameWorldController.instance.playerUW.MaxVIT;
				GameWorldController.instance.mus.Death=false;
				GameWorldController.instance.mus.Combat=false;
				GameWorldController.instance.mus.Fleeing=false;
				MusicController.LastAttackCounter=0.0f;
			}
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			
			GameWorldController.instance.playerUW.gameObject.transform.position=GameWorldController.instance.playerUW.ResurrectPosition;
			if (GameWorldController.instance.LevelNo!=GameWorldController.instance.playerUW.ResurrectLevel)
			{
				GameWorldController.instance.SwitchLevel(GameWorldController.instance.playerUW.ResurrectLevel);
			}
			
			break;

		case "Death"://Forever
			SetAnimation= "Death_Final";
			break;
		case "Death_Final"://Forever
			break;
		default:
			//maincam.enabled=true;
			GameWorldController.instance.playerUW.playerCam.cullingMask=HudAnimation.NormalCullingMask;
			SetAnimation= "Anim_Base";//Clears out the animation.
			break;
		}
	}
}