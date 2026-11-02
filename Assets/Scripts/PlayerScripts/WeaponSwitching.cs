
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    private CharacterInput controls;

    private void Awake()
    {
        controls = new CharacterInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (controls.Player.SwitchWeapon1.triggered)
        {
            selectedWeapon = 0;
            print("working");
            SelectWeapon();
        }
        if (controls.Player.SwitchWeapon2.triggered)
        {
            selectedWeapon = 1;
            print("working");
            SelectWeapon();
        }
     
    }
    void SelectWeapon()
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
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
