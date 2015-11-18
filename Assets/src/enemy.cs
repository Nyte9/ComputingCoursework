using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	bool right;
	public float enemySpeed = 1.0f;
	// Use this for initialization
	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "wall"){
			changeDirection();
		}
		print ("collided with: " + c.gameObject.tag);
	}
	void Start () {
		if(Random.Range (0,100) > 50){
			right = true;
		}else{
			right = false;
		}
	}
	
	void changeDirection(){
		right = !right;
	}
	// Update is called once per frame
	void Update () {
		if(right){
				transform.Translate(enemySpeed*Time.deltaTime,0,0);
		}else{
			transform.Translate(-(enemySpeed*Time.deltaTime),0,0);
		}
	}
}
