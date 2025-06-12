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
    [SerializeField] ParticleSystem hitDamageVFX;

    float nextTimeToFire = 0f;
    int currentBullet;
    bool isReloading;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        currentBullet = maxBullet;
    }

    private void OnEnable()
    {
        isReloading = false;
    }
    // Update is called once per frame
    void Update()
    {
        // impedir de atirar se nao tiver bala
        if (isReloading) return;

        // carregar
        if (currentBullet <= 0)
        {
            if (Input.GetMouseButtonDown(1))
                // pq ienumerator precisar ser executado com a startcoroutine
                StartCoroutine(Reload());
            return;
        }

        // atirar
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            Shoot();
            Debug.Log("balas: " + currentBullet);
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Está reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentBullet = maxBullet;
        isReloading = false;
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
            GameObject tempVFX = Instantiate(hitDamageVFX.gameObject, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(tempVFX, 1f);
            // efeitos fisicos
        }
    }
}
