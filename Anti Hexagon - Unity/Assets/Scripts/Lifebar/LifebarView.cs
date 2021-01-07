using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifebarView : MonoBehaviour
{
    [SerializeField] private UnityEvent onLosingHealth;

    public void playLoseHealthAnim()
    {
        onLosingHealth.Invoke();
    }
}
