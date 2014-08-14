using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {
	public GameObject Player;
	public GameObject Boss;
  
    public int BossDamage;
	// These 4 floats are the Coordinates of the Boss Room 
	public float MinX;
	public float MaxX;
	public float MinZ;
	public float MaxZ;
	//values that will be set in the Inspector
	public Transform Target;
	public float RotationSpeed;	
	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;

	private float distance;
	private float direction;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("TEST",0.0f,2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if ((Player.transform.position.x >= MinX) &&
		//    (Player.transform.position.x <= MaxX) &&
		//    (Player.transform.position.z >= MinZ) &&
		//    (Player.transform.position.z <= MaxZ))
		//{
			if(Boss){

               

				//find the vector pointing from our position to the target
				_direction = (Target.position - transform.position).normalized;				
				//create the rotation we need to be in to look at the target
				_lookRotation = Quaternion.LookRotation(_direction);				
				//rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

				print ("Boss Dead");
			}
		//}

	
	}

	void TEST()
	{
		direction = Random.Range(-45.0f,45.0f);
		transform.Rotate(0, direction, 0);
		transform.Translate (0.0f,0.0f,2.5f);

		//find the vector pointing from our position to the target
		_direction = (Target.position - transform.position).normalized;				
		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);				
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
	} 
}
