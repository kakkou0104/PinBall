using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

	private int score = 0;

	//スコアを表示するテキスト
	public GameObject scoreText;

	// Use this for initialization
	void Start () {
		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find ("ScoreText");
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	//衝突時に呼び出される関数
	void OnCollisionEnter(Collision collision){

		//衝突したオブジェクトのタグによって得点を加算
		if (collision.gameObject.tag == "SmallStarTag") {
			score += 10;
		} else if (collision.gameObject.tag == "LargeStarTag") {
			score += 20;
		} else if (collision.gameObject.tag == "SmallCloudTag") {
			score += 30;
		} else if (collision.gameObject.tag == "LargeCloudTag") {
			score += 40;
		}

		//SetScore関数の呼び出し
		SetScore ();
	}

	//SetScore関数の宣言
	void SetScore(){
		//ScoreTextにスコアを表示
		this.scoreText.GetComponent<Text> ().text = "score : " + score;
	}

}
