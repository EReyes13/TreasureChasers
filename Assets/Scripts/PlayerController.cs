using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  
  //this variable controls the rigidbody 2D component.
  public Rigidbody2D RB;
  
  //this variable controls the SpriteRenderer component
  public SpriteRenderer SR;
  
  //Speed determines how fast the player moves
   public float Speed = 10;

   //This bool determines whether the effect is active 
   public bool effect;

   //This bool determines Ability1 can be used
   public static bool Ability1;
   
   //This bool determines if Ability2 can be used.
   public static bool Ability2;
    
    //This float determines how long the effect will stay up
    public float Duration = 5;

    //This float represents the cooldown
    public float Cooldown = 5;

    public GameObject Person;

    //this controls the text that appears in the tutorial level.
    public TextMeshPro TutorialText;

    //this gives a list of all the enemy tagged with hazard
    public GameObject[] enemies;

    //this variable determines the health of the player.
    public static int  Health = 3;

    public float tp = 0;

    public Transform UpperWall;
    public Transform LowerWall;
    public Transform RightWall;
    public Transform LeftWall;

    public static int count = 0;

    
       void Update()
    {
       //Player Movement
       Vector2 vel = new Vector2(0,0);
       if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        //If I hold the up arrow, the player should move up. . .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Speed;
        }
        //If I hold the down arrow, the player should move down. . .
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -Speed;
        }
        
        //Finally, I take that variable and I feed it to the component in charge of movement
        RB.velocity = vel; 

        //Player Ability No.1 : temporary invisibility
        if(Ability1 == true && Input.GetKeyDown(KeyCode.E))
        {
           
            effect = true;
            Ability1 = false; 
            
        }
 
        if (effect == true)
        {
             
            Duration -= (Time.deltaTime);
            SR.color = Color.gray;
          
        }
        if (Duration <= 0.1)
        {
            Cooldown -=(Time.deltaTime);
            SR.color = Color.white;
            effect = false;
        }
        if (Cooldown <= 0.1)
        {
            Ability1 = true;
            Duration = 5;
        }
        if(Ability1 == true)
        {
            Cooldown = 5;
        }

          //Player Ability No.2 : Dashing.
          if(Ability2 == true && Input.GetKeyDown(KeyCode.D))
          {
            Vector2 pos = transform.position;
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            if(Input.GetKey(KeyCode.LeftArrow))
            {
               if(Physics2D.Raycast(transform.position + new Vector3(-1,0,0), new Vector2(-1,0), new ContactFilter2D(), hits, 3) > 0)
               {
                    tp = (hits[0].transform.position.x);
                    pos.x = (tp + 0.8f);
               }
               else
               {
                    pos.x -= 3;
               }
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                 if(Physics2D.Raycast(transform.position + new Vector3(1,0,0), new Vector2(1,0), new ContactFilter2D(), hits, 3) > 0)
               {
                tp = (hits[0].transform.position.x);
                    pos.x = (tp - 0.8f);
               }
                else
               {
                    pos.x += 3;
                    
               }
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                if(Physics2D.Raycast(transform.position + new Vector3(0,1,0), new Vector2(0,1), new ContactFilter2D(), hits, 3) > 0)
               {
                tp = (hits[0].transform.position.y);
                    pos.y = (tp - 0.8f);
               }
                else
               {
                    pos.y += 3;
               }
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                 if(Physics2D.Raycast(transform.position + new Vector3(0,-1,0), new Vector2(0,-1), new ContactFilter2D(), hits, 3) > 0)
               {
                tp = (hits[0].transform.position.y);
                    pos.y = (tp + 0.8f);
               }
                else
               {
                    pos.y -= 3;
               }
            }
             transform.position = pos;
            Vector2 up = UpperWall.position;
            Vector2 down = LowerWall.position;
            Vector2 left = LeftWall.position;
            Vector2 right = RightWall.position;
            if(transform.position.y > up.y)
            {
                pos.y = (up.y - 0.6f);
            }
            if(transform.position.y < down.y)
            {
                pos.y = (down.y + 0.6f);
            }
            if(transform.position.x > right.x)
            {
                pos.x = (right.x - 0.6f);
            }
            if(transform.position.x < left.x)
            {
                pos.x = (left.x + 0.6f);
            }
           transform.position = pos;
          }
    }

  

        
    
    
    //this will contain all the collision scripts when the player collides with a Game Object.
    private void OnCollisionEnter2D(Collision2D other)
    {

        PoroScript poro = other.gameObject.GetComponent<PoroScript>();

        if (poro != null)
        {

           
            poro.Fast();
            Ability1 = true;
            TutorialText.transform.position = new Vector3(27.05f,5.5f,0);
            TutorialText.fontSize = (8);
            TutorialText.text = "This fluffy little creature has given you his power to hide! Press the E key to temporarily remove the enemies you touch.";
        }
       
       TextChanger tex = other.gameObject.GetComponent<TextChanger>();
        if(tex != null)
        {
            tex.Change();
            TutorialText.transform.position = new Vector3(75.5f,5.5f,0);
            TutorialText.fontSize = (8);
            TutorialText.text = "The door will lead to your next level, good luck.";

        }

        TreasureScript treasure = other.gameObject.GetComponent<TreasureScript>();
        {
            if(treasure != null)
            {
                treasure.Victory();
                
            }
           
        }
       
        if (other.gameObject.CompareTag("Hazard"))
        {
            
            if (effect == true)
            {
                EnemyScript haz = other.gameObject.GetComponent<EnemyScript>();
                if(haz != null)
                {
                    haz.Invis();

                }
                EnemyScript2 bad = other.gameObject.GetComponent<EnemyScript2>();
                if(bad != null)
                {
                    bad.Invis();

                }
            }
           else
           {
            Health --;
            effect = true;
            Duration = 5;
            Cooldown = 2;
            if (Health <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
           }

        }

             BookScript book = other.gameObject.GetComponent<BookScript>();
             {
                if(book != null)
                {
                    book.dash();
                     Ability2 = true;
            TutorialText.transform.position = new Vector3(50f,5.5f,0);
            TutorialText.fontSize = (8);
            TutorialText.text = "This magic book contains the spell to dash around the place! Press the D key while moving to dash in that direction.";
                }

             }
             if(other.gameObject.CompareTag("level"))
             {
                count ++;
                SceneManager.LoadScene("Level"+ Random.Range(0,4));
                transform.position = new Vector3(0,0,0);
             }
}
}
