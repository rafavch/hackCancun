using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Contador : MonoBehaviour
{
    public int collisionCount;
    public Text countText;
    public Text winText;

    // Use this for initialization
    void Start()
    {
        collisionCount = 0;
        SetCountText();
        winText.text = "";
    }
    void OnCollisionEnter(Collision collision)
    {
        //Do whatever else you need to do here
        collisionCount += 1;
        print(collisionCount);
    }
    void SetCountText()
    {
        countText.text = "SCORE" + collisionCount.ToString();
        if (collisionCount >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
