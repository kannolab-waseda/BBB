using UnityEngine;
using System.Collections;
using System;
using Leap;

public class LeapSample02 : MonoBehaviour {
	Controller controller = new Controller();

	public GUIText guitext;
	public int handId = -1;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		HandList hands = frame.Hands;
		FingerList fingers = frame.Fingers;
//		PointableList pointables = frame.Pointables;
		Hand rHand = frame.Hands[0];

//		Debug.Log("Hands : " + hands.Count + " Fingers : " + fingers.Count + " Extended Fingers : " + fingers.Extended().Count);
//		Debug.Log("左 : " + hands.Leftmost.PalmPosition + " 右 : " + hands.Rightmost.PalmPosition);
//		Debug.Log("右手 : " + rHand.IsRight + " ピンチ : " + rHand.PinchStrength + " グラブ : " + rHand.GrabStrength + " 信頼性 : " + rHand.Confidence);

		if (handId == -1) {
			handId = frame.Hands[0].Id;
		} else {
			Hand hand = frame.Hand(handId);
			handId = hand.Id;

//			Debug.Log(handId + " " + hand.PalmPosition);
			/*
				速度は	hand.PalmVelocity
				法線は	hand.PalmNormal
				向きは	hand.Direction
				で表示される
			*/
		}

/*
		// 手に属している指を取得する
		foreach (var hand in frame.Hands) {
			Debug.Log("ID : " + hand.Id + " 指 : " + hand.Fingers.Count);
		}
*/
/*
		// 指の情報を表示する
		foreach (var finger in frame.Fingers) {
			if (finger.Type() == Finger.FingerType.TYPE_INDEX) {
				Debug.Log("ID : " + finger.Id + " 種類 : " + finger.Type() + " 位置 : " + finger.TipPosition);
			}
		}
*/

		// 指の関節情報を取得する
		foreach (var finger in frame.Fingers) {
			// 末端骨（指先の骨）
			var bone = finger.Bone(Bone.BoneType.TYPE_METACARPAL);
			if (finger.Type() == Finger.FingerType.TYPE_THUMB) {
				Debug.Log("種類 : " + bone.Type + " 長さ :" + bone.Length);
			}
		}

	}

	void OnGUI() {
//		GUI.Label (new Rect (0, 0, 100, 30), "Hello World!");
	}
}
