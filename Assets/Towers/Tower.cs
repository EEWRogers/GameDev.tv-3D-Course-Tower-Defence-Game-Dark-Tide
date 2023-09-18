using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 20;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        
        if (bank == null) { return false; }

        if ((bank.CurrentBalance - towerCost) <= 0) { return false; }
        
        bank.Withdraw(towerCost);
        Instantiate(tower.gameObject, position, Quaternion.identity);
        return true;
    }

}
