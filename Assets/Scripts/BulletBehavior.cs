using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Transform target;
    public float shootForce = 10f;
    public GameObject bulletGB;
    public Transform bulletLocation;
    public Rigidbody bulletRigidbody;
    private Vector3 BulletDirection;
    private float m_ForceX, mForceY;
    void Start()
    {
        Shoot();
    }

    private void Shoot(){
        //
        transform.LookAt(target);
        BulletDirection = new Vector3 (-5f, 1f, 0f);
        //bulletGB.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, shootForce, 0));
        bulletRigidbody.AddForce(BulletDirection* shootForce, ForceMode.Impulse);
    }
}  
    



    
