using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {


	public float hitEenemy;
	private float hitE;
	

	public void EnemyHit(int dameg )
	{
		hitE -= dameg;
		if (hitE / hitEenemy < 0.7f)
			renderer.material.color =	Color.Lerp (renderer.material.color, Color.red, 10 * Time.deltaTime);
		if (hitE / hitEenemy < 0.6f)
			renderer.material.color =	Color.Lerp (renderer.material.color, Color.clear, 20 * Time.deltaTime);
		if (hitE <= 0)
						Destroy (gameObject);
	}



	void Start () 
	{
			hitE = hitEenemy;
	}

	void Update () {


	
	}
}
