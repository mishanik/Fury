using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interface : MonoBehaviour {
    
    
    public Text counterBullets;
    public Text counterEnemy;
    public GameObject[] counterHp;

    static public int ammoInClip = 0;
    static public int ammoInStock = 0;
    
    static public int currentHp;
    int fullHp = 5;
    int elementСounterHp;


	void Start () {

	}
	
	void Update () {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Red Enemy");
        currentHp = HeroDmg.HpHero();
        if (currentHp >= 0)
        {
            elementСounterHp = currentHp-1;
            for (int i = fullHp-1; i > elementСounterHp; i--) counterHp[i].SetActive(false);
            for (int i = 0; i <= elementСounterHp; i++) counterHp[i].SetActive(true);
        }
 
        counterBullets.text = ammoInClip + " / " + ammoInStock;
        counterEnemy.text = "Enemy: " + enemy.Length;

	}

}
