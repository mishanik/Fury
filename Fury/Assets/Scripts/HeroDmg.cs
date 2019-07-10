using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDmg : MonoBehaviour {


    public int hpForHero = 3;
    static int hpForInterface;
    GameObject[] go; 
    int amountEnemy;
    public static int addHpDrop;
    GameObject saveEnemy;
    public GameObject empty;
    
    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Red Enemy")
        {
            saveEnemy = enemy.gameObject;
            StartCoroutine(DmgInterval());     
        }  
    }
    void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Red Enemy")
        {
            saveEnemy = empty;
            StopAllCoroutines();
        }
    }
    void FixedUpdate()
    {
        if (saveEnemy == null)
        {
            StopAllCoroutines();
            saveEnemy = empty;
        }
    }
    void Start()
    {
        saveEnemy = empty;
    }
    void Update()
    {
        if (addHpDrop > 0)
        {
            hpForHero += addHpDrop;
            addHpDrop = 0;
        }
        go = GameObject.FindGameObjectsWithTag("Red Enemy");
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
