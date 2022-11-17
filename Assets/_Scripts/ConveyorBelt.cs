using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform endPoint;
    public float speed;
    //Rigidbody rBody;

    private void OnTriggerStay(Collider other)
    {
        // GameObject parente = other.gameObject.GetComponentInParent<Transform>().position;
        if (!other.gameObject.CompareTag("GameController")){
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
            other.gameObject.GetComponentInParent<Transform>().position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }
}
