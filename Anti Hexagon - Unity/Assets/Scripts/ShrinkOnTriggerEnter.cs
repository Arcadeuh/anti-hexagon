using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOnTriggerEnter : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            collision.gameObject.GetComponent<TileGameObject>().shrinkXAxis(0.005f);
        }
    }
}
