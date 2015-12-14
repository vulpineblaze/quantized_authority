using UnityEngine;
using System.Collections;

public class SettlementScript : MonoBehaviour {

	public GUISkin quan_GUISkin;
	private Vector2 pos = new Vector2(15,15);
	public Vector2 size = new Vector2(128,60);

	public double year = 1000.0;
	// public double faithInYou = 25.0;
	// public double faithInSelf = 25.0;

	private ResourceHolderScript resources;


	public Vector2 foodPos = new Vector2(0.5f,0.5f);
	public Vector2 waterPos = new Vector2(0.5f,0.5f);
	public Vector2 defPos = new Vector2(0.5f,0.5f);
	public Vector2 stockPos = new Vector2(0.5f,0.5f);
	public Vector2 reliPos = new Vector2(0.5f,0.5f);
	public Vector2 eduPos = new Vector2(0.5f,0.5f);
	public Vector2 lumberPos = new Vector2(0.5f,0.5f);
	public Vector2 goldPos = new Vector2(0.5f,0.5f);
	// public Vector2 foodPos = new Vector2(0.5f,0.5f);




	// Use this for initialization
	void Start () {
		resources = transform.GetComponent<ResourceHolderScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(resources == null){
			resources = transform.GetComponent<ResourceHolderScript>();
		}
		if(resources.food > resources.stockpile){
			resources.food = resources.stockpile;
		}
		if(resources.water > resources.stockpile){
			resources.water = resources.stockpile;
		}
		if(resources.lumber > resources.stockpile){
			resources.lumber = resources.stockpile;
		}
		if(resources.gold > resources.stockpile){
			resources.gold = resources.stockpile;
		}
	}

	void OnGUI()
	{
		string HUD = "Year: "+year.ToString("F0")+" | Population: "+resources.population.ToString("F0");
		HUD +=" | Faith in You: "+resources.faithInYou.ToString("F1");
		HUD +=" | Faith in Themselves: "+resources.faithInSelf.ToString("F1");
    	GUI.Label(
	      // X, Y, Width, Height
	      new Rect(pos.x * 1 , 
	      	pos.y , 
	      	size.x, 
	      	size.y),
	      	HUD,
	      	quan_GUISkin.FindStyle("HUDText")
	    );

    	GUI.Label(
	      new Rect(foodPos.x *Screen.width, 
	      	foodPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.food.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(waterPos.x *Screen.width, 
	      	waterPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.water.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(defPos.x *Screen.width, 
	      	defPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.defense.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(stockPos.x *Screen.width, 
	      	stockPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.stockpile.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(reliPos.x *Screen.width, 
	      	reliPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.religion.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(eduPos.x *Screen.width, 
	      	eduPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.education.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(lumberPos.x *Screen.width, 
	      	lumberPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.lumber.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    	GUI.Label(
	      new Rect(goldPos.x *Screen.width, 
	      	goldPos.y *Screen.height, 
	      	size.x, size.y),
	      	resources.gold.ToString("F2"), 	quan_GUISkin.FindStyle("Resources")
	    );

    }

    public void OneYear(){
    	year++;
    	resources.population += (resources.population * (0.05));
    	resources.food -= resources.population/100.0;
    	resources.water -= resources.population/100.0;
    	resources.defense += resources.population/100.0;
    	resources.lumber += resources.population/100.0;
    	resources.gold += resources.population/100.0;
    	resources.education -= (resources.population/100.0)*(resources.religion);
    	resources.religion -= (resources.population/100.0)*(resources.education);
    	resources.faithInSelf += (resources.population/1000.0)*(resources.education);
    	resources.faithInYou += (resources.population/1000.0)*(resources.religion);
    	
    }
}
