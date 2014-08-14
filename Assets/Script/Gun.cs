using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class Gun : MonoBehaviour {


	public enum GunType {taktir,Auto};
	public enum GunTypeSh {GunMormal,ShotGun};

	public GunType guntype;
	public GunTypeSh guntypeSh;
	public AudioClip GunTigger,GunReload,GunPoke;
	public float TimeShoot =2;
	public int dameg;
	public Transform swon;
	public Transform pokeposition;
	public int ReloadTir;



	public Rigidbody poke;

	private int Tir;
	private float timeS,Angless;
	private float timeShootMin;
	private LineRenderer tecerr;



	void Start()
	{
		Tir = ReloadTir;
		timeShootMin = TimeShoot;
		Angless = 0;

		tecerr = GetComponent<LineRenderer> ();
		
	}



	public void GunShoot()
	{
		if(GunTimer() && guntypeSh == GunTypeSh.GunMormal && Tir>0)
		{
		Ray shootRay = new Ray (swon.position, swon.forward);

		RaycastHit hit;

		float dis=20;

		if( Physics.Raycast(shootRay,out hit,dis))
		{
			dis =hit.distance;
			
				if(hit.collider.gameObject.tag == "Enemy")
					hit.collider.gameObject.GetComponent<Entity>().EnemyHit(dameg);
		}

		//Debug.DrawRay (shootRay.origin, shootRay.direction * dis, Color.red,1);
			if(tecerr)
			{
				StartCoroutine("timeLineRenderer" , shootRay.direction*dis);
			}
			Rigidbody p = Instantiate(poke,pokeposition.position,Quaternion.identity) as Rigidbody;
			p.AddForce( pokeposition.forward * Random.Range(100,150) + swon.forward* Random.Range(-10,10));
			audio.PlayOneShot(GunPoke);
			audio.Play();
			timeS = Time.time + timeShootMin;
			Tir --;
		}



		if(GunTimer() && guntypeSh == GunTypeSh.ShotGun && Tir>0)
		{
			RaycastHit [] Hit =new RaycastHit[50];
			float diss =3;
			Ray [] rayShot=new Ray[50];


			//Debug.DrawRay(swon.position,swon.forward,Color.red,1);

			for(int i =0; i<rayShot.Length;i++)
			{

				float x = Mathf.Cos(Angless);
				float y = Mathf.Sin(Angless);
				Vector3 dirc = new Vector3(x,0,y);


				rayShot[i] =new Ray(swon.position,dirc );
				//Debug.DrawRay(rayShot[i].origin,rayShot[i].direction*dis,Color.blue,1);
				Angless +=0.1f;

			}
			Angless = 0;

			for(int i =0;i<rayShot.Length;i++)
			{

				if( Physics.Raycast(rayShot[i],out Hit[i],diss) )
				{
					if(Hit[i].collider.gameObject.tag == "Enemy")
					Hit[i].collider.gameObject.GetComponent<Entity>().EnemyHit(dameg);


				}

			}

			if(tecerr)
			{
				StartCoroutine("timeLineRenderer" , swon.forward*diss);
			}
			Rigidbody p = Instantiate(poke,pokeposition.position,Quaternion.identity) as Rigidbody;
			p.AddForce( pokeposition.forward * Random.Range(100,150) );//+ swon.forward* Random.Range(100,500));
			audio.PlayOneShot(GunPoke);
			
			audio.Play();
			timeS = Time.time + timeShootMin;
			Tir --;
		}


		if(GunTimer()&& Tir<=0)
		{
			audio.PlayOneShot (GunTigger);
			timeS = Time.time + timeShootMin+0.5f;

		}

		
		
	}







	IEnumerator timeLineRenderer(Vector3 hitponit)
	{
		tecerr.enabled = true;
		tecerr.SetPosition (0, swon.position);
		tecerr.SetPosition (1, swon.position + hitponit);
		yield return  new WaitForSeconds(0.02f);
		tecerr.enabled = false;
	}





 public void gunTygeAtShoot()
	{
		if(guntype == GunType.Auto)
		GunShoot ();
	}



	bool GunTimer()
	{
		bool bb = true;

		if (Time.time < timeS)
			bb = false;

		return bb;
	}


	public void Reload()
	{
		Tir = ReloadTir;	
		audio.PlayOneShot (GunReload);
	}



}
