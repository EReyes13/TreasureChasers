using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer SR;
    public float transpara = 0;
    public float countdown = 0;

    public static bool Fade;
    void Start()
    {
        SR.color = new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade == true)
        {transpara += (0.1f*Time.deltaTime);
        countdown += (10*Time.deltaTime);
        if(countdown >= 100)
        {
            SceneManager.LoadScene("Title Screen");
        }
        SR.color = new Color(0,0,0,transpara);
        }
    }
}
