﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    private List<Weapon> weapons = new List<Weapon>();

    public void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        registerWeapons();

        foreach (Weapon weapon in weapons)
            weapon.Initialize();
    }

    private void registerWeapons()
    {
        weapons.Add(new CandyCaneShooter());
    }
}
