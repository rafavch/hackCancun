using UnityEngine;
using System.Collections;

public class SensorRot : MonoBehaviour {

    // Use this for initialization
    public float xRotation;
    // Update is called once per frame
    void LateUpdate () {
        float xRotation = transform.eulerAngles.x;
        print(xRotation);
    }
}
