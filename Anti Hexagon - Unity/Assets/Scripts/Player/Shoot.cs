using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private List<GameObject> bullets;
    [SerializeField] private float cadence;
    private bool allowToShoot = true;

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
        if ((Input.GetKey(KeyCode.G) || Input.GetButton("Fire1")) && allowToShoot)
        {
            shoot(bullets[0]);
        }
        if ((Input.GetKey(KeyCode.F) || Input.GetButton("Fire2")) && allowToShoot)
        {
            shoot(bullets[1]);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetButton("Fire3")) && allowToShoot)
        {
            shoot(bullets[2]);
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetButton("Jump")) && allowToShoot)
        {
            shoot(bullets[3]);
        }
        
    }

    private void shoot(GameObject bullet)
    {
        Instantiate(bullet, transform.position, transform.rotation);
        allowToShoot = false;
        StartCoroutine("WaitNextShot");
    }
}
