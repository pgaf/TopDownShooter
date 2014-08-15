using UnityEngine;
using System.Collections;

public class health_bar  : MonoBehaviour {





    private float h = 9.8f;
	private bool isDark = true;
	private bool RoomSelf ;
	private Transform MetalBar;
	private TwirlEffect twir;
	private MotionBlur Mblur;
	private float Twircount =0,Mblurcount;




	void Start ()
	{
		MetalBar = GameObject.FindGameObjectWithTag ("MetalBar").transform;
		twir = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<TwirlEffect> ();
		Mblur = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MotionBlur> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(isDark)
		{
		h -= Time.deltaTime * 0.4f;
		h = (h > 3.7f) ? h : 3.7f;
		MetalBar.localScale = new Vector3 (h, MetalBar.localScale.y, MetalBar.localScale.z);
		}
		if(RoomSelf)
		{
			h += Time.deltaTime * 0.2f;
			h = (h < 9.8f) ? h : 9.8f;
			MetalBar.localScale = new Vector3 (h, MetalBar.localScale.y, MetalBar.localScale.z);

			Twircount -= Time.deltaTime*5;
			Twircount = ( Twircount>0)?Twircount:0f;
			twir.angle =Twircount;
			
			Mblurcount -= Time.deltaTime*3;
			Mblurcount = ( Mblurcount> 0)?Mblurcount:0f;
			Mblur.blurAmount =Mblurcount;

		}


		if( h <5 )
		{
			Twircount += Time.deltaTime*3;
			Twircount = ( Twircount< 24.95f)?Twircount:24.95f;
			twir.angle =Twircount;

			Mblurcount += Time.deltaTime*2;
			Mblurcount = ( Mblurcount< 0.7f)?Mblurcount:0.7f;
			Mblur.blurAmount =Mblurcount;

			//Mblur.enabled =true;
		}
	

	}






	void OnTriggerEnter(Collider other)
	{


		if(other.collider.gameObject.tag == "Light")
		{
			isDark = false;
		}

		if(other.collider.gameObject.tag == "RoomS")
		{
			RoomSelf = true;;
			isDark = false;
		}
	}





	void OnTriggerExit(Collider other)
	{

		
		if(other.collider.gameObject.tag == "Light")
		{
			isDark =true;
		}

		if(other.collider.gameObject.tag == "RoomS")
		{
			RoomSelf = false;
			isDark =true;
		}
		
	}








}
