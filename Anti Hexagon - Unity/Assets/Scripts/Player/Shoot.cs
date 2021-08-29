using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    [SerializeField] private List<GameObject> bullets;
    [SerializeField] private float cadence;
    [SerializeField] private UnityEvent onShoot;
    private bool allowToShoot = true;
    [SerializeField] private bool allowSecondShoot = false;

    private IEnumerator WaitNextShot()
    {
        yield return new WaitForSeconds(cadence);
        allowToShoot = true;
    }

    private void OnEnable()
    {
        allowToShoot = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.F) || Input.GetButton("Fire1")) && allowToShoot)
        {
            onShoot.Invoke();
            shoot(bullets[0]);
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetButton("Jump")) && allowToShoot && allowSecondShoot)
        {
            shoot(bullets[1]);
        }
        else if(!(Input.GetKey(KeyCode.F) || Input.GetButton("Jump") || Input.GetKey(KeyCode.F) || Input.GetButton("Fire1")))
        {
            allowToShoot = true;
        }
        /*
        if ((Input.GetKey(KeyCode.D) || Input.GetButton("Fire3")) && allowToShoot)
        {
            shoot(bullets[2]);
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetButton("Jump")) && allowToShoot)
        {
            shoot(bullets[3]);
        }
        */

    }

    public void shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position, transform.rotation);
        allowToShoot = false;
    }

    public void shootAuto()
    {
        Instantiate(bullets[0], transform.position, transform.rotation);
        allowToShoot = false;
    }
}
