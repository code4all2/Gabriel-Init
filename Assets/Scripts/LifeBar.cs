using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] HealthManager healthManager;
    [SerializeField] Image lifeImage;
    [SerializeField] GameObject lifeContainer;
    // Start is called before the first frame update
    void Awake()
    {
        healthManager.OnHealthChange += HealthManager_OnHealthChange;
    }

    private void HealthManager_OnHealthChange(int obj)
    {
        lifeImage.fillAmount = healthManager.GetLifeNormalized();
        lifeContainer.SetActive(!healthManager.IsFullLife());
    }

    private void OnDestroy()
    {
        healthManager.OnHealthChange -= HealthManager_OnHealthChange;
    }
}
