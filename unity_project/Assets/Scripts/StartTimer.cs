using UnityEngine;
using System.Collections;

public class StartTimer : MonoBehaviour {

	public float WaitTime = 4; 
	private float currentTimer;
	
	// Use this for initialization
	void Start () {
		currentTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTimer >= WaitTime)
			Application.LoadLevel(1);
		else
			currentTimer += Time.deltaTime;
	}
}
