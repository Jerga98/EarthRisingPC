using UnityEngine;

public class CubeSatComposition : MonoBehaviour
{
    [SerializeField] private Transform
        position1,
        position2,
        position3,
        position4,
        position5;

    private TabletMechanics _tabletMechanics;
    private SolderChecker _solderChecker;
    private string objectTag;
    private GameObject childObject;

    private void OnTriggerEnter(Collider other)
    {

        if (position1.childCount == 0 && !other.gameObject.CompareTag("GameController") &&
            !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            Transform transform1;
            (transform1 = other.transform).SetParent(position1.transform, false);
            other.transform.rotation = position1.transform.rotation;
            transform1.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (position1.childCount > 0 && !other.gameObject.CompareTag("GameController") &&
                 !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            return;
        }

        if (position2.childCount == 0 && !other.gameObject.CompareTag("GameController") && position1.childCount > 0 &&
            !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            Transform transform1;
            (transform1 = other.transform).SetParent(position2.transform, false);
            transform1.localPosition = new Vector3(0, 0, 0);
            other.transform.rotation = position2.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (position2.childCount > 1 && !other.gameObject.CompareTag("GameController") &&
                 !other.gameObject.CompareTag("Untagged"))
        {
            return;
        }

        if (position3.childCount == 0 && !other.gameObject.CompareTag("GameController") && position1.childCount > 0 &&
            position2.childCount > 0 && !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            other.transform.SetParent(position3.transform, false);
            other.transform.rotation = position3.transform.rotation;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (position3.childCount > 1 && !other.gameObject.CompareTag("GameController") &&
                 !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            return;
        }

        if (position4.childCount == 0 && !other.gameObject.CompareTag("GameController") && position1.childCount > 0 &&
            position2.childCount > 0 && position3.childCount > 0 && !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            other.transform.SetParent(position4.transform, false);
            other.transform.rotation = position4.transform.rotation;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (position4.childCount > 1 && !other.gameObject.CompareTag("GameController") &&
                 !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            return;
        }

        if (position5.childCount == 0 && !other.gameObject.CompareTag("GameController") && position1.childCount > 0 &&
            position2.childCount > 0 && position3.childCount > 0 && position4.childCount > 0 &&
            !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            other.transform.SetParent(position5.transform, false);
            other.transform.rotation = position5.transform.rotation;
            other.transform.localPosition = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (position4.childCount > 1 && !other.gameObject.CompareTag("GameController") &&
                 !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("MainCamera"))
        {
            return;
        }
    }


    private void Awake()
    {
        _solderChecker = FindObjectOfType<SolderChecker>();
        _tabletMechanics = FindObjectOfType<TabletMechanics>();
        _tabletMechanics = FindObjectOfType<TabletMechanics>();
    }
}