using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potions : MonoBehaviour
{
    private damage _damage;
    private powerAttack _powerAttack;
    private Shield _shield;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("poL"))
        {
            _damage.hp += 250;
            other.gameObject.SetActive(false);
        }

        else if (other.CompareTag("poE"))
        {
            _powerAttack.disp += 25f;
            _shield.disp += 25f;
            other.gameObject.SetActive(false);
        }
        
    }
}
