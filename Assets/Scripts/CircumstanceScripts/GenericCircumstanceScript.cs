using UnityEngine;
using System.Collections;

public class GenericCircumstanceScript : MonoBehaviour {

	public GUISkin quan_GUISkin;

	private Vector2 pos = new Vector2(40,40);

	public Vector2 size = new Vector2(128,60);

	public string main_text = "player readable goes here.";

	public Transform settlement;

	private ResourceHolderScript resources;
	private ResourceHolderScript always;

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
		if(always == null){
			always = transform.GetComponent<ResourceHolderScript>();
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

    	// Time.timeScale = 0;

    	if (GUI.Button(
	      // Center in X, 2/3 of the height in Y
	      new Rect(Screen.width / 2 - (buttonWidth / 2), (3 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight),
	      "Ok"
	      ))
	    {
	      // On Click, load the first level.
	      // Application.LoadLevel("Stage1"); // "Stage1" is the scene name
	    	resources.food += always.food;
	    	resources.water += always.water;
	    	resources.defense += always.defense;
	    	resources.stockpile += always.stockpile;
	    	resources.religion += always.religion;
	    	resources.education += always.education;
	    	resources.lumber += always.lumber;
	    	resources.gold += always.gold;
	    	resources.population += always.population;
	    	resources.faithInYou += always.faithInYou;
	    	resources.faithInSelf += always.faithInSelf;
	    	// Time.timeScale = 1;
	    	closeOut();
	    }


	}

	void closeOut(){
		GameObject.Find("Timer").GetComponent<TimerScript>().DoScenario();
		gameObject.SetActive(false);
	}
}
