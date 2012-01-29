using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour {
	
		public int LoadLevel = 0;


		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("jump") != 0)
			Application.LoadLevel(LoadLevel);
	}
}
