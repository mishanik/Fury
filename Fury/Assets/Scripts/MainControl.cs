using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour {
    public Rigidbody2D hero;

    public KeyCode top = KeyCode.W;
    public KeyCode bot = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public float speed;

    float movmentX;
    float movmentY;

	void Start () {
        hero = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (Time.timeScale != 0)
        {
            if (Input.GetKey(left))
            {
                movmentX = -speed;

                if (hero.GetComponent<Transform>().position.x <= -28.90003)
                {
                    movmentX = 0;
                }
            }
            if (Input.GetKey(right))
            {
                movmentX = speed;

                if (hero.GetComponent<Transform>().position.x >= 20.2)
                {
                    movmentX = 0;
                }
            }
            if (Input.GetKey(top))
            {
                movmentY = speed;

                if (hero.GetComponent<Transform>().position.y >= 16.459)
                {
                    movmentY = 0;
                }

            }
            if (Input.GetKey(bot))
            {
                movmentY = -speed;

                if (hero.GetComponent<Transform>().position.y <= -12.845)
                {
                    movmentY = 0;
                }

            }

            if (Input.GetKey(top) && Input.GetKey(left))
            {
                movmentY = (speed / 1.5f);
                movmentX = -(speed / 1.5f);
                if (hero.GetComponent<Transform>().position.x <= -28.90003)
                {
                    movmentX = 0;
                }
                if (hero.GetComponent<Transform>().position.y >= 16.459)
                {
                    movmentY = 0;
                }
            }
            if (Input.GetKey(top) && Input.GetKey(right))
            {
                movmentY = (speed / 1.5f);
                movmentX = (speed / 1.5f);
                if (hero.GetComponent<Transform>().position.y >= 16.459)
                {
                    movmentY = 0;
                }
                if (hero.GetComponent<Transform>().position.x >= 20.2)
                {
                    movmentX = 0;
                }
            }
            if (Input.GetKey(bot) && Input.GetKey(left))
            {
                movmentY = -(speed / 1.5f);
                movmentX = -(speed / 1.5f);
                if (hero.GetComponent<Transform>().position.x <= -28.90003)
                {
                    movmentX = 0;
                }
                if (hero.GetComponent<Transform>().position.y <= -12.845)
                {
                    movmentY = 0;
                }
            }
            if (Input.GetKey(bot) && Input.GetKey(right))
            {
                movmentY = -(speed / 1.5f);
                movmentX = (speed / 1.5f);
                if (hero.GetComponent<Transform>().position.x >= 20.2)
                {
                    movmentX = 0;
                }
                if (hero.GetComponent<Transform>().position.y <= -12.845)
                {
                    movmentY = 0;
                }
            }

            transform.Translate(movmentX, movmentY, 0);

            movmentX = 0;
            movmentY = 0;
        }
	}


}
