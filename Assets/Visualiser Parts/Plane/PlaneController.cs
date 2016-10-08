using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneController : MonoBehaviour {

	public int n;
	public int skips;

	private LineRenderer lineRend;
	private List<CoOrd> coordinates;
	private List<CoOrd> idealCoordinates;
	private float transitionTimeInSeconds = 1;
	private bool transitioning = false;


	// Use this for initialization
	void Start () {
		lineRend = GetComponentInChildren<LineRenderer> ();
		lineRend.SetVertexCount (n + 1);
		coordinates = CoOrd.RegularPolygonVertexArray(n);
	}

	void Update () {
		//transform.Rotate (0f, 2f, 0f);
				
		if (Input.GetKeyDown(KeyCode.Space)) {
				changeNumberOfVertecies();
			}

		if (transitioning) {
			for (int i = 0; i < coordinates.Count ; i++) {
				float x = Mathf.Lerp (coordinates[i].x, idealCoordinates [i].x, Time.deltaTime / transitionTimeInSeconds);
				float z = Mathf.Lerp (coordinates[i].z, idealCoordinates [i].z, Time.deltaTime / transitionTimeInSeconds);
				coordinates [i] = new CoOrd (x, z);
			}
		}

		lineRend.SetPositions (coordinatesToVector3Array (nGramReorder (coordinates)));
		//lineRend.SetPositions (coordinatesToVector3Array (coordinates));
	}

	void changeNumberOfVertecies () {
		n += 1;
		coordinates.Add (coordinates [coordinates.Count-1]);
		idealCoordinates = CoOrd.RegularPolygonVertexArray (n);
		lineRend.SetVertexCount (n + 1);
		transitioning = true;
		}

	List<CoOrd> nGramReorder (List<CoOrd> coordinates) {
		List<CoOrd> reorderedCoordinates = new List<CoOrd>();
		for (int i = 0; i < coordinates.Count; i++) {
			reorderedCoordinates.Add(coordinates [(i * skips)% (coordinates.Count)]);
		}
		return reorderedCoordinates;
	} 

	Vector3[] coordinatesToVector3Array(List<CoOrd> coordinates){
		Vector3[] output = new Vector3[coordinates.Count + 1];
		for (int i = 0; i < coordinates.Count; i++) {
			output[i] = new Vector3 (coordinates[i].x * 5, 0f, coordinates[i].z * 5);
		}
		output [coordinates.Count] = output [0];
		return output;
	}
}
