using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class BoidController : MonoBehaviour

//=====FlockingBoids=====
//Purpose:Manage a flock of boids
//Create swarm agents in random positon
//Compute flocking centre 
//Compute the way of flock boids
//Processes
//Update commen rules

{
	public float minVelocity = 5;
	public float maxVelocity = 300;
	public float randomness = 1;
	public int flockSize = 20;
	public BoidFlocking prefab;
	public Transform target;
	public float cohesionWeight = 1;      //How far the flocks should stick to the center ( the more weight stick closer to the center)
	public float alignmentWeight = 1;    //Alignment behaviors
	public float separationWeight = 1;  //Determine how far flock should be seperated within the group
	public float followWeight = 1;      //How close the flock should follow to the leader(the more weight make the closer follow)
	public float randomizeWeight = 1;
	internal Vector3 flockCenter;
	internal Vector3 flockVelocity;
	internal Vector3 CohesionCenter;
	internal Vector3 AlignmentVelocity;
	public float fishdeath_year=10f; //in year
	public float fishbirth_year=30f;// days
	public GameObject killfish;

	//StreamWriter sw;

	internal List<BoidFlocking> boids = new List<BoidFlocking>();
	//public ArrayList flockList = new ArrayList();

	void Start()
	{
		for (int i = 0; i < flockSize; i++)
		{
			BoidFlocking boid = Instantiate(prefab, transform.position, transform.rotation) as BoidFlocking;
			boid.transform.parent = transform;
			boid.transform.localPosition = new Vector3(
							Random.value * collider.bounds.size.x,
							Random.value * collider.bounds.size.y,
							Random.value * collider.bounds.size.z) - collider.bounds.extents;
			boid.controller = this;
			boids.Add(boid);

		}
	//	sw = new StreamWriter("count_fox.txt");
	}


	void Update()
	{
		Vector3 center = Vector3.zero;
		Vector3 velocity = Vector3.zero;
		double Pfoxdeath_rate = (24f*60f*60f /(fishdeath_year * 365f * 24f * 60f * 60f));
		double Pfoxbirth_rate = (24f*60f*60f/(fishbirth_year * 24f * 60f * 60f));
		foreach (BoidFlocking boid in boids)
		{
			center += boid.transform.localPosition;
			velocity += boid.rigidbody.velocity;


		}
							
		flockCenter = center / flockSize;
		//print (flockCenter + "flockcenter"+flockSize+"Flocksize");
		//print (flockSize+"Flocksize");
		flockVelocity = velocity / flockSize;


		CohesionCenter = center / (flockSize-1);
		AlignmentVelocity =velocity / (flockSize-1);
		if (Random.value < Pfoxbirth_rate) {
			BoidFlocking boid;	
			boid = Instantiate (prefab, transform.position, Quaternion.identity) as BoidFlocking;
			boid.transform.parent = transform;
			//print (boid + "globallllll");
			boid.transform.localPosition = flockCenter;
//			print (flockCenter + "flockcenternnnnnnnnnnnnnnnnnnnnn");
//			print (boid.transform.localPosition + "localllllllllllll");
//			print (boid.transform.position + "positionnnnnnnnnnnnn");
			boid.controller = this;
			//print("boid controller"+boid.controller);
			boids.Add(boid);
			flockSize =flockSize+1;
			//print(GameObject.FindGameObjectWithTag("fish"));

		
		
		}
		if (Random.value < fishdeath_year) {
			BoidFlocking boid = this.boids[0];	
			boids.Remove(boid);
			Destroy(boid.gameObject);
			flockSize =flockSize-1;

			//print(GameObject.FindGameObjectWithTag("fish"));
			
			
			
		}

	

		GameObject[] names = GameObject.FindGameObjectsWithTag("fish");

		//Destroy(this.boid);
		foreach(GameObject item in names)
		{

						if (Random.value < fishdeath_year)
		
		{	
				print(item);
				//Destroy( GameObject.FindGameObjectWithTag("fish"));
			//Destroy(item);
			print(flockSize+"HHHKK");
		}
		}
		

		
		
		
	}
}