using UnityEngine;
using System.Collections;

public class _PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "player";
		gameObject.renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKey("a") )
			gameObject.transform.position = new Vector3(gameObject.transform.position.x -0.5f, gameObject.transform.position.y, gameObject.transform.position.z);
		if( Input.GetKey("d") )
			gameObject.transform.position = new Vector3(gameObject.transform.position.x +0.5f, gameObject.transform.position.y, gameObject.transform.position.z);
	}
}
