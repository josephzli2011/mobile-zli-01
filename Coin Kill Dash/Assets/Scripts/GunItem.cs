using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Guns")]
public class GunItem : ScriptableObject
{
    public string gunName;
    [TextArea]public string description;
    public int damage;
    public int bulletsPerSecond;
    public string playerPrefOwnedName;
    public int price = 100;
}
