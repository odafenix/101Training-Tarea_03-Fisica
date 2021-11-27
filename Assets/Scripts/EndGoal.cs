using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
   public Transform BallTransform;
   public Transform StartingPoint;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            BallTransform.position = StartingPoint.position;
        }
        else{
            return;
        }
    }
}
