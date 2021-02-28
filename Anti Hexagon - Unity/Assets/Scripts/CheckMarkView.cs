using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMarkView : MonoBehaviour
{
    [SerializeField] private GameObject victoryparticles;

    void SetParticlesEnable()
    {
        victoryparticles.SetActive(true);
    }
}
