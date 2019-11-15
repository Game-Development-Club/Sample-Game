﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Inventory
{
    private static List<Weapon> weapons = new List<Weapon>();

    private static int window = 1;
    private static int windows = 0;
    private static int row = 1;
    public static int Row
    {
        get
        {
            return row;
        }

        set
        {
            if (value < 1)
            {
                row = 1;

                if (window - 1 < 1)
                {
                    window = 1;
                } else
                {
                    window -= 1;
                }

                return;
            }

            if (value > 3)
            {
                row = 1;

                if (window + 1 > windows)
                {
                    window = windows;
                }
                else
                {
                    window += 1;
                }

                return;
            }

            row = value;
        }
    }
    private static int column = 1;
    public static int Column
    {
        get
        {
            return column;
        }

        set
        {
            if (value < 1)
            {
                column = 1;
                return;
            }

            if (value > 3)
            {
                column = 3;
                return;
            }

            column = value;
        }
    }


    public static void UpdateView()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i < 9)
            {
                int weaponIndex = i + (9 * (window - 1));

                if (weapons[i] != null)
                {
                    if (weaponIndex < weapons.Count)
                    {
                        BattleManager.instance.inventoryContainers[i].text = weapons[weaponIndex].Name;
                    } else
                    {
                        BattleManager.instance.inventoryContainers[i].text = "";
                    }

                    BattleManager.instance.inventoryContainers[i].color = new Color(1f, 1f, 1f);
                }
            }
        }

        BattleManager.instance.inventoryContainers[GetPreSelectionWeaponIndex()].color = new Color(0.5f, 1f, 1f);
    }

    public static void Hide()
    {
        foreach (Text text in BattleManager.instance.inventoryContainers)
        {
            text.gameObject.SetActive(false);
        }
    }

    public static int GetPreSelectionWeaponIndex()
    {
        //Work on non full 9 screens
        int index = (3 * (Row - 1)) + (Column - 1);
        return index;
    }

    public static void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);

        windows = (weapons.Count / 9) + 1;
    }

    public static List<Weapon> GetInventoryWeapons()
    {
        return weapons;
    }

    public static void Show()
    {
        foreach (Text text in BattleManager.instance.inventoryContainers)
        {
            text.gameObject.SetActive(true);
        }
    }
}
