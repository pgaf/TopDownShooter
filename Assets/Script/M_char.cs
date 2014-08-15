using UnityEngine;
using System.Collections;


[RequireComponent (typeof (CharacterController))]

public class M_char : MonoBehaviour {


	public float SpeedRrotation = 450;
	public float RunSpeed = 10;
	public float WalkSpeed = 2,SpeedInZom =0.5f;
	public Gun [] GUN;
	public Transform hand;


	public  Light light;
	private Gun  G;
	private Quaternion tragetQuatetnion;
	private Camera cam;
	private CharacterController CharConttoller;


	void Start () 
	{
		light.intensity = PlayerHealth.FlashLightIntensity;
		cam = Camera.main;
		CharConttoller = GetComponent<CharacterController> ();
		SwitchGun (0);
	}
	

	void Update () 
	{
		if (Input.GetMouseButton (1))
						light.intensity = 1.08f;
		else
			light.intensity = PlayerHealth.FlashLightIntensity;


		controllerWASD ();

		if(G)
		{
		if (Input.GetMouseButton (1) && Input.GetMouseButtonDown (0))
						G.GunShoot ();
		if (Input.GetMouseButton (1) && Input.GetMouseButton (0))
						G.gunTygeAtShoot ();

			if(Input.GetKeyDown("r") )
				G.Reload();
		}

		for(int i=0;i<GUN.Length;i++)
		{
			if(Input.GetKeyDown( (i+1)+""))
			{
				SwitchGun(i);
				break;
			}
		}

	}






	void SwitchGun(int i)
	{
		if(G)
		{
			///Destroy( G.gameObject);
			G.gameObject.SetActive(false);
		}
		//G = Instantiate (GUN [i], hand.position, hand.rotation) as Gun;

		//G.transform.parent = hand;
		GUN [i].gameObject.SetActive (true);

		G = GUN [i] ;

	}



	void controllerWASD()
	{
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

		if(Input.GetMouseButton(1) )
		{
			Vector3 mous = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y));
			Quaternion tragetMous = Quaternion.LookRotation (mous - transform.position);

			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,tragetMous.eulerAngles.y ,SpeedRrotation * Time.deltaTime);
		}
		else if( input != Vector3.zero )
		{
			tragetQuatetnion = Quaternion.LookRotation (input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,tragetQuatetnion.eulerAngles.y ,SpeedRrotation * Time.deltaTime);
		}

		
		Vector3 motion = input;
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.x) == 1) ? 0.7f : 1;

		if (Input.GetButton ("Run") && !Input.GetMouseButton (1))
			      motion *= RunSpeed;
		else if(!Input.GetButton ("Run") && !Input.GetMouseButton (1))
			    motion *= WalkSpeed;
		else if(!Input.GetButton ("Run") && Input.GetMouseButton (1))
			    motion *= SpeedInZom;
		else
		    	motion *= SpeedInZom;

		
		motion += Vector3.up * -8;
		
		CharConttoller.Move (motion * Time.deltaTime);
	}
}
