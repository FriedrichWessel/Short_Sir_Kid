using UnityEngine;
using System.Collections;

public class HideOnPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<MeshRenderer>())
			renderer.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
