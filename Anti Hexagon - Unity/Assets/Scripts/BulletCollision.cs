using UnityEngine;
using UnityEngine.Events;

public class BulletCollision : MonoBehaviour
{
    private ScoreModel score;

    public void Start()
    {
        score = GameObject.Find("Score GameObject").GetComponent<ScoreModel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            int tileType = collision.gameObject.GetComponent<TileGameObject>().type;
            int bulletType = gameObject.GetComponent<BulletGameObject>().type;
            if (tileType == bulletType)
            {
                score.addOneScore();
                score.addOneCombo();
                collision.gameObject.GetComponent<TileGameObject>().corridor.GetComponent<CorridorView>().playGoodAnim(tileType);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else{
                score.resetComboVariables();
                Debug.Log("Wrong bullet");
                Destroy(gameObject);
            }

        }

        else if(collision.gameObject.tag == "BulletLimit")
        {
            score.resetComboVariables();
            Debug.Log("No tiles touched");
            Destroy(gameObject);
        }
    }

}
