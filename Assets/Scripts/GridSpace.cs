using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {


	//Declared Variables
	public Button button;
	public Text buttonText;


	private GameController gameController;


	public void SetGameControllerReference(GameController controller)
	{
		gameController = controller; // Setting gameController to the ref controller
	}

	public void SetSpace()
	{
		buttonText.text = gameController.GetPlayerSide (); // Assign the text property
		button.interactable = false; // Making the button non-interactable
		gameController.EndTurn();
	}





}
