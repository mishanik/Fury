using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Button : MonoBehaviour
{
    private Image btn;

    public float HitMinimumThreshold = 0.5f;

    void Start()
    {
        btn = gameObject.GetComponent<Image>();
    }

    public void FixedUpdate()
    {
        if (HitMinimumThreshold != btn.alphaHitTestMinimumThreshold)
        {
            btn.alphaHitTestMinimumThreshold = HitMinimumThreshold;
        }
    }
}
