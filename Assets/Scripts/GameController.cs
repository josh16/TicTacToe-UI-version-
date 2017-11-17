using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList; // Create an array for all of the buttons text's
							  //We want to check the buttons text to see if there is 3 matching values in a row

	private string playerSide;


	void Awake()
	{
		SetGameControllerReferenceOnButtons (); // When the game starts, this function will be called
		playerSide = "X";
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
		return playerSide;
	}


	void changeSides()
	{
		//Ternary Operator
		playerSide = (playerSide == "X") ? "O" : "X"; 
	}

	public void EndTurn()
	{

		//Checking to see if the player has won

		//Top Row
		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) 
		{
			GameOver ();
		}

		//Middle Row
		if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) 
		{
			GameOver (); 
		}

		//Bottom Row
		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) 
		{
			GameOver ();
		}

		//Left Row
		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) 
		{
			GameOver ();
		}

		//Middle Row
		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) 
		{
			GameOver ();
		}

		//Right Row
		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) 
		{
			GameOver ();
		}

		//Left Diagonal
		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) 
		{
			GameOver ();
		}
	
		//Right Diagonal
		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) 
		{
			GameOver ();
		}


		changeSides ();
	}



	//GameOver Function that Deactivates the Buttons
	void GameOver()
	{
		Debug.Log ("Lmao, you lost...GIT GUD!!!!");

		for (int i = 0; i < buttonList.Length; i++) 
		{
			// Here, we get the parent component "Button" and make it interactable
			buttonList[i].GetComponentInParent<Button>().interactable = false;

		}



	}

}
