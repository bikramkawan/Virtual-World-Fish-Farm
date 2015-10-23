using UnityEngine;
using System.Collections;

public class predator_prey : MonoBehaviour {

	// Use this for initialization
	public GameObject fox;
	public GameObject rabbit;
	public float foxdeath_year=10f; //in year
	public float foxbirth_indays=30f;// days
	public float fox_death_no=0f;
	public float fox_birth_no=0f;
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		double Pfoxdeath_rate = (24f*60f*60f /(foxdeath_year * 365f * 24f * 60f * 60f));
		double Pfoxbirth_rate = (24f*60f*60f/(foxbirth_indays * 24f * 60f * 60f));
		//print (Time.time);
		print ("Probability of Fox death rate =" + Pfoxdeath_rate + "Probability of Fox Birth rate=" + Pfoxbirth_rate);
		print(Random.value);
		GameObject clone;
		//for (int i=0; i<=20; i++) {
		//				Instantiate (fox, new Vector3 (Random.Range (-360f, 360f), 0f, Random.Range (-360f, 360f)), Quaternion.identity);
						if (Random.value < Pfoxdeath_rate) {
								Destroy(this);
								fox_death_no++;
						}
						//GameObject clone;
						if (Random.value < Pfoxbirth_rate) {
								Instantiate (fox, new Vector3 (Random.Range (-360f, 360f), 0f, Random.Range (-360f, 360f)), Quaternion.identity);
								fox_birth_no++;
						}
		//		}
	}
}
		                                       ;