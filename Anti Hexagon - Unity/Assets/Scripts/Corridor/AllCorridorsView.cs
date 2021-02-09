using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCorridorsView : MonoBehaviour
{
    [SerializeField] private List<Transform> corridors;
    
    public void alternateColor()
    {
        foreach(Transform corridor in corridors)
        {
            corridor.GetComponent<CorridorView>().alternateColor();
        }
    }
    
}
