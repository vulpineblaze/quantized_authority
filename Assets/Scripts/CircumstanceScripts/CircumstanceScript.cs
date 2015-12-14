using UnityEngine;
using System.Collections;

public class CircumstanceScript : MonoBehaviour {

	public Transform settlement;

	private GenericCircumstanceScript[] circs;

	// private Random rnd = new Random();
	// Use this for initialization
	void Start () {

	
	    circs = GetComponentsInChildren<GenericCircumstanceScript>();
	}
	
	void OnLevelWasLoaded(int level) {

		if (circs == null || circs.Length == 0){
			circs = GetComponentsInChildren<GenericCircumstanceScript>();
		}
    }
	// Update is called once per frame
	void Update () {
		
	    foreach(GenericCircumstanceScript circ in circs){
			// circ;
			// circ.gameObject.active = true;
			if(circ.settlement == null){
				circ.settlement = settlement;

				circ.gameObject.SetActive(false);

			}
			// gameObject.active = false;
		}

	}

	public void DoThis(){
		int index = Random.Range(0,circs.Length);
		circs[index].gameObject.SetActive(true);
		Debug.Log("Set scenario:"+index+" active. "+circs[index].gameObject.name);
	}

	
}
