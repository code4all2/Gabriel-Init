using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int selectedWeapon = 0;

    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previusWeaponSelected = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (previusWeaponSelected >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (previusWeaponSelected <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if(previusWeaponSelected != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    private void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
