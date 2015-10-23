using UnityEngine;
using System.Collections;

public class foxrev1 : MonoBehaviour {
	
	// Use this for initialization
	public GameObject fox_prefab;
	public GameObject thisFox;
	public float foxdeath_year=10f; //in year
	public float foxbirth_indays=30f;// days
	//public float fox_death_no=0f;
	//public float fox_birth_no=0f;
	public float stepSize = 10f;
	public float eatRate = 0.1f;
	public float planesize=720f;
	public int foxnumber=0;
	//public int clone=0;
	//public count myCounter;
	
	void Start () {
		
		//		myCounter = (FindObjectOfType (typeof(Camera)) as GameObject).GetComponent<count>();
		//float platforms = GameObject[];
		//foxnumber = GameObject.FindGameObjectsWithTag("fox");
		
		
		//GameObject[] fox_prefab = GameObject.FindGameObjectsWithTag("fox");
	}
	
	
	// Update is called once per frame
	void Update () {
		//GameObject[] fox_prefab = GameObject.FindGameObjectsWithTag("fox");
		//foxnumber = 0;
		
		//int foxcount = GameObject.FindGameObjectsWithTag ("fox").Length;
		float xpos, zpos;
		xpos = transform.position.x + (Random.value - 0.5f) * stepSize;
		zpos = transform.position.z + (Random.value - 0.5f) * stepSize;
		if (xpos > planesize/2f) {
			xpos-=planesize;
		}
		if (xpos < -planesize/2f) {
			xpos+=planesize;
		}
		if (zpos > planesize/2f) {
			zpos-=planesize;
		}
		if (zpos < -planesize/2f) {
			zpos+=planesize;
		}
		transform.position = new Vector3 (xpos, 0f, zpos);
		
		double Pfoxdeath_rate = (24f*60f*60f /(foxdeath_year * 365f * 24f * 60f * 60f));
		double Pfoxbirth_rate = (24f*60f*60f/(foxbirth_indays * 24f * 60f * 60f));
		//print (Time.time);
		//print ("Probability of Fox death rate =" + Pfoxdeath_rate + "Probability of Fox Birth rate=" + Pfoxbirth_rate);
		//print(Random.value);
		GameObject clone;
		//	print (foxnumber);
		
		if (Random.value < Pfoxdeath_rate) {
			Destroy(thisFox);
			int foxcount_dead = GameObject.FindGameObjectsWithTag ("fox").Length;
			foxcount_dead++;
			print ("Foxdeath"+foxcount_dead);	
			//	myCounter.counter--;
		}
		//GameObject clone;
		if (Random.value < Pfoxbirth_rate) {
			Instantiate (fox_prefab, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
			
			int foxcount_birth = GameObject.FindGameObjectsWithTag ("fox").Length;
			foxcount_birth++;
			print ("Foxbirth"+foxcount_birth);	
			
			//	myCounter.counter++;
		}
		
		//print (foxcount);
	}
	
	void OnTriggerEnter (Collider col)
	{
		GameObject clone;
		if(col.gameObject.tag == "rabbit" && Random.value > eatRate)
		{
			Destroy(col.gameObject);
			Instantiate (fox_prefab, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
			int foxcount_birth1 = GameObject.FindGameObjectsWithTag ("fox").Length;
			foxcount_birth1++;
			print ("Foxbirth1"+foxcount_birth1);	
			//foxnumber++;
			//	myCounter.counter++;
		}			
	}
	
}
;