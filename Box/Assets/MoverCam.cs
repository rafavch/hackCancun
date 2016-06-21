using UnityEngine;
using System.Collections;

public class MoverCam : MonoBehaviour
{

    private float speed = 2.0f;
    void LateUpdate()
    {
        float posa = GameObject.Find("Head").transform.position.x;
        float posb = GameObject.Find("Head").transform.position.y;
        float posc = GameObject.Find("Head").transform.position.z;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (transform.position.x > 22.0f) // left
        {
            transform.position = new Vector3(22.0f, this.transform.position.y, this.transform.position.z);
        }
        if (transform.position.x < -22.0f) // Right
        {
            transform.position = new Vector3(-22.0f, this.transform.position.y, this.transform.position.z);
        }
        if (transform.position.z > 22.0f) // Up
        { transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 22.0f);
        }
        if (transform.position.z < -22.0f) // Down
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -22.0f);
        }
    }
}
