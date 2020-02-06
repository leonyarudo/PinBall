using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	private float flickAngle = -20;

		// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint>();

		SetAngle(this.defaultAngle);
	}

	public class TouchManager{
		public bool _touch_flag;
		public Vector2 _touch_position;

	}
	
	// Update is called once per frame
	void Update (){

		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
		for (int i = 0; i < Input.touchCount; i++) {
			var pos = Input.touches[i].position;
			if (pos.x >= Screen.width / 2 && tag == "RightFripperTag") {
				SetAngle (this.flickAngle);
			}
			if (pos.x <= Screen.width / 2 && tag == "LeftFripperTag") {
				SetAngle (this.flickAngle);
			}
			if (Input.GetTouch(i).phase == TouchPhase.Ended && pos.x <= Screen.width / 2 && tag == "LeftFripperTag") {
				SetAngle (this.defaultAngle);
			}
			if (Input.GetTouch(i).phase == TouchPhase.Ended && pos.x >= Screen.width / 2 && tag == "RightFripperTag") {
				SetAngle (this.defaultAngle);
			}
		}
	/*	if (Input.GetMouseButtonDown (0) && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetMouseButtonDown (0) && Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetMouseButtonUp (0) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}					
		if (Input.GetMouseButtonUp (0) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
*/
	}
	public void SetAngle (float angle){
			JointSpring jointSpr = this.myHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.myHingeJoint.spring = jointSpr;
	}
}