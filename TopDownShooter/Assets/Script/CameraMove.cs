using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {


	public float ComSpeedWalk =4;
	public float ComSpeedRun =10;
	public float CamZom =4,CamSpeedInZom =2;

	

	private Transform traget;
	private Vector3 FirstCamPos;
	private Vector3 CamPostition;

	
	private Vector3 CameraZompos; 
	private Vector3 comTraget; 
	private float ComS;

	void Start () 
	{
		FirstCamPos = transform.position;
		CameraZompos = FirstCamPos -new Vector3(0, CamZom,0);
		traget = GameObject.FindGameObjectWithTag ( "Player").transform;	

	}
	

	void Update ()
	{

		CamPostition = (Input.GetMouseButton (1)) ? CameraZompos : FirstCamPos;

		comTraget = new Vector3 (traget.position.x, CamPostition.y, traget.position.z);
		//ComS = (Input.GetButton ("Run")) ? ComSpeedRun : ComSpeedWalk;

		if (Input.GetButton ("Run") && !Input.GetMouseButton (1))
			ComS = ComSpeedRun;
		else if(!Input.GetButton ("Run") && !Input.GetMouseButton (1))
			ComS = ComSpeedWalk;
		else if(!Input.GetButton ("Run") && Input.GetMouseButton (1))
			ComS = CamSpeedInZom;

		transform.position = Vector3.Lerp (transform.position, comTraget, Time.deltaTime *ComS);


	}
}
