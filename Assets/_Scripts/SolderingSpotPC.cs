using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SolderingSpotPC : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] string solderingText;
    [SerializeField] string notSolderingText;
    [SerializeField] Animator aniamtorSpot;

    [SerializeField] GameObject solderingCamera;
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject SolderPanel;
    [SerializeField] GameObject solderingModePanel;
    [SerializeField] GameObject ingamePanel;
    [SerializeField] GameObject spott;
    [SerializeField] GameObject solderingIron;
    [SerializeField] bool solderingMode = false;

    [SerializeField] Transform solderingPos;

    [SerializeField] float solIronHeight;


    bool rotating = false;

    [SerializeField] float rotationSpeed = 2f;

    FirstPersonController firstPerson;
    Camera solCamera;

    private void Awake()
    {
        firstPerson = FindObjectOfType<FirstPersonController>();
        //camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Start()
    {
        solCamera = solderingCamera.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && SolderPanel.activeInHierarchy)
        {
            Debug.Log("Radi E");
            if(solderingMode == false)
            {
                ingamePanel.SetActive(false);
                solderingModePanel.SetActive(true);
                solderingCamera.SetActive(true);
                playerCamera.SetActive(false);
                solderingMode = true;
                text.text = solderingText;
                firstPerson.CanMove = false;
                solderingIron.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else if(solderingMode == true)
            {
                ingamePanel.SetActive(true);
                solderingModePanel.SetActive(false);
                playerCamera.SetActive(true);
                solderingCamera.SetActive(false);
                solderingMode = false;
                text.text = notSolderingText;
                firstPerson.CanMove = true;
                solderingIron.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && solderingMode==true && rotating == false)
        {
            StartCoroutine(RotateLeft());
            //gameObject.transform.Rotate(-Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D) && solderingMode == true && rotating == false)
        {
            StartCoroutine(RotateRight());
            //spott.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }

        if(solderingMode == true)
        {
            solderingIron.transform.position = solCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, solIronHeight));
            //Vector3 cursosos = Input.mousePosition;
            //var mousePos = Input.mousePosition;
            //mousePos.z = 1.3f; // select distance = 10 units from the camera
            //Debug.Log(solCamera.ScreenToWorldPoint(mousePos));
            //solderingIron.transform.position = new Vector3(solCamera.ScreenToWorldPoint(Input.mousePosition).x, 1.3f, solCamera.ScreenToWorldPoint(Input.mousePosition).y);
            //Debug.Log(mousePos.x + " " + mousePos.y);
            //solderingIron.transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("usao");
        if (other.gameObject.CompareTag("GameController"))
        {
            SolderPanel.SetActive(true);
        }
        else if (!other.gameObject.CompareTag("GameController") &&
            !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera") && !other.gameObject.CompareTag("solderingIron"))
        {
            if(spott.transform.childCount == 0) {
            GameObject obj = other.gameObject;
            Debug.Log(obj.name);
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<Rigidbody>().isKinematic = true;
            
            obj.transform.rotation = solderingPos.rotation;
            obj.transform.SetParent(spott.transform);
            obj.transform.localPosition = Vector3.zero;
            //gameObject = other.gameObject;
            ////GameObject obj = other.gameObject;
            //gameObject.GetComponent<Rigidbody>().useGravity = false;
            //gameObject.transform.localPosition = solderingPos.transform.localPosition;
            //gameObject.transform.rotation = solderingPos.rotation;
            }
        }
    }

    IEnumerator RotateLeft()
    {
        rotating = true;
        int x = 0;
        while (x < 180)
        {
            yield return new WaitForSeconds(0.02f);
            if(x < 90)
            {
                spott.transform.position += new Vector3(0, 0.003f, 0);
            }
            else if (x >= 90)
            {
                spott.transform.position -= new Vector3(0, 0.003f, 0);
            }
            x++;
            spott.transform.eulerAngles += new Vector3(0, 0, 1);
        }
        rotating = false;
        CancelInvoke();
    }

    IEnumerator RotateRight()
    {
        rotating = true;
        int x = 0;
        while (x < 180)
        {
            yield return new WaitForSeconds(0.02f);
            if (x < 90)
            {
                spott.transform.position += new Vector3(0, 0.003f, 0);
            }
            else if (x >= 90)
            {
                spott.transform.position -= new Vector3(0, 0.003f, 0);
            }
            x++;
            spott.transform.eulerAngles += new Vector3(0, 0, -1);
        }
        rotating = false;
        CancelInvoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("izasao");

        if (other.gameObject.CompareTag("GameController"))
        {
            SolderPanel.SetActive(false);
        }
    }
}
