using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectToSpawn;

    public void spawnObject()
    {
        GameObject.Instantiate(gameObjectToSpawn);
    }
}
