using UnityEngine;
using System.Collections;

public class EnemyTest : MonoBehaviour {

	public float r;

	private Animator A;
	private Transform target;
	private NavMeshAgent Nmv;
	private bool IsSightEnemy;
	private bool outSightEnemy;
	private float HitDis;
	private float Timer;
	// Use this for initialization
	void Start () {
		A = GetComponent<Animator> ();
		Nmv = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		renderer.enabled = true;
		NavMeshHit hit;
		if (!Nmv.Raycast (target.position, out hit))
		{
			HitDis = hit.distance;
		}


		if (IsSightEnemy )
		{
						Nmv.SetDestination (target.position );
			//A.SetBool("m",false);
			A.enabled = false;
		}
		else if(!IsSightEnemy )
		{
			A.SetBool("m",true);

		}

		if(HitDis <1.4f)
			Nmv.velocity = Vector3.zero;
						


	
	}





	void OnTriggerEnter(Collider other) 
	{
		IsSightEnemy = false;

		if (other.collider.tag == "Player") {
			NavMeshHit hit;
			if (!Nmv.Raycast (target.position, out hit)) 
			{
				IsSightEnemy =true;

			}

		}
	}

	void OnCollisionStay(Collision collisionInfo) 
	{

	}

	void OnTriggerExit(Collider other) 
	{
		Timer = Time.time +5;
		if (other.collider.tag == "Player" ) {
			//print("asdafasf");
			IsSightEnemy =true;
		}

	}




}
