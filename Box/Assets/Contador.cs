using UnityEngine;
using System.Collections;

public class Contador : MonoBehaviour {
    public int collisionCount = 0;
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        collisionCount += 1;
       // if (collisionCount > 10){
               //}
       print(collisionCount);
    }
}
