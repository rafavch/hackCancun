using UnityEngine;

using System.Collections;

public class SensorDerecho : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        float myPositionDer = transform.position.x;
        //Prints the position to the Console.
        print(myPositionDer);
    }
}
