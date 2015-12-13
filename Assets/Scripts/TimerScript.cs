using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	private Transform[] children;

	public bool runThis = true;

	// Use this for initialization
	void Start () {
		children = new Transform[transform.childCount];
		PopulateChildren();
	    
	}
	
	void OnLevelWasLoaded(int level) {

		if (children == null || children.Length == 0){
			PopulateChildren();
		}
	    
    }
	
	// Update is called once per frame
	void Update () {

		if(runThis){
			RunFunction();
			runThis = false;
		}
	}

	void PopulateChildren(){
		for(int i = 0; i < 2; ++i){
            children[i] = transform.GetChild(i);
		}
	}

	public void RunFunction(){

		// play busy animation

		//increment year

		//activate a scen || circ
		ScenarioScript component = children[0].gameObject.GetComponent<ScenarioScript>();
		component.DoThis();
	}
}
