using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public float verticalOffset;
    public float horizontalOffset;

    public Transform panel;

    void Start()
    {

    }

    void Update()
    {
        var position = (Vector2)Input.mousePosition + (Vector2.up * verticalOffset) + (Vector2.left * horizontalOffset);
        panel.position = position;
    }



}
