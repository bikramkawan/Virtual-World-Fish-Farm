using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BoidFlocking : MonoBehaviour
//======Commen Rules====
//Cohesion,Separation,Alignment,Follow
//Set weights for these four force
//Calculate the center of boids
//Calculate the velocity of boids
//Processes
	
//======Cohesion======
//Coh(Pos) = Total(A(j,Pos)-(A(i,Pos))/(Number-1)
//Coh(Dist) = Coh(Pos) - A(i,Pos)
//Coh(Dir) = ||oh(Pos) - A(i,Pos)||
//F(coh) = Coh(Dir)*Gcoh
	
//======Separation======
//relDist = A(j,Pos) -A(i,Pos) 		
//relDist = relDis/[(A(j, Pos) -A(i, Pos)) (A(j, Pos) -A(i, Pos))] 
//Sum(relDist) 
	
//======Alignment======
//Swarms(Speed) = Total(A(j, Speed))/(Number-1) 
//Align(Speed) = (Swarm(Speed) -A(i, Speed)) 

{
	internal BoidController controller;

	StreamWriter sw;

	IEnumerator Start()
	{
		while (true)
		{
			if (controller)
			{
				rigidbody.velocity += steer() * Time.deltaTime;

				// enforce minimum and maximum speeds for the boids
				float speed = rigidbody.velocity.magnitude;
				if (speed > controller.maxVelocity)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * controller.maxVelocity;
				}
				else if (speed < controller.minVelocity)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * controller.minVelocity;
				}
			}
			float waitTime = Random.Range(0.3f, 0.5f);
			yield return new WaitForSeconds(waitTime);
		}
	}

	Vector3 steer()
	{
		//sw = new StreamWriter("c.txt");

		Vector3 randomize = new Vector3((Random.value * 0.5f) - 1, (Random.value * 0.5f) - 1, (Random.value * 0.5f) - 1);
		randomize.Normalize();
		randomize *= controller.randomness;


		Vector3 center = controller.CohesionCenter - transform.localPosition;
		Vector3 velocity = controller.AlignmentVelocity - rigidbody.velocity;
		Vector3 follow = controller.target.localPosition - transform.localPosition;
		Vector3 separation = Vector3.zero; 											// separation


		//print (follow);
		//sw.WriteLine(" " + center+" "+ velocity/*+" "+System.DateTime.Now*/);

		//sw.Flush();

		foreach (BoidFlocking boid in controller.boids)
		{
			if (boid != this) 
			{
				Vector3 relativePos = transform.localPosition - boid.transform.localPosition;
				separation += relativePos / (relativePos.sqrMagnitude);				
			}
		}
		
		return (controller.cohesionWeight*center + 
		        controller.alignmentWeight*velocity + 
		        controller.separationWeight*separation + 
		        controller.followWeight*follow + 
		        controller.randomizeWeight*randomize);
	}	

	
//	public float foxdeath_year=10f; //in year
//	public float foxbirth_indays=30f;// days

//	void Update () {
//		
//		
//		double Pfoxdeath_rate = (24f*60f*60f /(foxdeath_year * 365f * 24f * 60f * 60f));
//		double Pfoxbirth_rate = (24f*60f*60f/(foxbirth_indays * 24f * 60f * 60f));
//		//print (Time.time);
//		//print ("Probability of Fox death rate =" + Pfoxdeath_rate + "Probability of Fox Birth rate=" + Pfoxbirth_rate);
//		print(Random.value+"randomvalue");
//		print ( "foxbirth");
//		
//		
//		if (Random.value < Pfoxbirth_rate) {
//			//foxCounter.count_fox++;
//			//			Instantiate (fox_prefab, new Vector3 (Random.Range (-planesize/2f, planesize/2f), 0f, Random.Range (-planesize/2f, planesize/2f)), Quaternion.identity);
//			Instantiate (this, transform.position, Quaternion.identity);
//		}
//		else if (Random.value < Pfoxdeath_rate) {
//		//	foxCounter.count_fox--;
//			Destroy(this);
//			//print ("Fox dead"+foxCounter.count_fox);
//		}
//		//print (foxcount);
//	}
	}
