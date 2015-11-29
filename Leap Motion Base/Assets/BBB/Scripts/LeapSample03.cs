using UnityEngine;
using System.Collections;
using System;
using Leap;

public class LeapSample03 : MonoBehaviour {
	Controller controller = new Controller();
//	DrawingAttributes touchIndicator = new DrawingAttributes();

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		FingerList fingers = frame.Fingers;
		PointableList pointables = frame.Pointables;
		InteractionBox interactionBox = frame.InteractionBox;

		foreach (var pointable in frame.Pointables) {
			foreach (var finger in frame.Fingers) {
			Leap.Vector normalizedPosition = interactionBox.NormalizePoint(pointable.StabilizedTipPosition);
			float tx = normalizedPosition.x * UnityEngine.Screen.width;
			float ty = UnityEngine.Screen.height - normalizedPosition.y * UnityEngine.Screen.height;

				// 末端骨（指先の骨）
				var bone = finger.Bone(Bone.BoneType.TYPE_METACARPAL);
				if (finger.Type() == Finger.FingerType.TYPE_THUMB) {
						Debug.Log("tx : " + tx + " ty : " + ty + " 距離 : " + pointable.TouchDistance + " 種類 : " + bone.Type);
				}
			int alpha = 255;
			// ホバー状態
			if (pointable.TouchDistance > 0 && pointable.TouchZone != Pointable.Zone.ZONENONE) {
				alpha = 255 - (int)(255 * pointable.TouchDistance);
	//			touchIndicator.Color = Color.FromArgb((byte)alpha, 0x0, 0xff, 0x0);
			}
			}
		}
	}


}
