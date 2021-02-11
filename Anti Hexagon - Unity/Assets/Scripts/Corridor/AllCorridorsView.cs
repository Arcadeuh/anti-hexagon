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

    public void reinitColor()
    {
        foreach (Transform corridor in corridors)
        {
            corridor.GetComponent<CorridorView>().reinitColor();
        }
    }

    public void changeColor(Color newBaseColor, Color newAletrnativeColor)
    {
        for(int i=0; i<corridors.Count; i++)
        {
            if (i % 2 == 0)
            {
                corridors[i].GetComponent<CorridorView>().changeColor(newBaseColor, newAletrnativeColor);
            }
            else
            {
                corridors[i].GetComponent<CorridorView>().changeColor(newAletrnativeColor, newBaseColor);
            }
        }
    }
}
