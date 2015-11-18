using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed = 5;
	public float gSpeed = 5;
	bool touchingGround;
	bool jumping;
	bool runJump = false;
	public Rigidbody rb;
	float extraJump = 0;
	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "floor"){
			touchingGround = true;
		}
		print ("collided with: " + c.gameObject.tag);
	}

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		input ();
	//	gravity();
	}

	void gravity(){
		if(!isGrounded()){
			transform.Translate(0,-gSpeed*Time.deltaTime,0);
		}
	}

	void input(){
		if(Input.GetKey(KeyCode.LeftArrow)){
			moveLeft ();

		}
		if(Input.GetKey(KeyCode.RightArrow)){
			moveRight();
		}

		if(Input.GetKey(KeyCode.Z)){
			if(runJump){
				extraJump += 0.4f*Time.deltaTime;
			}
		}
		if(Input.GetKeyDown(KeyCode.Z)){
			runJump = true;
		//s	jump();
		}

		if(runJump){
			jump();
		}
	}
	float jTime = 0;
	void jump(){
		float jAcc;

		if(jTime == 0f){
			touchingGround = false;
			jumping = true;
		}
		if(jumping){

			rb.useGravity = false;
			jTime+=1.5f*Time.deltaTime;
			jAcc = 25*Time.deltaTime + extraJump; 
			//if(jTime < jAcc*0.6){
			transform.Translate(0,jAcc-jTime,0);
			//}
		}
		if(touchingGround){
			rb.useGravity = true;
			jumping = false;
			runJump = false;
			jTime = 0;
			extraJump = 0;

		}
	}

	void moveLeft(){
		transform.Translate(-speed*Time.deltaTime,0,0);
	}

	void moveRight(){
		transform.Translate(speed*Time.deltaTime,0,0);
	}

	bool isGrounded(){
		bool gCheck;
		if(touchingGround){
			gCheck = true;
		}else{
			gCheck = false;
		}

		return gCheck;
	}
}
