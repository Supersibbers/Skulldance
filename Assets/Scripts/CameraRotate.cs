using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public float speed = 15f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (0, speed * Time.deltaTime, 0); 
	}
}
