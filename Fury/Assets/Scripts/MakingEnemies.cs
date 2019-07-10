using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingEnemies : MonoBehaviour {

    public GameObject redEnemy;
    public int amount;
    bool creatEnemy = true;
    int randomRange;
    Vector3 randomCreate;
    public static int wave;
    int i;
    public int timer = 0;
    bool creat = true;
	void Start () {
        
        //InvokeRepeating("RunTimer", 1, 1);
        wave = 0;
	}
	
	void Update () {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Red Enemy");
        if (enemy.Length == 0 && creat)
        {
            creat = false;
            creatEnemy = true;
        }
        if (creatEnemy)
        {
            creatEnemy = false;
            StartCoroutine(IntervalMakingEnemies());
            amount++;
        }
	}

    //void RunTimer()
    //{
    //    timer++;
    //}

    IEnumerator IntervalMakingEnemies()
    {
        yield return new WaitForSeconds(2f);
        wave++;
        i = amount;
        while (i > 0)
        {
            randomRange = Random.Range(1, 4);
            if (randomRange == 1) randomCreate = new Vector3(-30, Random.Range(-14.0f, 18.0f), 0);
            if (randomRange == 2) randomCreate = new Vector3(Random.Range(-30.0f, 22.0f), 18, 0);
            if (randomRange == 3) randomCreate = new Vector3(22, Random.Range(-14.0f, 18.0f), 0);
            if (randomRange == 4) randomCreate = new Vector3(Random.Range(-30.0f, 22.0f), -14, 0);
            Instantiate(redEnemy, randomCreate, Quaternion.identity);
            i--;
            yield return new WaitForSeconds(0.1f);
        }
        creat = true;
    }

}
