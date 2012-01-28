using UnityEngine;
using System.Collections;

public class EmotionStates  {

	public enum States{
		TooSlow,
		MiddleSlow, 
		MiddleFast,
		TooFast
	}
	
	public float TooSlow = 40;
	public float MiddleSlow = 60;
	public float MiddleFast = 80;
	public float TooFast = 100;
	
	public EmotionStates(){
		
	}
	
	public States GetState(float currentSpeed){
		var minSpeed = GameWorld.Instance.MinSpeed;
		var maxSpeed = GameWorld.Instance.MaxSpeed;
		var statePercentage = ( ( currentSpeed - minSpeed ) / (maxSpeed - minSpeed) ) * (100 - 0) + 0; 
		//Debug.Log("currentSpeed: " + currentSpeed);
		//Debug.Log("Percentage: " + statePercentage);
		if(statePercentage <= TooSlow)
			return States.TooSlow;
		else if(statePercentage <= MiddleSlow)
			return States.MiddleSlow;
		else if (statePercentage <= MiddleFast)
			return States.MiddleFast;
		else 
			return States.TooFast;
			
	}
	
	public float GetStateSpeed(States targetState){
		var maxSpeed = GameWorld.Instance.MaxSpeed;
		if(targetState == EmotionStates.States.TooSlow)
			return maxSpeed * (TooSlow/100);
		else if(targetState == EmotionStates.States.MiddleSlow)
			return maxSpeed * (MiddleSlow/100);
		else if(targetState == EmotionStates.States.MiddleFast)
			return maxSpeed * (MiddleFast/100);
		else if(targetState == EmotionStates.States.TooFast)
			return maxSpeed * (TooFast/100);
		else {
			Debug.LogError("Unkown State requestet: ");
			return 0;
		}
	}
}
