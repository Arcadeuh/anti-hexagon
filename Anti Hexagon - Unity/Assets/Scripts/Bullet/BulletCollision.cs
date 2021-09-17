using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private ScoreModel score;
    private AudioSource miss;

    public void Start()
    {
        score = GameObject.Find("Score GameObject").GetComponent<ScoreModel>();
        miss = GameObject.Find("Miss shot").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TileMenu")
        {
            collision.GetComponent<TileMenu>().tileShot();
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.tag == "Tile")
        {
            int tileType = collision.gameObject.GetComponent<TileGameObject>().type;
            int bulletType = gameObject.GetComponent<BulletGameObject>().type;
            if (tileType == bulletType)
            {
                if (score) {
                    score.addOneScore();
                    score.addOneCombo();
                }
                collision.gameObject.GetComponent<TileGameObject>().corridor.GetComponent<CorridorView>().playGoodAnim(tileType);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else{
                if (score)
                {
                    score.resetComboVariables();
                    miss.Play();
                }
                Destroy(gameObject);
            }
        }

        else if(collision.gameObject.tag == "BulletLimit")
        {
            if (score)
            {
                score.resetComboVariables();
                miss.Play();
            }
            Destroy(gameObject);
        }
    }

}
