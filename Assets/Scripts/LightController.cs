using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {


	public float speed = 5f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (speed * Time.deltaTime, 0, 0); 
	}
}
