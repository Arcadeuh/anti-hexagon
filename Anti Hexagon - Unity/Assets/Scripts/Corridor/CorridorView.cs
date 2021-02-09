using UnityEngine;

public class CorridorView : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color alternativeColor;

    private Animator anim;
    private GameObject body;
    private bool displayBaseColor = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = transform.Find("Body").gameObject;
    }

    public void alternateColor()
    {
        displayBaseColor = !displayBaseColor;
        if (displayBaseColor)
        {
            body.GetComponent<SpriteRenderer>().color = baseColor;
        }
        else
        {
            body.GetComponent<SpriteRenderer>().color = alternativeColor;
        }
    }

    public void playGoodAnim(int tileType)
    {
        switch (tileType)
        {
            case 0:
                anim.Play("Good_0");
                break;
            case 1:
                anim.Play("Good_1");
                break;
            case 2:
                anim.Play("Good_2");
                break;
            case 3:
                anim.Play("Good_3");
                break;
        }
    }
}
