using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    public GameObject ammoDrop;
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D hero)
    {
        if (hero.gameObject.tag == "Player")
        {
            Shooting.addStockDrop = 12;
            Destroy(ammoDrop.gameObject);
        }

    }
}
