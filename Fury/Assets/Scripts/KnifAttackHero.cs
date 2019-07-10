using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifAttackHero : MonoBehaviour
{
    // Start is called before the first frame update
    //public AnimationClip knife;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ()
        {
            var mousePosition = Input.mousePosition;
            //mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
            var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//немного магии на последок
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("AttackHero");
        }
        }

    }
}
