using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interface : MonoBehaviour {
    
    
    public Text counterBullets;
    public Text counterWave;
    public GameObject herts;
    public GameObject convasInterface;

    bool ferInsHp = true;


    GameObject[] go;
    GameObject hert;

    static public int ammoInClip = 0;
    static public int ammoInStock = 0;
    
    static public int currentHp;
    int fullHp;
    int differenceHp;




	void Start () {

	}

    void LateUpdate()
    {
        //GameObject[] enemy = GameObject.FindGameObjectsWithTag("Red Enemy");
        currentHp = HeroDmg.HpHero();

        FerstInstantiateHP();

        go = GameObject.FindGameObjectsWithTag("Hp Hero");
        fullHp = go.Length;

        if (fullHp < currentHp)
        {
            differenceHp = currentHp - fullHp;
            while (differenceHp > 0)
            {
                hert = Instantiate(herts, new Vector3(go[go.Length - 1].transform.position.x + 64.588f, -45f, 0), Quaternion.identity);
                hert.transform.SetParent(convasInterface.transform, false);
                differenceHp--;
                go = GameObject.FindGameObjectsWithTag("Hp Hero");
            }
        }
        else if (fullHp > currentHp)
        {
            differenceHp = fullHp - currentHp;
            while (differenceHp > 0)
            {
                Destroy(go[go.Length - 1]);
                differenceHp--;
            }
        }

        if (ammoInClip <= 0)
        {
            ammoInClip = 0;
        }
        if (ammoInStock <= 0)
        {
            ammoInStock = 0;
        }
        counterBullets.text = ammoInClip + " / " + ammoInStock;
        if (MakingEnemies.wave != 0) counterWave.text = "Wave: " + MakingEnemies.wave;
        else counterWave.text = "Wave: ";

	}

    void FerstInstantiateHP()
    {
        if (ferInsHp)
        {
            
            Vector3 positonHerts = new Vector3(60.7f, -45f, 0f);
            for (int i = currentHp - 1; i >= 0; i--)
            {
                hert = Instantiate(herts, positonHerts, Quaternion.identity);
                hert.transform.SetParent(convasInterface.transform, false);
                positonHerts = new Vector3(positonHerts.x + 64.588f, -45f, 0f);
            }
            ferInsHp = false;
        }
    }
}
