using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingEnemies : MonoBehaviour {

    public GameObject redEnemy;
    public int amount;
   
	void Start () {
        StartCoroutine(IntervalMakingEnemies());
	}
	
	void Update () {
        
	}
    IEnumerator IntervalMakingEnemies()
    {
        yield return new WaitForSeconds(5f);
        while (amount > 0)
        {

            Instantiate(redEnemy, new Vector3(-16.47f, amount / 2, 0), Quaternion.identity);
            amount--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
