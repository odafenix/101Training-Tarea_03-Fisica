using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
        public Transform target;
    public float bulletSpeed = 6f;
    public float bulletReload = 2f;
    private bool bulletCooldown;
    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    public float speed = 3f;
    public bool ignorarEjeY = true;
    Vector3 directionVector = Vector3.zero;
    Vector3 originalPosition;
    private void Start() {
        originalPosition = gameObject.transform.position;
    }
    private void OnTriggerStay(Collider Player) {
        
        if(Player.tag == "Player"){
            target = Player.transform;
        }
        

        if(Player.tag != "Player"){
            return;
        }
        
    }

     void OnTriggerExit(Collider Player)
    {
        
       if(Player.tag == "Player"){
            target = null;
        }
        if(Player.tag != "Player"){
            return;
        }
    }
    private void FixedUpdate() {
        StartCoroutine(ShootAtTarget());
    }
    
    IEnumerator ShootAtTarget(){
        if (target != null & bulletCooldown == false){
            Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
             bulletCooldown = true;
             yield return new WaitForSeconds(bulletReload);
             bulletCooldown = false;
        }
    }
}
