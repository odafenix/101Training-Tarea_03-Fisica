using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public bool ignorarEjeY = true;
    Vector3 directionVector = Vector3.zero;
    Vector3 originalPosition;
    Quaternion originalRotation;
    private void Start() {
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
        
    }
    private void OnTriggerStay(Collider Player) {
        
        target = Player.transform;
        
    }
    void OnTriggerExit(Collider Player)
    {
         target = null;
        
    }
    private void FixedUpdate()
    {
        Chaser();
    }
    private void Chaser(){
            if (target != null){
            transform.LookAt(target);
            directionVector = (target.position - transform.position).normalized;
            
            if (ignorarEjeY){
                directionVector.y = 0;
            }

            transform.rotation = Quaternion.LookRotation(directionVector);
            transform.position += transform.forward * speed * Time.deltaTime; 
          }

        if (target == null){
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, Time.deltaTime * speed);

         }

        }
}
    
    

