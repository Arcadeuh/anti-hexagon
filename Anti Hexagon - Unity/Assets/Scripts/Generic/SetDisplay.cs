using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDisplay : MonoBehaviour
{
    public void setEnable()
    {
        gameObject.SetActive(true);
    }

    public void setDisable()
    {
        gameObject.SetActive(false);
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
