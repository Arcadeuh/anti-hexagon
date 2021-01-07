using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAxisInput : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal")==0 && Input.GetAxisRaw("Vertical") == 0)
        {
            Player.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
        }
    }
}
