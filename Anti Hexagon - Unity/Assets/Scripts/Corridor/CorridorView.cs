using UnityEngine;

public class CorridorView : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void playGoodAnim(int tileType)
    {
        anim.Play("Null");
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
