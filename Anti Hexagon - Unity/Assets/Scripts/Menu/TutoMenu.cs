using UnityEngine;

public class TutoMenu : MonoBehaviour
{
    [SerializeField] private Animator menu;

    /*
    private Vector2 aimVector;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        //controls.Player.Aim.performed += ctx => aimVector = ctx.ReadValue<Vector2>();
        //controls.Player.Shoot0.performed += ctx => onShoot();
    }
    */

    private void Update()
    {
        if (!(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            menu.SetBool("aim", true);
            
            if (Input.GetKey(KeyCode.F) || Input.GetButton("Fire1"))
            {
                menu.SetBool("shoot",true);
                gameObject.GetComponent<TutoMenu>().enabled = false;
            }
            
        }
        else
        {
            menu.SetBool("aim", false);
        }
    }

    /*
    private void onShoot()
    {
        if (!menu.GetBool("aim")) { return; }
        menu.SetBool("shoot", true);
        gameObject.GetComponent<TutoMenu>().enabled = false;
    }
    */
}
