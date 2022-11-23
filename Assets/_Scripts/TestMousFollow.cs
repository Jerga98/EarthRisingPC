using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMousFollow : MonoBehaviour
{
    public GameObject gm;
    private void Update()
    {
        Vector3 cursosos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gm.transform.position = new Vector3(cursosos.x, 0, cursosos.y);
        //Debug.Log(cursosos.x + " " + cursosos.y);
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
            }
        }
    }
}
