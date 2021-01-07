using UnityEngine;

public class TileGameObject : MonoBehaviour
{
    public int type = 0;
    //CHANGER ACCESSIBILITE DE CORRIDOR
    public GameObject corridor;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "CorridorSide")
        {
            GetComponent<TileGameObject>().shrinkXAxis(0.005f);
        }
    }

    public void shrinkXAxis(float value)
    {
        transform.localScale = transform.localScale - new Vector3(value, 0, 0);
    }

    public void setCorridor(GameObject newCorridor)
    {
        corridor = newCorridor;
    }
}
