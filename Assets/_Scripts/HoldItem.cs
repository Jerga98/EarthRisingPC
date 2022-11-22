using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldItem : MonoBehaviour
{
    public float speed = 10;
    public bool canHold = true;
    public bool canPickup = false;
    public GameObject cubeSatComponent = null;
    public Transform guide;
    public Image krugUI;
    Vector3 scale_Normal;
    public MeshCollider componentMeshColl;
    public BoxCollider componentBoxColl;


    void Update()
    {
        InteractWithObj();
    }

    void InteractWithObj()
    {
        if (Input.GetMouseButtonUp(0) && canPickup == true)
        {
            if (!canHold)
                throw_drop();
            else
                Pickup();
        }
    }

    private void Pickup()
    {
        if (!cubeSatComponent)
            return;

        cubeSatComponent.transform.SetParent(guide);
        scale_Normal = cubeSatComponent.transform.localScale;

        //if (cubeSatComponent.name == "Komu")
        //{
        //    krugUI.color = Color.green;
        //}
        //else if (cubeSatComponent.name == "Bio")
        //{
        //    krugUI.color = new Color(0.47f, 0.274f, 0.211f);
        //}
        //else if (cubeSatComponent.name == "Plastika")
        //{
        //    krugUI.color = Color.yellow;
        //}
        //else if (cubeSatComponent.name == "Papir")
        //{
        //    krugUI.color = Color.blue;
        //}

        cubeSatComponent.GetComponent<Rigidbody>().useGravity = false;

        if (cubeSatComponent.GetComponent<MeshCollider>() != null)
        {
            guide.transform.localScale = new Vector3(3, 3, 3);
            guide.transform.eulerAngles = new Vector3(0, 0, 0);
            cubeSatComponent.transform.eulerAngles = new Vector3(0, 0, 0);
            componentMeshColl = cubeSatComponent.GetComponent<MeshCollider>();
            componentMeshColl.enabled = false;
        }
        else
        {
            guide.transform.eulerAngles = new Vector3(0, 0, 0);
            cubeSatComponent.transform.eulerAngles = new Vector3(0, 0, 0);
            componentBoxColl = cubeSatComponent.GetComponent<BoxCollider>();
            componentBoxColl.enabled = false;

        }

        cubeSatComponent.gameObject.transform.localScale = scale_Normal * 0.1f;

        cubeSatComponent.transform.localRotation = transform.rotation;

        cubeSatComponent.transform.position = guide.position;

        canHold = false;
    }

    private void throw_drop()
    {
        if (!cubeSatComponent)
            return;


        //Aktiviraj gravity
        cubeSatComponent.GetComponent<Rigidbody>().useGravity = true;
        cubeSatComponent.GetComponent<Rigidbody>().isKinematic = false;
        cubeSatComponent.gameObject.transform.localScale = scale_Normal;

        //krugUI.color = Color.black;

        //aktiviraj coll
        if (cubeSatComponent.GetComponent<MeshCollider>() != null)
        {
            guide.transform.localScale = new Vector3(1, 1, 1);
            componentMeshColl = cubeSatComponent.GetComponent<MeshCollider>();
            componentMeshColl.enabled = true;
        }
        else
        {
            componentBoxColl = cubeSatComponent.GetComponent<BoxCollider>();
            componentBoxColl.enabled = true;
        }

        //Primjeni velocity kad se baca
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Uperent smece
        guide.GetChild(0).parent = null;
        canHold = true;
        cubeSatComponent = null;
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Untagged") && !col.gameObject.CompareTag("GameController") && !col.gameObject.CompareTag("MainCamera") && canPickup == false)
        {
            Debug.Log("CAN PICKUP: " + col.gameObject.name);
            canPickup = true;
            cubeSatComponent = col.gameObject;
            Outline outline = col.gameObject.GetComponent<Outline>();
            outline.enabled = true;

            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (!col.gameObject.CompareTag("Untagged") && !col.gameObject.CompareTag("GameController") && !col.gameObject.CompareTag("GameController"))
        {
            if (canHold)
            {
                canPickup = false;
                Outline outline = col.gameObject.GetComponent<Outline>();
                outline.enabled = false;
            }
        }
    }
}
