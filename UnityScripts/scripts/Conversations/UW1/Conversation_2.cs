﻿using UnityEngine;
using System.Collections;

public class Conversation_2 : Conversation {
	
	public int[,] global =new int[11,3];
	//conversation #2
	//String block 0x0e02, name Shak
	
	//When Shak wants us to come back for the sword.
	public int AppointmentTime;
	//public int AppointmentMinutesEarly;
	public string ItemUnderRepair;
	//Enumerator that returns a value
	int func_11f7_result;
	public override IEnumerator main() {
		SetupConversation (3586);
		privateVariables[1] = 0;
		yield return StartCoroutine(func_029d());
		func_0012();
		yield return 0;
	} // end func
	
	void func_0012() {
		EndConversation();
		privateVariables[0] = 1;
	} // end func
	
	int func_0020() {
		
		//int locals[1];
		int[] locals =new int[2];
		
		if ( (((npc.npc_goal == 5 || npc.npc_goal == 6) || npc.npc_goal == 9) && npc.npc_gtarg == 1 || npc.npc_attitude == 0) ) {
			
			locals[1] = 0;
		} else {
			
			locals[1] = 1;
		} // end if
		
		return locals[1];
	} // end func
	
	/*void func_0063() {
		
		npc.npc_gtarg = 1;
		npc.npc_attitude = 1;
		npc.npc_goal = 6;
		func_0012();
	} // end func*/
	
	/*void func_007c() {
		
		npc.npc_goal = 1;
		func_0012();
	} // end func*/
	
	void func_008b() {
		
		npc.npc_gtarg = 1;
		npc.npc_goal = 5;
		npc.npc_attitude = 1;
		func_0012();
	} // end func
	
	/*void func_00a4() {
		
		npc.npc_attitude = 6;
	} // end func*/
	
	/*void func_00b1() {
		
		npc.npc_attitude = param1[0]global[0];
		func_0012();
	} // end func*/
	
	void func_00c2() {
		
		npc.npc_attitude = 2;
		func_0012();
	} // end func
	
	/*void func_00d1() {
		
		npc.npc_attitude = 1;
		func_0012();
	} // end func*/
	
	void func_00e0() {
		
		func_0012();
	} // end func
	
	void func_00ea(int param1) {
		//TODO:Figure out this. Has something to do with time for work to complete.
		/*
		param1[1] = game_days;
		param1[2] = game_mins;
		*/
	} // end func
	
	int func_0106(int param1, int param2)
	{//My version of have I made my appointment.
		return 1;
		int hoursLeft= AppointmentTime - GameClock.ConvertNow ();
		
		if (hoursLeft<=0)
		{
			//I'm on time or late.
			return 1;
		}
		else
		{
			//Not yet. 
			return 0;
		}
	}
	
	/*int func_0106(int param1, int param2) {
		return 1;
		//int locals[4];
		int[]locals =new int[5];
		
		//locals[2] = game_days - param2[1];
		locals[2] = game_days - param1;//[1];
		locals[3] = game_mins - param2;//[2];
		if ( locals[3] < 0 ) {
			
			locals[3] = locals[3] + 1440;
			locals[2] = locals[2] - 1;
		} // end if
		
		//if ( locals[2] >= param1[1] && locals[3] >= param1[2] ) {
		if ( locals[2] >= param1 && locals[3] >= param1 ) {			
			locals[1] = 1;
		} else {
			
			locals[1] = 0;
		} // end if
		
		return locals[1];

	} // end func*/
	
	void func_018f(int param1, int param2, int param3) {
		//TODO:Figure out this
		/*
		param1[1] = game_days - param3[1];
		param1[2] = game_mins - param3[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
		param1[1] = param2[1] - param1[1];
		param1[2] = param2[2] - param1[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		*/
	} // end func
	
	/*void func_0243() {
		
		param1[1] = game_days - param2[1];
		param1[2] = game_mins - param2[2];
		if ( param1[2] < 0 ) {
			
			param1[2] = param1[2] + 1440;
			param1[1] = param1[1] - 1;
		} // end if
		
	} // end func*/
	
	IEnumerator func_029d() {
		
		//int locals[24];
		int[] locals =new int[25];
		locals[1] = 15;
		locals[2] = 10001;		
		global[10,0] = x_skills( 2, locals[2], locals[1] );
		
		if ( global[0,0] == 0 ) {
			
			func_13bb();
			//TODO:Figure this out
			global[0,0] = 1;
			global[3,1] = 0;
			global[3,2] = 0;
			global[6,1] = 0;
			global[6,2] = 0;
			global[9,0] = 0;
			global[2,0] = -1;
		} // end if
		
		if ( npc.npc_talkedto==1 ) {
			
			yield return StartCoroutine(func_0729());
		} else {
			
			yield return StartCoroutine(say( locals, 001 ));
			locals[3] = 2;
			locals[4] = 3;
			locals[5] = 0;
			//locals[24] = babl_menu( 0, locals[3] );
			yield return StartCoroutine(babl_menu (0,locals,3));
			locals[24] = PlayerAnswer;
			switch ( locals[24] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0343());//i need info
				break;
				
			case 2:
				
				yield return StartCoroutine(func_03fb());//need your skills
				break;
			} // end if
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0343() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 004 ));
		locals[1] = 5;
		locals[2] = 6;
		locals[3] = 7;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0801());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_03fb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_039f());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_039f() {
		
		//int locals[22];
		int[]locals =new int[23];
		
		yield return StartCoroutine(say( locals, 008 ));
		locals[1] = 9;
		locals[2] = 10;
		locals[3] = 11;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0443());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0dfb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0801());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_03fb() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 012 ));
		locals[1] = 13;
		locals[2] = 14;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_067e());//cannot pay
			break;
			
		case 2:
			
			yield return StartCoroutine(func_06e1());//i can pay
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0443() {
		//Shak is repairing something. Not working...
		//int locals[69];
		int[] locals=new int[70];
		
		locals[21] = 0;
	label_044d:;
		
		if ( locals[21] > 2 ) {
			
			yield return StartCoroutine(say( locals, 015 ));
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
		} // end if
		
		locals[18] = 0;
		locals[19] = 0;
		//locals[16] = show_inv( 2, locals[8], locals[3] );
		locals[16] = show_inv( 2,locals,8, 3 );
		if ( locals[16] == 0 ) {
			
			locals[21] = locals[21] + 1;
			//goto label_063b;//Ask to try again.
				yield return StartCoroutine(say( locals, 028 ));
				locals[48] = 29;
				locals[49] = 30;
				locals[50] = 0;
				//locals[69] = babl_menu( 0, locals[48] );
				yield return StartCoroutine(babl_menu (0,locals,48));
				locals[69] = PlayerAnswer;
				//TODO:Figure this out.
				//locals[69] == 1;  // expr. has value on stack!
				if ( locals[69] == 2 ) {

						yield return StartCoroutine(func_13ac());
				} // end if
				else
				{
						goto label_044d;		
				}

		} else {
				locals[2]=locals[3];//Put the first found object into locals2
			locals[18] = 0;
			locals[19] = 0;
			locals[17] = 1;
			while ( (locals[17] <= locals[16]) && ((locals[19] !=1) || (locals[18]!=1)) ) {
				//Try and match sword hilt and blade.
				if  (( locals[3] == 280 ) || ( locals[4] == 280)) {
					
					locals[19] = 1;
					locals[13] = locals[7];
				} // end if
				
				if  (( locals[3] == 281 ) || ( locals[4] == 281)) {
					
					locals[18] = 1;
					locals[14] = locals[7];
				} // end if
				
				locals[17] = locals[17] + 1;
			} // while
			locals[22] = 16;
			locals[23] = 17;
			locals[1] = sex( 2, locals[23], locals[22] );
			
			if ( (locals[19]==1) && (locals[18]==1)) {
				//found sword and hilt
				yield return StartCoroutine(say( locals, 018 ));
				locals[24] = 19;
				locals[25] = 20;
				locals[26] = 0;
				//locals[45] = babl_menu( 0, locals[24] );
				TradeSlot.Locked=true;//Stop player from removing items from trade area.
				yield return StartCoroutine(babl_menu (0,locals,24));
				TradeSlot.Locked=false;
				locals[45] = PlayerAnswer;
				switch ( locals[45] ) {
					
				case 1:
					
					yield return StartCoroutine(func_13ac());
					break;
					
				case 2:
					
					yield return StartCoroutine(func_0ada( 8,locals ));//Takes objects from the list.
					yield break;
				} // end if
				
			} 			
			if ( locals[16] > 1 ) {
				
				if ( locals[21] > 2 ) {
					
					yield return StartCoroutine(say( locals, 021 ));
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00c2();
					yield break;
				} // end if
				
				yield return StartCoroutine(say( locals, 022 ));
				locals[21] = locals[21] + 1;
			} else {
				//Get item at selected index;
				if ( locals[3] > 63 ) {
					
					if ( (((locals[3] == 201 || locals[3] == 203) || locals[3] == 202) || locals[3] == 200) ) {
						
						yield return StartCoroutine(say( locals, 023 ));
					} else {
						
						if ( (locals[3] == 280 || locals[3] == 281) ) {
							
							yield return StartCoroutine(say( locals, 024 ));
						} else {
							
							yield return StartCoroutine(say( locals, 025 ));
							locals[21] = locals[21] + 1;
						} 
						
					}
				}
				else {
					//Standard repair
					locals[20] = check_inv_quality( 1, locals[8] );
					locals[46] = 0;
					locals[47] = 0;
					identify_inv( 4, locals, 47, 2, 46, locals[8] );
					switch ( locals[20] ) {
						
					case 16:
						
						yield return StartCoroutine(say( locals, 026 ));
						goto label_063b;

					case 63:
						
						yield return StartCoroutine(say( locals, 027 ));
						goto label_063b;
	
					default:
						yield return StartCoroutine(func_0bb4( locals, 8 ));
						yield return null;
						break;
					} // end if
					
				} // end if
				
			} // end if
			
			//	} // end if
			
			//	} // end if
		//	yield break;	
		label_063b:;
			//Asks to try again
			
			yield return StartCoroutine(say( locals, 028 ));
			locals[48] = 29;
			locals[49] = 30;
			locals[50] = 0;
			//locals[69] = babl_menu( 0, locals[48] );
			yield return StartCoroutine(babl_menu (0,locals,48));
			locals[69] = PlayerAnswer;
			//TODO:Figure this out.
			//locals[69] == 1;  // expr. has value on stack!
			goto label_044d;
			
		} // end switch
		
		if ( locals[69] == 2 ) {
			
			yield return StartCoroutine(func_13ac());
		} // end if
		
	} // end func
	
	IEnumerator func_067e() {
		
		//int locals[25];
		int[] locals=new int[26];
		locals[2] = 31;
		locals[3] = 32;
		locals[1] = sex( 2, locals[3], locals[2] );
		
		yield return StartCoroutine(say( locals, 033 ));
		locals[4] = 34;
		locals[5] = 35;
		locals[6] = 0;
		//locals[25] = babl_menu( 0, locals[4] );
		yield return StartCoroutine(babl_menu (0,locals,4));
		locals[25] = PlayerAnswer;
		
		switch ( locals[25] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0a88());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0ad0());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_06e1() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 036 ));
		locals[1] = 37;
		locals[2] = 38;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0dfb());//ask to identify
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0443());//this is in need of repair
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0729() {
		
		//int locals[29];
		int [] locals =new int[30];
		locals[6] = 39;
		locals[7] = 40;		
		locals[1] = sex( 2, locals[7], locals[6] );
		
		if ( global[2,0] > 0 ) {//I am repairing something.
			
			if ( func_0106( 3, 6 ) !=1) {//I am early.
				
				func_018f( locals[3], 3, 6 );
				if ( locals[4] == 1 ) {
					
					locals[2] = 41;
				} else {
					
					locals[2] = 42;
				} // end if
				
				yield return StartCoroutine(say( locals, 043 ));
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
			} // end if
			
			if ( global[2,0] == 10 ) {//Am I repairing the sword or not.
				
				yield return StartCoroutine(func_1064());
			} else {
				
				yield return StartCoroutine(func_0d65());
			} // end if
			
		} else {
			
			yield return StartCoroutine(say( locals, 044 ));
			locals[8] = 45;
			locals[9] = 46;
			locals[10] = 47;
			locals[11] = 48;
			locals[12] = 0;
			//locals[29] = babl_menu( 0, locals[8] );
			yield return StartCoroutine(babl_menu (0,locals,8));
			locals[29] = PlayerAnswer;
			switch ( locals[29] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0443());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0dfb());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0801());
				break;
				
			case 4:
				
				yield return StartCoroutine(func_039f());
				break;
			} // end if
			
			
			
		} // end switch
		
		//return;
		
	} // end func
	
	IEnumerator func_0801() {
		
		//int locals[22];
		int [] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 049 ));
		locals[1] = 50;
		locals[2] = 51;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_08a5());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0849());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0849() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 052 ));
		locals[1] = 53;
		locals[2] = 54;
		locals[3] = 55;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0953());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_08a5());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_08a5() {
		
		//int locals[22];
		int[] locals =new int[23];
		if ( global[9,0] == 1) {
			
			yield return StartCoroutine(func_08f7());
		} else {
			
			yield return StartCoroutine(say( locals, 056 ));
			locals[1] = 57;
			locals[2] = 59;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(say( locals, 058 ));
				break;
				
			case 2:
				
				break;
				
			} // end switch
			
			yield return StartCoroutine(func_13ac());
		} // end if
		
	} // end func
	
	IEnumerator func_08f7() {
		
		//int locals[22];
		int[] locals =new int[23];
		
		yield return StartCoroutine(say( locals, 060 ));
		locals[1] = 61;
		locals[2] = 62;
		locals[3] = 63;
		locals[4] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0443());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0dfb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0953() {
		
		//int locals[81];
		int [] locals =new int[82];
		
		yield return StartCoroutine(say( locals, 064 ));
		locals[16] = 65;
		locals[17] = 66;
		locals[18] = 0;
		//locals[37] = babl_menu( 0, locals[16] );
		yield return StartCoroutine(babl_menu (0,locals,16));
		locals[37] = PlayerAnswer;
		switch ( locals[37] ) {
			
		case 1:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		case 2:
			
			break;
			
		} // end switch
		
	label_0996:;
		
		locals[1] = 1;
		locals[2] = 0;
		//locals[3] = show_inv( 2, locals[9], locals[4] );
		locals[3]=show_inv (2,locals,9, 4);
		while ( locals[1] <= locals[3] ) {
			
			if ( locals[3] == 55 ) {
				
				locals[2] = locals[1];
				locals[14] = locals[8];
			} // end if
			
			locals[1] = locals[1] + 1;
		} // while
		
		if ( locals[2] > 0 ) {
			
			yield return StartCoroutine(say( locals, 067 ));
		} else {
			
			yield return StartCoroutine(say( locals, 068 ));
			locals[38] = 69;
			locals[39] = 70;
			locals[40] = 0;
			//locals[59] = babl_menu( 0, locals[38] );
			yield return StartCoroutine(babl_menu (0,locals,38));
			locals[59] = PlayerAnswer;
			switch ( locals[59] ) {
				
			case 1:
				
				goto label_0996;

			case 2:
				
				yield return StartCoroutine(say( locals, 071 ));
				goto label_0a34;
			} // end if
			
			
			
		} // end switch
		
	label_0a34:;
		
		locals[60] = 72;
		locals[61] = 73;
		locals[62] = 74;
		locals[63] = 0;
		//locals[81] = babl_menu( 0, locals[60] );
		yield return StartCoroutine(babl_menu (0,locals,60));
		locals[81] = PlayerAnswer;
		switch ( locals[81] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0443());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0dfb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0a88() {
		
		//int locals[22];
		int[]locals =new int[23];
		
		yield return StartCoroutine(say( locals, 075 ));
		locals[1] = 76;
		locals[2] = 77;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0ad0() {
		
		yield return StartCoroutine(func_13ac());
	} // end func
	
	IEnumerator func_0ada(int param1, int[] param1Locals) {
		
		//int locals[46];
		int[] locals=new int[47];
		
		locals[1] = 0;
	label_0ae4:;
		
		locals[2] = 2;
		if ( give_to_npc( 2,param1Locals, param1, locals[2] ) !=1 ) {
			//if ( !give_to_npc( 2, param1, locals[2] ) ) {
			
			yield return StartCoroutine(say( locals, 078 ));
			locals[3] = 79;
			locals[4] = 81;
			locals[5] = 0;
			//locals[24] = babl_menu( 0, locals[3] );
			yield return StartCoroutine(babl_menu (0,locals,3));
			locals[24] = PlayerAnswer;
			switch ( locals[24] ) {
				
			case 1:
				
				if ( locals[1] > 2 ) {
					
					yield return StartCoroutine(say( locals, 080 ));
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00c2();
					yield break;
				} // end if
				
				locals[1] = locals[1] + 1;
				goto label_0ae4;
				
			case 2:
				
				yield return StartCoroutine(func_13ac());
				break;
			} // end if
			
		} 
		
		yield return StartCoroutine(say( locals, 082 ));
		global[2,0] = 10;//Seems to indicate we are repairing the sword.
		func_00ea( 6 );
		global[3,1] = 0;//no days
		global[3,2] = 60;//60 minutes
		global[1,0] = 20;//20 gold?
		
		
		//Sets the date and time the player is to come back at
		AppointmentTime = GameClock.AddNow(0,1,0);//Add 1 hour to the appointment time.
		
		locals[25] = 83;
		locals[26] = 84;
		locals[27] = 0;
		//locals[46] = babl_menu( 0, locals[25] );
		yield return StartCoroutine(babl_menu (0,locals,25));
		locals[46] = PlayerAnswer;
		switch ( locals[46] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_0bb4(int[] PassedLocals, int param1) {//Param1 is the slot the item being repaired is in.
		
		//int locals[75];
		int[]locals=new int[76];
		//This is how shak calculates the cost of this
		locals[1] = 0;
		locals[2] = identify_inv( 4, locals, 8, 5, 7, PassedLocals[param1] );//TODO:take note of the passedlocals
		locals[7] = 0;
		locals[8] = 0;
		locals[3] = check_inv_quality( 1, PassedLocals[param1] );
		locals[4] = 100 - locals[3] * 100 / 63 * locals[2] / 100;
		locals[4] = locals[4] / 3;
		locals[4] = locals[4] - global[10,0] / 6;
		switch ( locals[4] ) {
			
		case 0://This was 1. CHeck what happens here
			
			locals[4] = 1;
			break;
			
		case 1:
			
			locals[6] = 85;
		//	break;
			
			locals[6] = 86;
			yield return StartCoroutine(say( locals, 087 ));
			locals[9] = 88;
			locals[10] = 89;
			locals[11] = 0;
			//locals[30] = babl_menu( 0, locals[9] );
			yield return StartCoroutine(babl_menu (0,locals,9));
			locals[30] = PlayerAnswer;
			//TODO:Figure this out.
			//locals[30] == 1;  // expr. has value on stack!
			break;
		} // end switch
		
		if ( locals[30] == 2 ) {
			
			yield return StartCoroutine(func_13ac());
		} // end if
		
	label_0c78:;
		
		locals[31] = 1;
		string itemAt = UWHUD.instance.playerTrade[PassedLocals[param1]].objectInSlot;
		if (give_to_npc(2,PassedLocals, param1,locals[31]) != 1){
			//if ( !give_to_npc( 2, param1, locals[31] ) ) {
			
			yield return StartCoroutine(say( locals, 090 ));
			locals[32] = 91;
			locals[33] = 93;
			locals[34] = 0;
			//locals[53] = babl_menu( 0, locals[32] );
			yield return StartCoroutine(babl_menu (0,locals,32));
			locals[53] = PlayerAnswer;
			switch ( locals[53] ) {
				
			case 1:
				
				if ( locals[1] > 2 ) {
					
					yield return StartCoroutine(say( locals, 080 ));
					Time.timeScale =SlomoTime;
					yield return new WaitForSeconds(WaitTime);
					func_00c2();
					yield break;
				} // end if
				
				locals[1] = locals[1] + 1;
				goto label_0c78;
				
			case 2:
				
				yield return StartCoroutine(func_13ac());
				break;
			} // end if
			
		} 
		//TODO:Figure this out
		ItemUnderRepair=itemAt;
		global[3,1] = 0;
		global[3,2] = 63 - locals[3] / 2;
		if ( global[3,2] < 2 ) {
			
			global[3,2] = 2;
		} // end if
		
		yield return StartCoroutine(say( locals, 094 ));
		//TODO:Figure this out.
		//global[2] = param1[0]global[0];
		global[2,0]= global[3,2];
		func_00ea( 6 );
		global[1,0] = locals[4];
		locals[54] = 95;
		locals[55] = 96;
		locals[56] = 0;
		//locals[75] = babl_menu( 0, locals[54] );
		yield return StartCoroutine(babl_menu (0,locals,54));
		locals[75] = PlayerAnswer;
		switch ( locals[75] ) {
			
		case 1:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00e0();
			yield break;

		case 2:
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_00c2();
			yield break;

		} // end switch
		
	} // end func
	
	IEnumerator func_0d65() {
		
		//int locals[25];
		int[] locals =new int[26];
		
		yield return StartCoroutine(say( locals, 097 ));
		locals[1] = 10;
		locals[2] = 50 + random( 1, locals[1] );
		UWHUD.instance.npcTrade[2].objectInSlot=ItemUnderRepair;
		set_inv_quality( 2, locals[2], 2 );
		locals[3] = 1;
		yield return StartCoroutine(func_11f7( locals[3], 1 ) );
		//if ( func_11f7( locals[3], 1 ) ) {
		if ( func_11f7_result==1) {
			if ( take_id_from_npc( 1, 2 ) == 2 ) {
				
				yield return StartCoroutine(say( locals, 098 ));
			} // end if
			
			global[2,0] = -1;
			locals[4] = 99;
			locals[5] = 100;
			locals[6] = 0;
			//locals[25] = babl_menu( 0, locals[4] );
			yield return StartCoroutine(babl_menu (0,locals,4));
			locals[25] = PlayerAnswer;
			switch ( locals[25] ) {
				
			case 1:
				
				yield return StartCoroutine(func_1187());
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
			} // end if
			
		} else {
			
			
			
		} // end switch
		
		yield return StartCoroutine(say( locals, 101 ));
	} // end func
	
	IEnumerator func_0dfb() {
		
		//int locals[109];
		int[] locals=new int[110];
		
		locals[1] = 0;
		
	label_0e05:;
		
		//locals[3] = show_inv( 2, locals[10], locals[5] );
		locals[3]= show_inv (2,locals,10,5);
		switch ( locals[3] ) {
			
		case 0:
			
			if ( locals[1] > 2 ) {
				
				yield return StartCoroutine(say( locals, 102 ));
						yield return new WaitForSeconds(WaitTime);
						func_00c2();
						yield break;
			} // end if
			
			yield return StartCoroutine(say( locals, 103 ));
			locals[19] = 104;
			locals[20] = 105;
			locals[21] = 0;
			//locals[40] = babl_menu( 0, locals[19] );
			yield return StartCoroutine(babl_menu (0,locals,19));
			locals[40] = PlayerAnswer;
			switch ( locals[40] ) {
				
			case 1:
				
				locals[1] = locals[1] + 1;
				goto label_0e05;
				
			case 2:
				
				yield return StartCoroutine(func_13ac());
				break;
				
			} // end switch
			
			break;
			
		case 1:
			break;
			
		default://For more than 1 item.	
			yield return StartCoroutine(say( locals, 106 ));
			locals[41] = 107;
			locals[42] = 108;
			locals[43] = 0;
			//locals[62] = babl_menu( 0, locals[41] );
			yield return StartCoroutine(babl_menu (0,locals,41));
			locals[62] = PlayerAnswer;
			switch ( locals[62] ) {
				
			case 1:
				
				locals[1] = 1;
				goto label_0e05;

			case 2:
				
				yield return StartCoroutine(func_13ac());
				break;
				
			} // end switch
			
			break;
			
		} // end switch

		locals[63] = 1;
		locals[64] = 0;
		locals[2] = identify_inv( 4,locals, 64, 15, 63, locals[10] );
		//locals[18] is the cash value of the item.
		if ( locals[2] / 5 < 3 ) {
			
			locals[18] = 1;
			locals[4] = 0;
		} else {
			
			locals[18] = locals[2] / 3;
			locals[4] = locals[18] / 5;
			if ( locals[4] <= global[10,0] / 6 ) {
				
				locals[4] = 0;
			} else {
				
				locals[4] = locals[4] - global[10,0] / 6;
			} // end if
			
		} // end if
		
		if ( locals[4] == 0 ) {
			
			locals[17] = 1;
		} else {
			yield return StartCoroutine(func_11f7( locals[65], locals[4] ));
			locals[17] = func_11f7_result; //func_11f7( locals[65], locals[4] );
			locals[65] = 2;
		} // end if
		
		if ( locals[18] == 1 ) {//Pieces of gold.
			
			locals[16] = 109;
		} else {
			
			locals[16] = 110;
		} // end if
		
		if ( locals[17] == 1) {
			
			if ( (locals[5] == 281 || locals[5] == 280) ) {
				
				yield return StartCoroutine(say( locals, 111 ));
			} else {
				
				if ( locals[18] == 0 ) {
					
					yield return StartCoroutine(say( locals, 112 ));
				} else {
					
					yield return StartCoroutine(say( locals, 113 ));
				} // end if
				
			} // end if
			
			locals[66] = 114;
			locals[67] = 115;
			locals[68] = 116;
			locals[69] = 117;
			locals[70] = 0;
			//locals[87] = babl_menu( 0, locals[66] );
			yield return StartCoroutine(babl_menu (0,locals,66));
			locals[87] = PlayerAnswer;
			switch ( locals[87] ) {
				
			case 1:
				
				yield return StartCoroutine(func_0443());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_0dfb());
				break;
				
			case 3:
				
				yield return StartCoroutine(func_0801());
				break;
				
			case 4:
				
				yield return StartCoroutine(func_13ac());
				break;
			} // end if
		}
		
		yield return StartCoroutine(say( locals, 118 ));
		locals[88] = 119;
		locals[89] = 120;
		locals[90] = 121;
		locals[91] = 122;
		locals[92] = 0;
		//locals[109] = babl_menu( 0, locals[88] );
		yield return StartCoroutine(babl_menu (0,locals,88));
		locals[109] = PlayerAnswer;
		switch ( locals[109] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0443());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0dfb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0801());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_1064() {
		
		//int locals[38];
		int[]locals=new int[39];
		
		yield return StartCoroutine(say( locals, 123 ));
		locals[2] = 281;
		do_inv_delete( 1, locals[2] );
		locals[3] = 280;
		do_inv_delete( 1, locals[3] );
		locals[4] = 10;
		do_inv_create( 1, locals[4] );
		locals[5] = 10;
		locals[6] = 0;
		locals[1] = find_inv( 2, locals[6], locals[5] );

		if ( locals[1] > 0 ) {
			
			locals[7] = 1;
			locals[8] = 7;
			locals[9] = -1;
			locals[10] = -1;
			locals[11] = -1;
			locals[12] = -1;
			locals[13] = -1;
			locals[14] = -1;
			//x_obj_stuff( 9, locals[14], locals[13], locals[12], locals[11], locals[10], locals[9], locals[8], locals[7], locals[1] );
			x_obj_stuff( 10,locals, 14, 13,12,11, 10, 9, 8, 7, locals[1]-1 );//Minus 1 for find_inv
		} // end if
		
		locals[15] = 1;
		yield return StartCoroutine(func_11f7( locals[15], 1 ));
		//if ( func_11f7( locals[15], 1 ) ) {
		if (func_11f7_result ==1){
			locals[16] = 10;
			if ( take_from_npc( 1, locals[16] ) == 2 ) {
				
				yield return StartCoroutine(say( locals, 098 ));
			} // end if
			
			global[2,0] = -1;
			global[9,0] = 1;
			locals[17] = 125;
			locals[18] = 126;
			locals[19] = 0;
			//locals[38] = babl_menu( 0, locals[17] );
			yield return StartCoroutine(babl_menu (0,locals,17));
			locals[38] = PlayerAnswer;
			switch ( locals[38] ) {
				
			case 1:
				
				yield return StartCoroutine(func_1187());
				break;
				
			case 2:
				Time.timeScale =SlomoTime;
				yield return new WaitForSeconds(WaitTime);
				func_00c2();
				yield break;
			} // end if
			
		} 
		
		yield return StartCoroutine(say( locals, 101 ));
	} // end func
	
	IEnumerator func_1187() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		yield return StartCoroutine(say( locals, 128 ));
		locals[1] = 129;
		locals[2] = 130;
		locals[3] = 131;
		locals[4] = 132;
		locals[5] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			yield return StartCoroutine(func_0801());
			break;
			
		case 2:
			
			yield return StartCoroutine(func_0dfb());
			break;
			
		case 3:
			
			yield return StartCoroutine(func_0443());
			break;
			
		case 4:
			
			yield return StartCoroutine(func_13ac());
			break;
			
		} // end switch
		
	} // end func
	
	IEnumerator func_11f7(int param1, int param2) {
		
		//int locals[68];
		int[] locals=new int[69];
		//TODO:Check this
		//if ( param2[0]global[0] == 1 ) {
		if ( param2 == 1 ) {	
			locals[23] = 133;
		} else {
			
			locals[23] = 134;
		} // end if
		
		locals[24] =global[1,0];// param1[0]global[0];
		if ( 1 == locals[24] ) {
			
			yield return StartCoroutine(say( locals, 135 ));
		} else {
			
			if ( true ) {
				
				yield return StartCoroutine(say( locals, 136 ));
			} // end if
			
		} // end if
		
		locals[25] = 137;
		locals[26] = 138;
		locals[27] = 0;
		//locals[46] = babl_menu( 0, locals[25] );
		yield return StartCoroutine(babl_menu (0,locals,25));
		locals[46] = PlayerAnswer;
		switch ( locals[46] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			locals[1] = 0;
			goto label_13a4;
			
		} // end switch
		
		locals[3] = 0;
		//} // end if
		
		//} // end if
	label_PAYSHAK:;	
		if ( locals[3] > 0 ) {
			
			locals[47] = 139;
			locals[48] = 140;
			locals[49] = 0;
			//locals[68] = babl_menu( 0, locals[47] );
			yield return StartCoroutine(babl_menu (0,locals,47));
			locals[68] = PlayerAnswer;
			switch ( locals[68] ) {
				
			case 1:
				
				break;
				
			case 2:
				
				locals[1] = 0;
				break;
			}
		} 
		
		//locals[5] = show_inv( 2, locals[6], locals[11] );
		locals[5] = show_inv (2,locals,6,11);
		if ( locals[5] == 0 ) {
			
			if ( locals[3] > 2 ) {
				
				locals[1] = 0;
			} else {
				
				yield return StartCoroutine(say( locals, 141 ));
				locals[3] = locals[3] + 1;				
			}
		goto label_PAYSHAK;
		}
		else {
			
			locals[2] = 1;
			locals[16] = 0;
			locals[17] = 0;
				int counter=0;
			while ( locals[2] <= locals[5] ) {
				//TODO:This will need some reworking
				if ( (locals[11+counter] == 160 )|| (locals[11+counter] == 161) ) {
					
					locals[16] = locals[16] + count_inv( 1, locals[6+counter] );
					locals[18 + locals[17]] = locals[6+counter]; //Copy the item poisition.
					locals[17] = locals[17] + 1;//No of items found
					
					//locals[17] = locals[5];
				} // end if
				counter++;
				locals[2] = locals[2] + 1;
			} // while
			
			//if ( locals[16] >= param2[0]global[0] ) {
			if ( locals[16] >=global[1,0] ) {
				
				//give_to_npc( 2, locals[18], locals[17] );
				give_to_npc(2,locals,18,locals[17]);
				//if ( locals[16] > param2[0]global[0] ) {
				if ( locals[16] >param2 ) {				
					yield return StartCoroutine(say( locals, 142 ));
				} // end if
				
				locals[1] = 1;
			} else {
				
				if ( locals[17] > 0 ) {
					
					yield return StartCoroutine(say( locals, 143 ));
					locals[3] = 1;
				} else {
					
					yield return StartCoroutine(say( locals, 144 ));
					locals[3] = 1;
				} // end if
				
			} // end if
			
		} // end if
		
	label_13a4:;
		func_11f7_result=locals[1];
		//return locals[1];
	} // end func
	
	IEnumerator func_13ac() {
		int[] locals = new int[1];
		yield return StartCoroutine(func_1448());
		yield return StartCoroutine(say( locals, 145 ));
		Time.timeScale =SlomoTime;
		yield return new WaitForSeconds(WaitTime);
		func_00e0();
		yield break;
		
	} // end func
	
	void func_13bb() {
		//TODO:Figure this out.
		/*		privateVariables[2][1] = 1001;
		privateVariables[2][2] = 1002;
		privateVariables[2][3] = 1003;
		privateVariables[2][4] = 1010;
		privateVariables[2][5] = 1016;
		privateVariables[2][6] = 1000;
		privateVariables[2][7] = -1;
		privateVariables[23][1] = 1019;
		privateVariables[23][2] = 1011;
		privateVariables[23][3] = 291;
		privateVariables[23][4] = 32;
		privateVariables[23][5] = 35;
		privateVariables[23][6] = 38;
		privateVariables[23][7] = 44;
		privateVariables[23][8] = -1;*/
		set_likes_dislikes( 2, 65, 44 );
	} // end func
	
	IEnumerator func_1448() {
		
		//int locals[22];
		int[] locals=new int[23];
		
		if ( func_0020() !=1) {
			
		} else {
			
			yield return StartCoroutine(say( locals, 146 ));
			locals[1] = 147;
			locals[2] = 148;
			locals[3] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_1498());
				break;
				
			case 2:
				yield break;

			} // end if
			
		} // end switch
		
	} // end func
	
	IEnumerator func_1498() {
		
		//int locals[44];
		int[] locals=new int[45];
		
		setup_to_barter( 0 );
		while ( privateVariables[1] !=1 ) {
			
			locals[1] = 149;
			locals[2] = 150;
			locals[3] = 151;
			locals[4] = 152;
			locals[5] = 0;
			//locals[22] = babl_menu( 0, locals[1] );
			yield return StartCoroutine(babl_menu (0,locals,1));
			locals[22] = PlayerAnswer;
			switch ( locals[22] ) {
				
			case 1:
				
				yield return StartCoroutine(func_1549());
				break;
				
			case 2:
				
				yield return StartCoroutine(func_158b());
				break;
				
			case 3:
				
				yield return StartCoroutine(do_judgement( 0 ));
				break;
				
			case 4:
				
				do_decline( 0 );
				privateVariables[1] = 1;
				break;
				
			} // end switch
			
		} // while
		
		locals[23] = 153;
		locals[24] = 0;
		//locals[44] = babl_menu( 0, locals[23] );
		yield return StartCoroutine(babl_menu (0,locals,23));
		locals[44] = PlayerAnswer;
		if ( locals[44] == 1 ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_1549() {
		
		//int locals[5];
		int [] locals=new int[6];
		
		locals[1] = 154;
		locals[2] = 155;
		locals[3] = 156;
		locals[4] = 157;
		locals[5] = 158;
		yield return StartCoroutine (do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1], 0,0) );
		if (PlayerAnswer==1)	{
			//if ( do_offer( 5, locals[5], locals[4], locals[3], locals[2], locals[1] ) ) {
			
			privateVariables[1] = 1;
		} // end if
		
	} // end func
	
	IEnumerator func_158b() {
		
		//int locals[24];
		int[]locals=new int[25];
		
		yield return StartCoroutine(say( locals, 159 ));
		locals[1] = 160;
		locals[2] = 161;
		locals[3] = 0;
		//locals[22] = babl_menu( 0, locals[1] );
		yield return StartCoroutine(babl_menu (0,locals,1));
		locals[22] = PlayerAnswer;
		switch ( locals[22] ) {
			
		case 1:
			
			break;
			
		case 2:
			
			yield break;

			
		} // end switch
		
		locals[23] = 162;
		locals[24] = 163;
		//	if ( do_demand( 2, locals[24], locals[23] ) ) {
		yield return StartCoroutine (do_demand( 2, locals[24], locals[23] ));
		if (PlayerAnswer==1){
			
			privateVariables[1] = 1;
		} else {
			Time.timeScale =SlomoTime;
			yield return new WaitForSeconds(WaitTime);
			func_008b();
			yield break;
		} // end if
		
	} // end func
	
	
	
	
	
	
	
	
}