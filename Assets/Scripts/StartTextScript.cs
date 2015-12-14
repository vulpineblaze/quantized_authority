using UnityEngine;
using System.Collections;

public class StartTextScript : MonoBehaviour {

	public GUISkin quan_GUISkin;

	private Vector2 pos = new Vector2(40,40);

	public Vector2 size = new Vector2(128,60);

	private string alien_text = "";

	


	// Use this for initialization
	void Start () {
		alien_text += "You have been chosen to lead a pre-industrial civilization to prosperity\n" ;
		alien_text += "They must survive and become technological quickly\n" ;
		alien_text += "So that we may best help them overcome the challenges of space travel\n\n" ;
		alien_text += "Sadly, the Quantum Entanglement Relay is limited to Yes and No answers\n" ;
		alien_text += "  to their questions. Good Luck!\n" ;
		alien_text += "" ;
		alien_text += "" ;
		alien_text += "" ;
	}
	
	void OnLevelWasLoaded(int level) {


	    pos = new Vector2(Screen.width * 0.1f,Screen.height * 0.1f);
    }
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	  {

    	GUI.Label(
	      // X, Y, Width, Height
	      new Rect(pos.x * 1 , 
	      	pos.y , 
	      	size.x, 
	      	size.y),
	      	alien_text,
	      	quan_GUISkin.FindStyle("MostText")
	      );





	    

	  }
}
