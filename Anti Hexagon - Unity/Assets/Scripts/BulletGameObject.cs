using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGameObject : MonoBehaviour
{
    public int type;

    public void destroy()
    {
        Debug.Log(gameObject);
        Destroy(gameObject);
    }
}
