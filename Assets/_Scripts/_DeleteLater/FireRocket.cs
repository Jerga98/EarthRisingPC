using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocket : MonoBehaviour
{
    [SerializeField] private float rocketSpeed = 3f;
    [SerializeField] private Rigidbody force;

    private void Update()
    {
        rocketSpeed = Mathf.Lerp(rocketSpeed, 2, rocketSpeed * 2);
        Vector3 travel = new Vector3(0, rocketSpeed * Time.deltaTime, 0);

        force.velocity = travel;
    }
}
