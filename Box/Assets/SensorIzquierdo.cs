using UnityEngine;

using System.Collections;

public class SensorIzquierdo : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        float myPositionIzq = transform.position.x;
        //Prints the position to the Console.
        print(myPositionIzq);
    }
}

