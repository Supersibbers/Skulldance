using UnityEngine;
using System.Collections;

public class SkullDance : MonoBehaviour {

	public int detail = 500; //TODO refactor all this stuff about audiolistening onto a script on the main camera, with a view to making packagedate * amplitude a public variable (or a static?)
	public float amplitude = 0.1f;
	public float lerpRate = 0.5f;

	private Vector3 startPosition;
	private Vector3 startScale;

	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float[] info = new float[detail];
		AudioListener.GetOutputData (info, 0);
		float packageData = 0;

		int i;
		for (i = 0; i < info.Length; i++) {
			packageData += System.Math.Abs (info [i]);
		}


		float idealHeight = startPosition.y + packageData * amplitude;
		Vector3 idealPosition = new Vector3 (transform.position.x, idealHeight, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, idealPosition, lerpRate);
	}
}
