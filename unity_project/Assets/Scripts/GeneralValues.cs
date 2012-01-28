using UnityEngine;
using System.Collections;

public class GeneralValues : MonoBehaviour {

	public static GeneralValues Instance;
	
	public float MoveSpeed = 0.1f;
	public float JumpHeight = 7.0f;
	public float Gravity = 9.8f; 
	public Robot RobotEntity;
	
	void Awake(){
		if(Instance != null){
			Debug.Log("Already get an GeneralValues");
		}
		if(Instance == null){
			Instance = this;
		}
	}
	
}
