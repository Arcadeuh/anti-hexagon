using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    public void setSpeed(float distance, float time)
    {
        speed = - distance / time;
    }
}
