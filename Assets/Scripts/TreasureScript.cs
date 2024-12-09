using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    // Start is called before the first frame update
   public void Victory()
    {
        Destroy(gameObject);
        WinScript.Fade = true;
    }
}
