using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New Weapon")]
[System.Serializable]
public class WeaponClass : ScriptableObject {

    public string WeaponName;
    public int damage;
}
