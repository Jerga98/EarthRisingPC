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
    [SerializeField] bool solderingMode = false;

    [SerializeField] Transform solderingPos;

    public GameObject spott;

    bool rotating = false;

    [SerializeField] float rotationSpeed = 2f;

    FirstPersonController firstPerson;

    private void Awake()
    {
        firstPerson = FindObjectOfType<FirstPersonController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && SolderPanel.activeInHierarchy)
        {
            Debug.Log("Radi E");
            if(solderingMode == false)
            {
                solderingCamera.SetActive(true);
                playerCamera.SetActive(false);
                solderingMode = true;
                text.text = solderingText;
                firstPerson.CanMove = false;

            }
            else if(solderingMode == true)
            {
                playerCamera.SetActive(true);
                solderingCamera.SetActive(false);
                solderingMode = false;
                text.text = notSolderingText;
                firstPerson.CanMove = true;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("usao");
        if (other.gameObject.CompareTag("GameController"))
        {
            SolderPanel.SetActive(true);
        }
        else if (!other.gameObject.CompareTag("GameController") &&
            !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
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
