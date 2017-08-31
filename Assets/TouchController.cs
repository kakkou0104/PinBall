using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle = 30;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HinjiJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint> ();
		//フリッパーの傾きを設定
		SetAngle (this.defaultAngle);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (0 < Input.touchCount) {
			// タッチされている指の数だけ処理
			for (int i = 0; i < Input.touchCount; i++) {
				// タッチ情報をコピー
				Touch tch = Input.GetTouch (i);
			
				//画面左をタッチした時左フリッパーを動かす
				if (tch.phase == TouchPhase.Began && Screen.width / 2 > tch.position.x && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);

				}
		//画面右をタッチした時右フリッパーを動かす
		else if (tch.phase == TouchPhase.Began && Screen.width / 2 < tch.position.x && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);

				}
		//画面から手を離すとフリッパーを元に戻す
				else if (tch.phase == TouchPhase.Ended && Screen.width / 2 > tch.position.x && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				} 
				else if (tch.phase == TouchPhase.Ended && Screen.width / 2 < tch.position.x && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}
	
			
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
