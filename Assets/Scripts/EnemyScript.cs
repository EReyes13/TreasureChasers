using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    
        public BoxCollider2D BD;

        public SpriteRenderer SR;

        public float Duration = 5;
        
        public bool downtime;

        public bool Goingup;
        public float distance = 1;
            void Start()
    {
        
    }

        void Update()
        {
            if (downtime == true)
            Duration -= (1*Time.deltaTime);
       if(Duration <= 0.1)
       {
        BD.enabled = true;
        downtime = false;
        SR.color = Color.red;
        }

        Vector2 pos = transform.position;
        
        if(Goingup == true)
        {
            pos.y += (1 * Time.deltaTime);
            distance += Time.deltaTime;
        }
        else
        {
            pos.y -= (1 * Time.deltaTime);
            distance -= Time.deltaTime;
        }
        if(distance <= -1)
        {

            Goingup = true;
        }
        if(distance >= 2)
        {
            Goingup = false;
        }
        
        transform.position = pos;
        }
    public void Invis()
    {
       BD.enabled = false;
       SR.color = new Color(255,255,255,0);
       downtime = true;
       Duration = 5;
    }
    
}
