using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDmg : MonoBehaviour {

    public int hpForHero = 3;
    static int hpForInterface;
    GameObject[] go; 
    int amountEnemy;

    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Red Enemy") StartCoroutine(DmgInterval());

     
    }
    void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Red Enemy") StopAllCoroutines();
    }
    void Update()
    {   go = GameObject.FindGameObjectsWithTag("Red Enemy");
        amountEnemy = go.Length;
        if (hpForHero > 10) hpForHero = 10;
        if (amountEnemy <= 0) StopAllCoroutines();

        hpForInterface = hpForHero;
        if (hpForHero <= 0) Destroy(this.gameObject);
        
    }

    public static int HpHero(){
        return hpForInterface;
    }
    IEnumerator DmgInterval()
    { 
        while (hpForHero > 0)
        {
            hpForHero -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
