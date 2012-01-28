using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {

	public static GameWorld Instance;
	
	public float MoveSpeed = 0.1f;
	public float JumpHeight = 7.0f;
	public float Gravity = 9.8f; 
	public Robot RobotEntity;
	public float CheerUpTime = 0.1f;
	public float SpeedStep = 0.1f;
	public float MinSpeed = 1;
	public float MaxSpeed = 20;
	public EmotionStates Emotions{
		get;
		set;
	}
	private float runningTime = 0.0f;
	
	void Awake(){
		if(Instance != null){
			Debug.Log("Already get an GeneralValues");
		}
		if(Instance == null){
			Instance = this;
		}
		Emotions= new EmotionStates();
	}
	
	void Update(){
		if(runningTime >= CheerUpTime){
			//Debug.Log("Increase Happyness");
			RobotEntity.IncreaseHappyness();
			runningTime = 0;
		} else 
			runningTime += Time.deltaTime;
			
	}
	
	public void GameEnd(bool winGame){
		// Dummy in the moment
		Application.LoadLevel("EndScreen");
	}
	
}
