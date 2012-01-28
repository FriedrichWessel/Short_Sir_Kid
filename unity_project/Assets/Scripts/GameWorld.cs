using UnityEngine;
using System.Collections;

public class GameWorld : MonoBehaviour {

	public static GameWorld Instance;
	
	public float MoveSpeed = 0.1f;
	public float JumpHeight = 7.0f;
	public float Gravity = 9.8f; 
	public float JumpGravity = 9.8f;
	public Robot RobotEntity;
	public Predator PredatorEntity;
	public float CheerUpTime = 0.1f;
	public float SpeedIncreaseStep = 0.1f;
	public float BrakeCoolDownTime = 1;
	public float SpeedDecreaseStep = 2;
	public float MinSpeed = 1;
	public float MaxSpeed = 20;
	public float PredatorSpeed = 5;
	public float PredatorMaxDistance = 1;
	public float HardStopperStep = 4;
	public float SoftStopperStep = 2;
	public float SpeedUpStep = 4;
	public float BurstSlowDownStep = 0.5f;
	public float AfterTumblingSpeedUp = 1;
	public float TumbleTime = 2;
	public float PossibilityToJumpWhenCrazy = 10;
	public float PossibilityToStopWhenCrazy = 10;
	public float PossibilityNotToJumpWhenCrazy = 10;
	private bool waitForGameEnd = false;
	private float timeTillGameEnd = 10;
	
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
		if(waitForGameEnd){
			timeTillGameEnd -= Time.deltaTime;
		}
		if(timeTillGameEnd <= 0)
			GameEnd(false, 0);
		
		if(runningTime >= CheerUpTime){

			//Debug.Log("Increase Happyness");
			RobotEntity.IncreaseHappyness();
			runningTime = 0;
		} else 
			runningTime += Time.deltaTime;
		//Debug.Log("Distance: " + (RobotEntity.transform.position.x -  PredatorEntity.transform.position.x));
		if(RobotEntity.transform.position.x -  PredatorEntity.transform.position.x > PredatorMaxDistance){
			//Debug.Log("Predator Pulled");
			var pos = PredatorEntity.transform.position;
			pos.x = RobotEntity.transform.position.x;
			pos.x -= PredatorMaxDistance;
			PredatorEntity.transform.position = pos;
		}
		
			
	}
	
	public void GameEnd(bool winGame){
		GameEnd(winGame, 0);
	}
	public void GameEnd(bool winGame, float time){
		if(time > 0){
			waitForGameEnd = true;
			timeTillGameEnd = time;
			return;
		}
		if(!winGame){ // just start all over again
			Debug.Log("YouSuck!");
			Application.LoadLevel(0);
		} else 
			Application.LoadLevel("EndScreen");
	}
	
}
