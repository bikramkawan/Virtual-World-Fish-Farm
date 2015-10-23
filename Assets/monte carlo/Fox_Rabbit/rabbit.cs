using UnityEngine;
using System.Collections;

public class rabbit : MonoBehaviour {

	// Use this for initialization

	public GameObject startSim;
//	public GameObject thisrabbit;
	public GameObject rabbit_prefab;
	public float rabbitdeath_year=10f; //in year
	public float rabbitbirth_indays=30f;// days
	public float stepSize = 10f;
	public float planesize=720f;
	public countfox foxCounter;

	void Start () {
		planesize = startSim.GetComponent<startSimulation>().planesize;
	}

	
	// Update is called once per frame
	void Update () {
		float xpos, zpos;
		xpos = transform.position.x + (Random.value - 0.5f) * stepSize;
		zpos = transform.position.z + (Random.value - 0.5f) * stepSize;
		if (xpos > planesize/2f) {
			xpos-=planesize;
		}
		else if (xpos < -planesize/2f) {
			xpos+=planesize/2f;
		}
		else if (zpos > planesize/2f) {
			zpos-=planesize/2f;
		}
		else if (zpos < -planesize/2f) {
			zpos+=planesize;
		}
		transform.position = new Vector3 (xpos, 0f, zpos);
				
		double Probability_rabbitxdeath = (24f*60f*60f /(rabbitdeath_year * 365f * 24f * 60f * 60f));

		double Probability_rabbitbirth = (24f*60f*60f/(rabbitbirth_indays * 24f * 60f * 60f));
				
		/*if (Random.value < Probability_rabbitxdeath) {
			foxCounter.count_rabbit--;
			print ("rabbitxdeath");
			Destroy(thisrabbit);							
		}			
		else*/ if (Random.value < Probability_rabbitbirth) {
			//Instantiate (rabbit_prefab, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
			//foxCounter.count_rabbit++;

			Instantiate (rabbit_prefab, transform.position, Quaternion.identity);
		}
		//		}
	}
}
		                                       
