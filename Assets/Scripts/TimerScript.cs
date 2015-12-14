using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	private Transform[] children;

	public bool runThis = true;

	private int skips = 1;

	public int chanceToCircumstance=10;

	public Transform settlement ;
	private SettlementScript ss;

	// Use this for initialization
	void Start () {
		children = new Transform[transform.childCount];
		PopulateChildren();
		ss = settlement.GetComponent<SettlementScript>();
	    
	}
	
	void OnLevelWasLoaded(int level) {

		if (children == null || children.Length == 0){
			PopulateChildren();
		}
	    ss = settlement.GetComponent<SettlementScript>();
    }
	
	// Update is called once per frame
	void Update () {

		if(runThis){
			DoScenario();
			runThis = false;
		}
		if(settlement != null && ss == null){
			ss = settlement.GetComponent<SettlementScript>();
		}
	}

	void PopulateChildren(){
		for(int i = 0; i < 2; ++i){
            children[i] = transform.GetChild(i);
		}
	}

	public void DoScenario(){


		
		Invoke("DoScen", 1.0f);
	}

	public void DoCircumstance(){
		if(chanceToCircumstance > Random.Range(0,99)){
			CircumstanceScript component2 = children[1].gameObject.GetComponent<CircumstanceScript>();
			component2.DoThis();
		}else{
			DoScenario();
		}
	}

	void DoScen(){

		if(skips > 0){
			skips--;
		}else 

		ss.OneYear();

		ScenarioScript component = children[0].gameObject.GetComponent<ScenarioScript>();
		component.DoThis();


	}
}
