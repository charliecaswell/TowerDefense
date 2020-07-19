using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    
    [SerializeField] Transform tower;
    [SerializeField] Transform enemy; 
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem particle;
    void Update(){
        if (enemy){
            tower.LookAt(enemy);
            fireEnemy();
        }
        else{
            var emmisionModule = particle.emission;
            emmisionModule.enabled = false;
        }
    }

    private void fireEnemy(){
        float enemyDistance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
        var emmisionModule = particle.emission;
        //if within range fire
        if (enemyDistance <= attackRange){
            emmisionModule.enabled = true;
        }
        //otherwise turn particles off 
        else{
            emmisionModule.enabled = false;
        }
    }
}
