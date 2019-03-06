using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour {

    public int hpForEnemy = 3;
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D pistolBullet)
    {
        if (pistolBullet.gameObject.tag == "Pistol Bullet")
        {
            hpForEnemy -= 1;
            Destroy(pistolBullet.gameObject);
        }
        if (hpForEnemy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

	void Update () {
	}
    
  
    
}
