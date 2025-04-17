using System.Collections;
using UnityEngine;

public class Arma : MonoBehaviour
{    
    Camera cam;
    [SerializeField] int damage = 10;
    [SerializeField] int maxBullet = 10;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] float reloadTime = 1f;

    float nextTimeToFire = 0f;
    int currentBullet;
    bool isReloading;

   
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Está reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentBullet = maxBullet;
        isReloading=false;
    }

    void Shoot()
    {
        currentBullet--;

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // aplicar dano
            // efeito visuais
            // efeitos fisicos
        }
    }
}
