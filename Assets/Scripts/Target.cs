using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] internal HealthManager healthManager;
    [SerializeField] ParticleSystem VFX;
    // Start is called before the first frame update
    void Awake()
    {
        healthManager.OnDie += HealthManager_OnDie;
    }

    private void HealthManager_OnDie()
    {
        if (VFX != null)
            Instantiate(VFX.gameObject, transform.position, transform.rotation);



        Destroy(gameObject);
    }
}
