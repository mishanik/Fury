using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingEnemies : MonoBehaviour {

    public GameObject redEnemy;
    public int amount;
    static public int addEnemy = 0;
    bool creatEnemy = true;

    public int timer = 0;
   
	void Start () {
        StartCoroutine(IntervalMakingEnemies());
        InvokeRepeating("RunTimer", 1, 1);
	}
	
	void Update () {
        if (addEnemy >= 5)
        {
            Instantiate(redEnemy, new Vector3(-30, 0, 0), Quaternion.identity);
            Instantiate(redEnemy, new Vector3(0, 18, 0), Quaternion.identity);
            Instantiate(redEnemy, new Vector3(0, -14, 0), Quaternion.identity);
            Instantiate(redEnemy, new Vector3(22, 0, 0), Quaternion.identity);
            addEnemy = 0;
        }
        if (timer == 30 && creatEnemy)
        {
            creatEnemy = false;
            Instantiate(redEnemy, new Vector3(-30, Random.Range(-14.0f, 18.0f), 0), Quaternion.identity);
            Instantiate(redEnemy, new Vector3(Random.Range(-30.0f, 22.0f), 18, 0), Quaternion.identity);
            Instantiate(redEnemy, new Vector3(Random.Range(-30.0f, 22.0f), -14, 0), Quaternion.identity);
            Instantiate(redEnemy, new Vector3(22, Random.Range(-14.0f, 18.0f), 0), Quaternion.identity);

        }
	}

    void RunTimer()
    {
        timer++;
    }
    IEnumerator IntervalMakingEnemies()
    {
        yield return new WaitForSeconds(5f);
        while (amount > 0)
        {

            Instantiate(redEnemy, new Vector3(-30f, amount / 2, 0), Quaternion.identity);
            amount--;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
