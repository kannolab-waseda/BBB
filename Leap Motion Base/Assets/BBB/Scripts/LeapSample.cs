using UnityEngine;
using System.Collections;
using Leap;

public class LeapSample : MonoBehaviour {
    Controller controller = new Controller();
    //指の数をカウント
    public int FingerCount;
    public GameObject[] FingerObjects;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        FingerCount = frame.Fingers.Count;
        //指が有効であればInteractionBoxオブジェクトを使ってLeapMotionの座標系をディスプレイ座標系に変換する
        InteractionBox interactionBox = frame.InteractionBox;

        Hand hand = frame.Hands.Rightmost;
        float strength = hand.GrabStrength;
//        Debug.Log (strength);

        for ( int i = 0; i < FingerObjects.Length; i++ ) {
            var leapFinger = frame.Fingers[i];
            var unityFinger = FingerObjects[i];
            SetVisible( unityFinger, leapFinger.IsValid );
            if ( leapFinger.IsValid ) {
                Vector normalizedPosition = interactionBox.NormalizePoint(leapFinger.TipPosition );
                normalizedPosition *= 10;
                normalizedPosition.z = -normalizedPosition.z;
                unityFinger.transform.localPosition = ToVector3( normalizedPosition );

            }
        }
    }

    //検出した指の有効/無効状態いよって、Sphereの表示と非表示をする。
    void SetVisible( GameObject obj, bool visible )
    {
        foreach( Renderer component in obj.GetComponents<Renderer>() ) {
            component.enabled = visible;
        }
    }

    Vector3 ToVector3( Vector v )
    {
        return new UnityEngine.Vector3( v.x, v.y, v.z );
    }
}
