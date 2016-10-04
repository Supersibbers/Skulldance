using UnityEngine;
using System.Collections;

public struct CoOrd {
	public float x;
	public float z;

	CoOrd (float a, float b){
		x = a;
		z = b;
	}

	private CoOrd RandomPolygonVertex (int iteration, int n){
		float foo = Random.Range (-1f, 1f);
		float bar = Random.Range (-1f, 1f);
		return new CoOrd (foo, bar);
	}

	private CoOrd RegularPolygonVertex (int iteration, int n){
		float x = Mathf.Cos((2*Mathf.PI*iteration)/n);
		float z = Mathf.Sin((2*Mathf.PI*iteration)/n);
		return new CoOrd (x, z);
	}

	public static CoOrd[] RegularPolygonVertexArray(int n) { //should also contain ALTERNATE OVERLOADS for offset and those zoomy x and y things
		CoOrd[] coordinates = new CoOrd[n];
		for (int i = 0; i < n; i++) {
			CoOrd current = new CoOrd();
			current = current.RegularPolygonVertex(i,n);
			coordinates [i] = current;
		}
		return coordinates;
	}

}
