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
    int random1;
    int random2;
    public GameObject hpDrop;
    public GameObject ammoDrop;
    Vector3 savePositEnemy;
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
                savePositEnemy = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 1);
                Destroy(this.gameObject);
                DropForHero();
                //MakingEnemies.addEnemy++;     
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
        }
    }
    void DropForHero()
    {
        random1 = Random.Range(1, 100);
        if (random1 <= 3)
        {
            Instantiate(hpDrop, savePositEnemy, Quaternion.identity);
        }
        
        random2 = Random.Range(1, 100);
        if (random2 <= 10)
        {
            Instantiate(ammoDrop, savePositEnemy, Quaternion.identity);
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
