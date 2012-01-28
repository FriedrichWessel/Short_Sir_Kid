using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {
	
	public GameObject player;
	public ColliderType colliderType;
	
	public enum ColliderType {
		Stop,
		Slow_min,
		Slow_mid,
		Slow_max,
		Deadly,
		NoEffect
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter( Collider obj ) {
		// here enum checks
		if (obj.gameObject.tag == "player") {
			obj.gameObject.renderer.material.color = Color.cyan;
		}
	}
	
	void OnTriggerExit( Collider obj ) {
		// here enum checks
		if (obj.gameObject.tag == "player") {
			obj.gameObject.renderer.material.color = Color.green;
		}
	}
}
