using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderingIronMover : MonoBehaviour
{
    public Camera solCamera;
    [SerializeField] GameObject solderingIron;
    public float visina;
    // Start is called before the first frame update
    void Start()
    {
        //solCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        solderingIron.transform.position = solCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, visina));
        //solderingIron.transform.position = new Vector3(solCamera.ScreenToWorldPoint(Input.mousePosition).x, 1.3f, solCamera.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
