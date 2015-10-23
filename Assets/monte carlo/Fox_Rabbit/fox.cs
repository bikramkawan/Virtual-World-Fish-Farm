using UnityEngine;
using System.Collections;

public class fox : MonoBehaviour {

	public GameObject startSim;
	// Use this for initialization
	public GameObject fox_prefab;
	public GameObject thisFox;
	public float foxdeath_year=10f; //in year
	public float foxbirth_indays=30f;// days
	public float stepSize = 10f;
	public float eatRate = 0.1f;
	public float planesize=720f;
	public countfox foxCounter;
//	public countfox rabbitCounter;

	GameObject testObj;

	void Start () {
		planesize = startSim.GetComponent<startSimulation>().planesize;
		//myCounter = (FindObjectOfType (typeof(Camera)) as GameObject).GetComponent<count>();
	}

	
	// Update is called once per frame
	void Update () {
		float xpos, zpos;
		xpos = transform.position.x + (Random.value - 0.5f) * stepSize;
		zpos = transform.position.z + (Random.value - 0.5f) * stepSize;
		if (xpos > planesize/2f) {// periodic boundary
			xpos-=planesize;
		}
		else if (xpos < -planesize/2f) {
			xpos+=planesize;
		}
		else if (zpos > planesize/2f) {
			zpos-=planesize;
		}
		else if (zpos < -planesize/2f) {
			zpos+=planesize;
		}
		transform.position = new Vector3 (xpos, 0f, zpos);
				
		double Pfoxdeath_rate = (24f*60f*60f /(foxdeath_year * 365f * 24f * 60f * 60f));
		double Pfoxbirth_rate = (24f*60f*60f/(foxbirth_indays * 24f * 60f * 60f));
		//print (Time.time);
		//print ("Probability of Fox death rate =" + Pfoxdeath_rate + "Probability of Fox Birth rate=" + Pfoxbirth_rate);
		//print(Random.value);

							
		if (Random.value < Pfoxbirth_rate) {
			foxCounter.count_fox++;
			//			Instantiate (fox_prefab, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
			Instantiate (fox_prefab, transform.position, Quaternion.identity);
		}
		else if (Random.value < Pfoxdeath_rate) {
			foxCounter.count_fox--;
			Destroy(thisFox);
			//print ("Fox dead"+foxCounter.count_fox);
		}
		//print (foxcount);
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "rabbit" && Random.value < eatRate)
		{
			foxCounter.count_fox++;
//			foxCounter.count_rabbit--;

		
			Instantiate (fox_prefab, transform.position, Quaternion.identity);
			Destroy(col.gameObject);

			//print ("rabbit --"+foxCounter.count_rabbit--);
		}
	}
}
		                                       ;