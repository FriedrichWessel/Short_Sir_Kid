using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	private float generalMoveSpeed;
	private float currentSpeed;
	private float jumpHeight;
	private float gravity;
	private float jumpingGravity;
	private float increaseSteps;
	private float decreaseSteps;
	private float maxSpeed; 
	private float minSpeed;
	private float afterTumblingSpeedUp;
	
	private float targetTumbleTime;
	private float timeTumbling;
	private bool tumbling = false;
	private bool startJump = false;
	private bool jumping = false;
	private AnimatedUVBehaviour movieTexture;
	private float standardFrameRate;
	private Quaternion standardRotation;
	
	public Texture2D sadTexture;
	public Texture2D normalTexture;
	public Texture2D crazyTexture;
	
	public Rigidbody Torso;
	public Rigidbody Leg1;
	public Rigidbody Leg2;
	public Rigidbody Arm1;
	public Rigidbody Arm2;
	public Rigidbody Head;
	
	private Vector3 lastPosition;
	public bool AfterTumbling{
		get;
		private set;
	}
	public EmotionStates.States currentState{
		get;
		private set;
	} 
	private EmotionStates.States lastState;
	private CharacterController charControler;
	
	private Vector3 currentDirection;
	//private CharacterController charControler;
	// Use this for initialization
	void Start () {
		Debug.Log("Start Robot");
		generalMoveSpeed = GameWorld.Instance.MoveSpeed;
		jumpHeight = GameWorld.Instance.JumpHeight;
		currentDirection = new Vector3(generalMoveSpeed,0,0);
		gravity = GameWorld.Instance.Gravity;
		jumpingGravity = GameWorld.Instance.JumpGravity;
		currentSpeed = generalMoveSpeed;
		increaseSteps = GameWorld.Instance.SpeedIncreaseStep;
		decreaseSteps = GameWorld.Instance.SpeedDecreaseStep;
		minSpeed = GameWorld.Instance.MinSpeed;
		maxSpeed = GameWorld.Instance.MaxSpeed;
		currentState = GameWorld.Instance.Emotions.GetState(currentSpeed);
		targetTumbleTime = 0;
		timeTumbling = 0;
		lastState = currentState;
		AfterTumbling = false;
		afterTumblingSpeedUp = GameWorld.Instance.AfterTumblingSpeedUp;
		jumping = false;
		movieTexture = gameObject.GetComponent<AnimatedUVBehaviour>() as AnimatedUVBehaviour;
		standardFrameRate = movieTexture.MovieSpeedFPS;
		lastPosition = currentDirection;
		standardRotation = gameObject.transform.rotation;
		movieTexture.Textures[0] = sadTexture;
		movieTexture.ReloadTexture();
		
		Torso.gameObject.renderer.enabled = false;
		Leg1.gameObject.renderer.enabled = false;
		Leg2.gameObject.renderer.enabled = false;
		Arm1.gameObject.renderer.enabled = false;
		Arm2.gameObject.renderer.enabled = false;
		Head.gameObject.renderer.enabled = false;
		
		
		
		charControler = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(tumbling){
			timeTumbling += Time.deltaTime;
			if(timeTumbling >= targetTumbleTime){
				currentSpeed = 0;
				tumbling = false;
				timeTumbling = 0;
			}
		} else if(AfterTumbling){
			//currentSpeed += afterTumblingSpeedUp;
			IncreaseHappyness(afterTumblingSpeedUp);
			if(currentSpeed == minSpeed)
				AfterTumbling = false;
		} 
		else {
			if(!charControler.isGrounded && startJump){
				//Debug.Log("start Jump");
				jumping = true;
				startJump = false;
			} else if(charControler.isGrounded && jumping){
				jumping = false;
			} else if(jumping){
				movieTexture.MovieSpeedFPS = 0;
			}
				
			calculateDirection();
			move(currentDirection);	
		}
		
	}
	
	private void calculateDirection(){
		lastPosition = gameObject.transform.position;
		currentDirection.x = currentSpeed;
		if(jumping){
			//Debug.Log("Jump Gravity");
			if(!charControler.isGrounded)
				currentDirection.y -= jumpingGravity * Time.deltaTime;
			//else 
				//currentDirection.y = 0;
		}else {
			//Debug.Log("normal Grav");
			if(!charControler.isGrounded)
				currentDirection.y -= gravity * Time.deltaTime;
			//else 
				//currentDirection.y = 0;
		}
		
		
	}
	
	private void move(Vector3 direction){
		
		if(charControler != null){
			charControler.Move(direction * Time.deltaTime);
		}
		if(currentState == EmotionStates.States.TooFast){
			GoCrazy();
		}
		else{// check for normal Rotation
			var currentPosition = gameObject.transform.position;
			//Debug.Log("DirectionChange; " + (currentPosition.y - lastPosition.y));
			if(currentPosition.y - lastPosition.y < 0 ){
				//Debug.Log("Down");
				if(charControler.isGrounded)
					gameObject.transform.Rotate(0,0,60*Time.deltaTime);
			} else if(currentPosition.y - lastPosition.y > 0 ){
				//Debug.Log("Up");
				if(charControler.isGrounded)
					gameObject.transform.Rotate(0,0,-60*Time.deltaTime);
			} else {
				//Debug.Log("Normal");
				gameObject.transform.rotation = standardRotation;
			}		
		}
		
		
	}
	
	public void GoCrazy(){
		var currentPosition = gameObject.transform.position;
		//Debug.Log("DirectionChange; " + (currentPosition.y - lastPosition.y));
		if(currentPosition.y - lastPosition.y < 0 ){
			//Debug.Log("Down");
			gameObject.transform.Rotate(0,0,-10);
		} else if(currentPosition.y - lastPosition.y > 0 ){
			//Debug.Log("Up");
			gameObject.transform.Rotate(0,0,-10);
		} //else
			//Debug.Log("Normal");
	}
	
	public void Jump(float height){
		if(charControler.isGrounded){
			//Debug.Log("jump");
			currentDirection.y =  height;
			startJump = true;
			movieTexture.MovieSpeedFPS = 0;
			
			//jumping = true;
		}
	}
	public void Jump(){
		Jump(jumpHeight);
			
	}
	
	public void Hit(){
		if(!charControler.isGrounded)
			return;
		if(GameWorld.Instance.Emotions.GetState(currentSpeed) == EmotionStates.States.TooFast)
			currentSpeed = GameWorld.Instance.Emotions.GetStateSpeed(EmotionStates.States.TooSlow);
		else 
			DecreaseHappyness(decreaseSteps);
	}
	public void IncreaseHappyness(){
		IncreaseHappyness(increaseSteps);
	}
	
	public void DecreaseHappyness(){
		//Debug.Log("Decreas Happyness");
		DecreaseHappyness(decreaseSteps);
		
	}
	
	public void IncreaseHappyness(float changeValue){
		IncreaseSpeed(changeValue);
		checkEmotionState();
	}
	
	public void DecreaseHappyness(float changeValue){
		DecreaseSpeed(changeValue);
		checkEmotionState();
	}
	
	private void IncreaseSpeed(float difference){
		currentSpeed += difference;
		if(currentSpeed >= maxSpeed)
			currentSpeed = maxSpeed;
		// calculate animation Playback speed
		var diff = (currentSpeed - generalMoveSpeed)*0.1f ;
		diff += 1;
		
		float value = standardFrameRate * diff ;
		if(!jumping)
			movieTexture.MovieSpeedFPS = (int)value;
		
		
	}
	
	private void DecreaseSpeed(float difference){
		currentSpeed -= difference;
		if(currentSpeed <= minSpeed)
			currentSpeed = minSpeed;
		
	}
	
	public void Tumble(float time){
		//Debug.Log("Tumble");
		currentSpeed = 0;
		tumbling = true;
	}
	
	private void checkEmotionState(){
		// Just a Dummy
		currentState = GameWorld.Instance.Emotions.GetState(currentSpeed);
		//Debug.Log("currentState: " + currentState);
		if(lastState != currentState){
			if(currentState == EmotionStates.States.TooFast){
				Debug.Log("Reached To Fast");
				IncreaseSpeed(maxSpeed);
				// Do Graphic Changes here
				movieTexture.Textures[0] = crazyTexture;
				movieTexture.ReloadTexture();
			} else if(currentState == EmotionStates.States.TooSlow){
				Debug.Log("Reached Too Slow");
				DecreaseSpeed(maxSpeed);
				// Do Graphic Changes here
				movieTexture.Textures[0] = sadTexture;
				movieTexture.ReloadTexture();
			} else{
				movieTexture.Textures[0] = normalTexture;
				movieTexture.ReloadTexture();
			}
				
			lastState = currentState ;	
		}
		
		
	}
	
	public void Die(){
		var position = gameObject.transform.position;
		
		Torso.gameObject.transform.position = position;
		Head.gameObject.transform.position = position;
		Leg1.gameObject.transform.position = position;
		Leg2.gameObject.transform.position = position;
		Arm1.gameObject.transform.position = position;
		Arm2.gameObject.transform.position = position;
		
		Torso.gameObject.renderer.enabled = true;
		Leg1.gameObject.renderer.enabled = true;
		Leg2.gameObject.renderer.enabled = true;
		Arm1.gameObject.renderer.enabled = true;
		Arm2.gameObject.renderer.enabled = true;
		Head.gameObject.renderer.enabled = true;
		
		
		currentSpeed = 0;
		gameObject.renderer.enabled = false;
		Torso.useGravity = true;
		Leg1.useGravity = true;
		Leg2.useGravity = true;
		Arm1.useGravity = true;
		Arm2.useGravity = true;
		Head.useGravity = true;
		
		var force = 10;
		Torso.AddExplosionForce(1,position,force);
		Leg1.AddExplosionForce(1,position,force);
		Leg2.AddExplosionForce(1,position,force);
		Arm1.AddExplosionForce(1,position,force);
		Arm2.AddExplosionForce(1,position,force);
		Head.AddExplosionForce(1,position,force);
		
		var boom = gameObject.GetComponentInChildren<Detonator>() as Detonator;
		if(boom != null)
			boom.Explode();
		
	}
	
}
