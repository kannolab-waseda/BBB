using UnityEngine;
using System.Collections;
using System;
using Leap;

public class Batter : MonoBehaviour {
	Controller controller = new Controller();
	public float yRotation = -600.0f;

	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		HandList hands = frame.Hands;

		Hand lHand = frame.Hands[0];
		Debug.Log("左手 : " + lHand.IsLeft + " ピンチ : " + lHand.PinchStrength + " グラブ : " + lHand.GrabStrength + " 信頼性 : " + lHand.Confidence);

		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 3.0f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
		// ワールド座標に変換されたマウス座標を代入
		gameObject.transform.position = screenToWorldPointPosition;

		if (Input.GetMouseButton (0) || lHand.GrabStrength > 0.8)
		{
			transform.Rotate(0, yRotation * Time.deltaTime, 0);
		}
	}
}
