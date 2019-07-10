using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDrop : MonoBehaviour
{
    public GameObject hpDrop;
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D hero)
    {
        if (hero.gameObject.tag == "Player")
        {
            HeroDmg.addHpDrop = 1;
            Destroy(hpDrop.gameObject);
        }

    }
}
