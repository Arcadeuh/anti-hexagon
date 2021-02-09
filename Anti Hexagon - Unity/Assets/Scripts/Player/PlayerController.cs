using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x = 0;
    private float y = 1;
    
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
        if(!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }

        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(x, y));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
