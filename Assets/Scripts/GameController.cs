using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Class that holds relevant details for playerColour
[System.Serializable] //Shows up inspector
public class PlayerColor{

	public Color panelColour;
	public Color textColour;
}

//Class that holds relevant details for the image and text 
[System.Serializable] //Shows up inspector
public class Player{

	public Image panel;
	public Text text;
	public Button button;
}

public class GameController : MonoBehaviour {

	public Text[] buttonList; // Create an array for all of the buttons text's
							  //We want to check the buttons text to see if there is 3 matching values in a row

	private string playerSide;

	public GameObject gameOverPanel;
	public Text gameOverText;

	private int moveCount; // How many moves has it been?

	public GameObject RestartButton;
	public GameObject startInfo;

	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColour;
	public PlayerColor inactivePlayerColour;


	void Awake()
	{
		RestartButton.SetActive(false);
		SetGameControllerReferenceOnButtons (); // When the game starts, this function will be called
		gameOverPanel.SetActive (false);
		moveCount = 0; // When the Game starts, moveCount will be set to 0

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


	//Get PlayerSide Function
	public string GetPlayerSide()
	{
		return playerSide;
	}


	//Change Sides Function
	void changeSides()
	{
		
		playerSide = (playerSide == "X") ? "O" : "X";//Conditional Operator

		if (playerSide == "X") 
		{
			SetPlayerColours (playerX, playerO);
		} 
		else 
		{
			SetPlayerColours (playerO, playerX);
		}
	}

	public void EndTurn()
	{

		moveCount++; //At the end of each turn, moveCount increments

		//Checking to see if the player has won

		//Top Row
		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		}

		//Middle Row
		else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver (playerSide); 
		}

		//Bottom Row
		else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		}

		//Left Row
		else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		}

		//Middle Row
		else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver (playerSide);
		}

		//Right Row
		else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		}

		//Left Diagonal
		else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		}
	
		//Right Diagonal
		else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} 

		else 
		{
			changeSides ();
		}

	

		//This will be called if the moveCount is greater
		if (moveCount >= 9) 
		{
			GameOver ("draw");
		}
	}



	//GameOver Function that Deactivates the Buttons
	void GameOver(string winningPlayer)
	{
		SetBoardInteractable(false);
		RestartButton.SetActive (true);

		if (winningPlayer == "draw") 
		{
			SetGameOverText ("It's a Draw!!");
			SetPlayerColoursInactive ();
		} 
		else 
		{
			SetGameOverText(winningPlayer + "Wins!");
		}

		RestartButton.SetActive (true);
	}


	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive (true); // Game over Panel will be set to True
		gameOverText.text = value; 
	}


	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive (false);
		RestartButton.SetActive (false);
		SetPlayerButtons (true);
		SetPlayerColoursInactive ();
		startInfo.SetActive (true);


		//Resets all the buttons to blank again
		for (int i = 0; i < buttonList.Length; i++) 
		{
			buttonList[i].text = "";
		}

	}


	//Go through the button lost, and setting the toggle
	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++) 
		{
			// Here, we get the parent component "Button" and make it interactable
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;

		}
	
	}

	//Set PlayersColours Function
	void SetPlayerColours(Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColour.panelColour;
		newPlayer.panel.color = activePlayerColour.textColour;
		oldPlayer.panel.color = inactivePlayerColour.panelColour;
		oldPlayer.panel.color = inactivePlayerColour.textColour;
	}


	void StartGame()
	{
		SetBoardInteractable (true);
		SetPlayerButtons (false);
		startInfo.SetActive (false);
	}


	//Starting Side Function
	public void SetStartingSide(string StartingSide)
	{
		playerSide = StartingSide; // Set playerSide to Starting Side


		if (playerSide == "X") 
		{
			SetPlayerColours (playerX, playerO);
		} 

		else 
		{
			SetPlayerColours (playerO, playerX);
		}
	
		StartGame (); // Call "StartGame" Function
	}


	//This will set Players buttons
	void SetPlayerButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	//This will set the Players Colour to inactive
	void SetPlayerColoursInactive()
	{
		playerX.panel.color = inactivePlayerColour.panelColour;
		playerX.text.color = inactivePlayerColour.textColour;
		playerO.panel.color = inactivePlayerColour.panelColour;
		playerO.text.color = inactivePlayerColour.textColour;
	}


}
