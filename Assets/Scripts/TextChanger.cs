using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer SR;
    void Start()
    {
        SR.color = new Color(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        Destroy(gameObject);
        
    }
}
