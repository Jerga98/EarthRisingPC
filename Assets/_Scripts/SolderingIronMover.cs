using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIronMover : MonoBehaviour
{
    [SerializeField] Camera solCamera;
    [SerializeField] GameObject solderingIron;
    // Start is called before the first frame update
    void Start()
    {
        //solCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        solderingIron.transform.position = new Vector3(solCamera.ScreenToWorldPoint(Input.mousePosition).x, 1.3f, solCamera.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
