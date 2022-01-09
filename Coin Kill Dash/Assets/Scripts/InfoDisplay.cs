using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoDisplay : MonoBehaviour
{
    private GunItem gun;
    public Text infoName;
    public Text infoDesc;
    public Text infoDmg;
    public Text infoDps;
    public Text infoPrice;
    public Text infoOwned;
    public Button buy;
    public Button equip;
    public Text equippedGunText;
    public string[] guns;
    void Start()
    {
        infoName.text = "";
        infoDesc.text = "";
        infoDmg.text = "";
        infoDps.text = "";
        infoOwned.text = "";
        infoPrice.text = "";
        buy.gameObject.SetActive(false);
        equip.gameObject.SetActive(false);
    }

    private void Update()
    {
        equippedGunText.text = "EQUIPPED GUN: " + guns[PlayerPrefs.GetInt("EquippedGun", 0)];
    }

    public void SetGun(GunItem _gun)
    {
        
        gun = _gun;
        if (gun.price == 0 && PlayerPrefs.GetInt(gun.playerPrefOwnedName, 0) == 0)
        {
            PlayerPrefs.SetInt(gun.playerPrefOwnedName, 1);
            buy.interactable = false;
            equip.interactable = true;
        }
        infoName.text = gun.gunName;
        infoDesc.text = gun.description;
        infoDmg.text = "DAMAGE: "+gun.damage;
        infoDps.text = "BULLETS PER SECOND: " + gun.bulletsPerSecond;
        infoPrice.text = "PRICE: " + gun.price;
        buy.gameObject.SetActive(true);
        equip.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt(gun.playerPrefOwnedName, 0) == 0)
        {
            infoOwned.text = "NOT OWNED";
            infoOwned.color = Color.red;
            equip.interactable = false;
            if(gun.price == 0 && PlayerPrefs.GetInt(gun.playerPrefOwnedName, 0) == 0)
            {
                PlayerPrefs.SetInt(gun.playerPrefOwnedName, 1);
                buy.interactable = false;
                equip.interactable = true;
                return;
            }
            if(PlayerPrefs.GetInt("Money", 0) >= gun.price)
            {
                buy.interactable = true;
            } else
            {
                buy.interactable = false;
            }
        } else
        {
            infoOwned.text = "OWNED";
            infoOwned.color = Color.green;
            equip.interactable = true;
            buy.interactable = false;
        }

        
    }

    public void BuyGun()
    {
        PlayerPrefs.SetInt(gun.playerPrefOwnedName, 1);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - gun.price) ;
        buy.interactable = false;
        equip.interactable = true;
        infoOwned.text = "OWNED";
        infoOwned.color = Color.green;

    }

    public void Equip()
    {
        PlayerPrefs.SetInt("EquippedGun", gun.gunIndex);
    }
}
