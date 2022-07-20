using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")] // 특성(Attribute) : C#에서 제공하는 확장 기능 클래스
public class GunData : ScriptableObject
{
    public AudioClip ShotClip;
    public AudioClip ReloadClip;

    public float Damage = 25f;

    public int InitialAmmoCount = 100;
    public int MagazineCapacity = 25;

    public float FireCooltime = 0.12f;
    public float ReloadTime = 1.8f;
}
