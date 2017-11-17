using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList; // Create an array for all of the buttons text's
							  //We want to check the buttons text to see if there is 3 matching values in a row



	void Awake()
	{
		SetGameControllerReferenceOnButtons (); // When the game starts, this function will be called
	}



	public void SetGameControllerReferenceOnButtons()
	{
		//Loop through the buttonList
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList [i].GetComponentInParent<GridSpace> ().SetGameControllerReference (this);
			// We are setting the "GridSpace" which is the parent object to now reference 
			// "this" GameController Script

			
		}
	}



	public string GetPlayerSide()
	{
		return "?";
	}

	public void EndTurn()
	{
		Debug.Log ("End Turn is not implemented!!");
	}

}
