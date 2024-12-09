using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Textbutton : MonoBehaviour
{
  
        //button to load teh tutorial level.
       public void TutorialStart()
       {
        SceneManager.LoadScene("Tutorial");
       }
       
    }

