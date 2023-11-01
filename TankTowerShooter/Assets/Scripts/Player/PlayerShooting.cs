using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnTransform;
    bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

  

    IEnumerator Shoot()
    {
        print("reached");
        canShoot = false;
        Instantiate(bullet, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        yield return new WaitForSeconds(2);
        canShoot = true;
    }
}
