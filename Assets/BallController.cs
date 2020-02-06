using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	private float visiblePosZ = -6.5f;

	private GameObject gameoverText;

	private GameObject PointText;

	private int Point;

	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find("GameOverText");
		this.PointText = GameObject.Find("PointText");
	}
		
	void Update () {
		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "SmallStarTag"){
			Point += 5;
		} else if (other.gameObject.tag == "LargeStarTag") {
			Point += 10;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			Point += 15;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			Point += 20;
		}
		this.PointText.GetComponent<Text> ().text = Point + "point";
	}
}