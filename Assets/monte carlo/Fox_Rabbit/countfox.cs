using UnityEngine;
using System.Collections;
using System.IO;


public class countfox : MonoBehaviour {
	public int count_fox;
	//public int count_rabbit;
	public int count_rabbitNEW;
	StreamWriter sw;
	GameObject [] rabbit;
	GameObject [] fox;

	void Start(){
		 sw = new StreamWriter("count_fox.txt");
	}


	void Update(){

		rabbit = GameObject.FindGameObjectsWithTag("rabbit");
		count_rabbitNEW = rabbit.Length;
		sw.WriteLine(" " + count_fox+" "+ count_rabbitNEW+" "+System.DateTime.Now, true);
		sw.Flush();
	
		fox = GameObject.FindGameObjectsWithTag("fox");
		count_fox= fox.Length;
		if (count_fox == 0) {
			Debug.Break ();

					//	Application.Quit ();
				}
		}
	
}