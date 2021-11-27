using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
   public Transform BallTransform;
   public Transform StartingPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            BallTransform.position = StartingPoint.position;
        }
        else{
            return;
        }
    }
}
