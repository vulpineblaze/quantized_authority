using UnityEngine;
using System.Collections;

public class ScenarioScript : MonoBehaviour {

	public Transform settlement;

	private GenericScenarioScript[] scens;

	// private Random rnd = new Random();
	// Use this for initialization
	void Start () {

	
	    scens = GetComponentsInChildren<GenericScenarioScript>();
	}
	
	void OnLevelWasLoaded(int level) {

		if (scens == null || scens.Length == 0){
			scens = GetComponentsInChildren<GenericScenarioScript>();
		}
    }
	// Update is called once per frame
	void Update () {
		
	    foreach(GenericScenarioScript scen in scens){
			// scen;
			// scen.gameObject.active = true;
			if(scen.settlement == null){
				scen.settlement = settlement;

				scen.gameObject.SetActive(false);

			}
			// gameObject.active = false;
		}

	}

	public void DoThis(){
		int index = Random.Range(0,scens.Length);
		scens[index].gameObject.SetActive(true);
		Debug.Log("Set scenario:"+index+" active. "+scens[index].gameObject.name);
	}
}
