using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private void OnEnable()
    {
        aim();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aim();
    }

    private void aim()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(x, y));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
