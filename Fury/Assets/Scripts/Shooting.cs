using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public Rigidbody2D hero;

    Vector3 positionHero;

    public float force = 40;
    public int ammoPistolInClip = 12;
    public int ammoPistolInStock = 60;
    bool rechargeIsPossible = true;
    bool shootingIsPossible = true;
    [HideInInspector]
    public GameObject[] pistol_Bullets;
    public KeyCode recharge = KeyCode.R;

    public AudioClip audioShooting;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            positionHero = hero.GetComponent<Transform>().position;

            if (Input.GetMouseButtonDown(0))
            {
                if (ammoPistolInClip > 0 && rechargeIsPossible && shootingIsPossible)
                {
                    audio.PlayOneShot(audioShooting);
                    StartCoroutine(ShotDelay());
                    target.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)); //Setting a target for a shot

                    GameObject bulletClone = Instantiate(bullet, new Vector3(positionHero.x, positionHero.y, 1), Quaternion.identity); //Bullet creation

                    bulletClone.transform.LookAt(target, new Vector3(0, 0, bulletClone.transform.position.z)); //The direction of the bullet in the direction of the target
                    Vector3 forceVector = bulletClone.transform.TransformDirection(new Vector3(0, force, 0)); //Force vector
                    bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceVector.x, forceVector.y), ForceMode2D.Impulse); //Force realization
                    bulletClone.transform.Translate(0, 0, 0);

                    ammoPistolInClip -= 1;
                }
                
            }

            pistol_Bullets = GameObject.FindGameObjectsWithTag("Pistol Bullet"); //Cycle to destroy bullets
            foreach (var i in pistol_Bullets)
            {
                if (i.transform.position.x <= -30)
                {
                    Destroy(i);
                }
                if (i.transform.position.x >= 21)
                {
                    Destroy(i);
                }
                if (i.transform.position.y >= 17)
                {
                    Destroy(i);
                }
                if (i.transform.position.y <= -14)
                {
                    Destroy(i);
                }

            }

            if (Input.GetKeyDown(recharge))
            {

                if (ammoPistolInStock > 0 && ammoPistolInClip < 12 && rechargeIsPossible)
                {
                    StartCoroutine(TimeRecharge());
                }
            }

            if (ammoPistolInClip <= 0)
            {
                ammoPistolInClip = 0;
            }

            if (ammoPistolInClip == 0 && ammoPistolInStock > 0 && rechargeIsPossible)
            {
                StartCoroutine(TimeRecharge());
            }

            if (ammoPistolInStock <= 0)
            {
                ammoPistolInStock = 0;
            }
            Interface.ammoInClip = ammoPistolInClip;
            Interface.ammoInStock = ammoPistolInStock; 
        }
    }
    IEnumerator TimeRecharge()
    {
        rechargeIsPossible = false;
        yield return new WaitForSeconds(2.3f);
        if (ammoPistolInStock < 12)
        { 
            ammoPistolInClip = ammoPistolInStock;
            ammoPistolInStock = ammoPistolInStock - (12 - ammoPistolInClip);
        }
        else
        {
            ammoPistolInStock = ammoPistolInStock - (12 - ammoPistolInClip);
            ammoPistolInClip = 12;
        }
        rechargeIsPossible = true;
    }
    IEnumerator ShotDelay()
    {
        shootingIsPossible = false;
        yield return new WaitForSeconds(0.4f);
        shootingIsPossible = true;
    }
}
