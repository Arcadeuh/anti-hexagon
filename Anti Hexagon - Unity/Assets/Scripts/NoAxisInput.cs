using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAxisInput : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    /*
    private Vector2 aimVector;
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Aim.performed += ctx => aimVector = ctx.ReadValue<Vector2>();
        controls.Player.Shoot0.performed += ctx => test();
    }

    void test()
    {
        Debug.Log("THERE");
    }
    */

    private void Start()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Player.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Player.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
        }
    }
}
