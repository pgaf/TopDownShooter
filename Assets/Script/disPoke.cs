using UnityEngine;
using System.Collections;

public class disPoke : MonoBehaviour {




	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		renderer.material.color = Color.Lerp (renderer.material.color, Color.clear, 2 * Time.deltaTime);
		Destroy (gameObject, 1);
	
	}
}
