using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    [SerializeField] int hitPoints = 10;

    void Start()
    {
        
    } 

    private void OnParticleCollision(GameObject other){
        print("i am hit");
        processHit();

        //kill enemy 
        if (hitPoints <= 0){
            Destroy(gameObject);
        }
    }

    void processHit(){
        hitPoints -= 1;
    }
}
