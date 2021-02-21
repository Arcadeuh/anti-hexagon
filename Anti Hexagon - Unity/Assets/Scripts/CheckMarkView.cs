using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMarkView : MonoBehaviour
{
    [SerializeField] private GameObject particles;

    void SetParticlesEnable()
    {
        particles.SetActive(true);
    }
}
