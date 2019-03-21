using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgAndMovment : MonoBehaviour {

    public int hpForEnemy = 3;
    bool slowedDown = false;
    public float sped = 0.05f;
    float saveSped;
    public Rigidbody2D enemy;
    public Rigidbody2D hero;
	void Start () {
        enemy = GetComponent<Rigidbody2D>();
        hero = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D(Collider2D pistolBullet)
    {
        if (pistolBullet.gameObject.tag == "Pistol Bullet")
        {
            slowedDown = true;
            hpForEnemy -= 1;
            Destroy(pistolBullet.gameObject);
            if (hpForEnemy <= 0)
            {
                Destroy(this.gameObject);
                MakingEnemies.addEnemy++;
            }
        }
       
    }
    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            enemy.transform.right = new Vector3(hero.transform.position.x - transform.position.x,
                hero.transform.position.y - transform.position.y, 0);
            enemy.transform.Translate(new Vector3(sped, 0, 0));

            if (slowedDown)
            {
                StartCoroutine(stopStep());
            }
            Debug.print(sped);
        }
    }
    IEnumerator stopStep()
    {
        slowedDown = false;
        saveSped = sped;
        sped = saveSped / 3.5f;
        yield return new WaitForSeconds(0.15f);
        sped = saveSped;
    }
  
    
}
