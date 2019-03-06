using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour 
{

    public Rigidbody2D enemy;
    public Rigidbody2D hero;
    public float speed;
    bool moveEnemy = true;
	void Start () {
        enemy = GetComponent<Rigidbody2D>();
        hero = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            enemy.transform.right = new Vector3(hero.transform.position.x - transform.position.x, hero.transform.position.y - transform.position.y, 0);
            if (moveEnemy) enemy.transform.Translate(new Vector3(speed, 0, 0));

        }
    }
}
