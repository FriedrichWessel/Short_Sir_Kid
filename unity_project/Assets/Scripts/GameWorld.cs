using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {

	public static GameWorld Instance;
	
	public float MoveSpeed = 0.1f;
	public float JumpHeight = 7.0f;
	public float Gravity = 9.8f; 
	public Robot RobotEntity;
	public Predator PredatorEntity;
	public float CheerUpTime = 0.1f;
	public float SpeedStep = 0.1f;
	public float MinSpeed = 1;
	public float MaxSpeed = 20;
	public float PredatorSpeed = 5;
	public float PredatorMaxDistance = 1;
	
	
	private float runningTime = 0.0f;
	
	
	public EmotionStates Emotions{
		get;
		set;
	}

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
		Debug.Log("Distance: " + (RobotEntity.transform.position.x -  PredatorEntity.transform.position.x));
		if(RobotEntity.transform.position.x -  PredatorEntity.transform.position.x > PredatorMaxDistance){
			Debug.Log("Predator Pulled");
			var pos = RobotEntity.transform.position;
			pos.x -= PredatorMaxDistance;
			PredatorEntity.transform.position = pos;
		}
			
	}
	
	public void GameEnd(bool winGame){
		if(!winGame){ // just start all over again
			Debug.Log("YouSuck!");
			Application.LoadLevel(0);
		} else 
			Application.LoadLevel("EndScreen");
	}
	
}
