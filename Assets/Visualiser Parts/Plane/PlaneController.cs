using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {

	public int n;
	public int skips;

	private LineRenderer lineRend;
	private CoOrd[] coordinates;

	// Use this for initialization
	void Start () {
		lineRend = GetComponentInChildren<LineRenderer> ();
		lineRend.SetVertexCount (n + 1);
		coordinates = CoOrd.RegularPolygonVertexArray(n);
	}

	// Update is called once per frame
	void Update () {
		//transform.Rotate (0f, 2f, 0f);
		lineRend.SetPositions (coordinatesToVector3Array (nGramReorder (coordinates)));
	}

	CoOrd[] nGramReorder (CoOrd[] coordinates) {
		CoOrd[] reorderedCoordinates = new CoOrd[coordinates.Length];
		for (int i = 0; i < coordinates.Length; i++) {
			reorderedCoordinates [(i * skips)%coordinates.Length] = coordinates [i];
		}
		return reorderedCoordinates;
	}

	Vector3[] coordinatesToVector3Array(CoOrd[] coordinates){
		Vector3[] output = new Vector3[coordinates.Length + 1];
		int i = 0;
		foreach (CoOrd coordinate in coordinates) {
			output[i] = new Vector3 (coordinate.x * 5, 0f, coordinate.z * 5);
			i++;
		}
		output [coordinates.Length] = output [0];
		return output;
	}
}
