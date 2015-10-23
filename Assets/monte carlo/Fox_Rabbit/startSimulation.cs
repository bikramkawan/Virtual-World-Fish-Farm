using UnityEngine;
using System.Collections;

	public class startSimulation : MonoBehaviour {
	public GameObject fox_prefab;
	public GameObject rabbit_pref;
	public int fox_atbeginning;
	public int rabbit_atbeginning;
	public float planesize=720f;
	public GameObject plane;
	public countfox foxCounter;
//	public countfox rabbitCounter;
	// Use this for initialization
	void Start () {
		foxCounter.count_fox = 1;
		//foxCounter.count_rabbit = 1;

		for ( int i=0;i<fox_atbeginning;i++)
		{
			foxCounter.count_fox++;
			Instantiate (fox_prefab, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, 
			                                      Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
		}
		for ( int j=0;j<rabbit_atbeginning;j++)
		{
			//foxCounter.count_rabbit++;
			Instantiate (rabbit_pref, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, 
			                                       Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
		}
	}
}
