using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericScenarioScript : MonoBehaviour {

	public GUISkin quan_GUISkin;

	private Vector2 pos = new Vector2(40,40);

	public Vector2 size = new Vector2(128,60);

	public string main_text = "player readable goes here.";

	public Transform settlement;

	private ResourceHolderScript resources;
	private ResourceHolderScript yes;
	private ResourceHolderScript no;

	// public Dictionary<string, double> stuffs; //=             new Dictionary<string, string>();
// 

	// Use this for initialization
	void Start () {
		// stuffs.Add("test",8.0);
		resources = settlement.GetComponent<ResourceHolderScript>();
	}
	
	void OnLevelWasLoaded(int level) {
	    pos = new Vector2(Screen.width * 0.1f,Screen.height * 0.1f);

		// resources = settlement.GetComponent<ResourceHolderScript>();
    }
	
	// Update is called once per frame
	void Update () {
		if(settlement != null && resources == null){
			resources = settlement.GetComponent<ResourceHolderScript>();
		}
		if(yes == null){
			yes = transform.Find("Yes").GetComponent<ResourceHolderScript>();
		}
		if(no == null){
			no = transform.Find("No").GetComponent<ResourceHolderScript>();
		}


		
	}

	void OnGUI()
	{

    	GUI.Label(
	      // X, Y, Width, Height
	      new Rect(pos.x * 1 , 
	      	pos.y , 
	      	size.x, 
	      	size.y),
	      	main_text,
	      	quan_GUISkin.FindStyle("MostText")
	    );



	    const int buttonWidth = 128;
    	const int buttonHeight = 60;



	    // Draw a button to start the game
	    if (GUI.Button(
	      // Center in X, 2/3 of the height in Y
	      new Rect(1*Screen.width / 3 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight),
	      "Yes"
	      ))
	    {
	      // On Click, load the first level.
	      // Application.LoadLevel("Stage1"); // "Stage1" is the scene name
	    	resources.food += yes.food;
	    	closeOut();

	    }

	    if (GUI.Button(
	      // Center in X, 2/3 of the height in Y
	      new Rect(2*Screen.width / 3 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight),
	      "No"
	      ))
	    {
	      // On Click, load the first level.
	      // Application.LoadLevel("Stage1"); // "Stage1" is the scene name
	    	resources.food += no.food;
	    	closeOut();
	    }

	}

	void closeOut(){
		GameObject.Find("Timer").GetComponent<TimerScript>().RunFunction();
		gameObject.SetActive(false);
	}
}
