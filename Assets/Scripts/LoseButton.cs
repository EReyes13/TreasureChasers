using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButton : MonoBehaviour
{
    // Start is called before the first frame update
     public void LoseMenu()
       {
        SceneManager.LoadScene("Title Screen");
        PlayerController.Health = 3;
        PlayerController.count = 0;
        PlayerController.Ability1 = false;
        PlayerController.Ability2 = false;
       }
}
