using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x = 0;
    private float y = 1;

    /*
    private Vector2 aimVector;
    private PlayerControls controls;

    private void Awake()
    {
        Debug.Log("awakening");
        controls = new PlayerControls();
        controls.Player.Aim.performed += ctx => {
            aimVector = ctx.ReadValue<Vector2>();
        };
    }
    */

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
        /*
        Debug.Log(aimVector);
        if (!(aimVector.x == 0 && aimVector.y == 0))
        {
            x = aimVector.x;
            y = aimVector.y;
        }
        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(x, y));
        */

        if (!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }
        float angle = Vector2.SignedAngle(Vector2.up, new Vector2(x, y));

        /*
        if (angle > 22.5 && angle <= 67.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45)); }
        else if (angle > 67.5 && angle <= 112.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90)); }
        else if (angle > 112.5 && angle <= 157.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135)); }
        else if (angle <= -22.5 && angle > -67.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45)); }
        else if (angle <= -67.5 && angle > -112.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90)); }
        else if (angle <= -112.5 && angle > -157.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135)); }
        else if (angle <= 22.5 && angle > -22.5) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); }
        else if ((angle <= 180 && angle > 157.5) || (angle > -180 && angle <= -157.5)) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180)); }
        */
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
