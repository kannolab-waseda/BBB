using UnityEngine;
using System.Collections;
using System;
using Leap;

public class Batter : MonoBehaviour {
	Controller controller = new Controller();
	public float yRotation = -600.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		HandList hands = frame.Hands;

		Hand lHand = frame.Hands[0];
		Debug.Log("左手 : " + lHand.IsLeft + " ピンチ : " + lHand.PinchStrength + " グラブ : " + lHand.GrabStrength + " 信頼性 : " + lHand.Confidence);

		if (Input.GetMouseButton (0) || lHand.GrabStrength > 0.8)
		{
			transform.Rotate(0, yRotation * Time.deltaTime, 0);
		}
	}
}
