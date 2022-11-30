using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationText : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }
}
