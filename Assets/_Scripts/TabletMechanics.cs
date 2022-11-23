using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using Toggle = UnityEngine.UI.Toggle;

public class TabletMechanics : MonoBehaviour
{
    [BoxGroup("Printer variables")]
    [SerializeField]
    private GameObject printPanel;

    [BoxGroup("Printer variables")]
    [SerializeField]
    private Transform parent;

    [BoxGroup("Printer variables")]
    [SerializeField]
    private AudioSource microwaveSound;

    [BoxGroup("Printer variables")]
    [SerializeField]
    private Animator animator;

    [BoxGroup("Printer variables")]
    [SerializeField]
    private float maxTimer;

    [BoxGroup("Toggle")] [SerializeField] private GameObject _togglePrefab;
    [BoxGroup("Toggle")] [SerializeField] private ToggleGroup _toggleGroup;

    [BoxGroup("Text")] [SerializeField] public TMP_Text debugText;
    [BoxGroup("Text")] [SerializeField] private TMP_Text timerText;

    public int instaceID = 0;

    private float timerCounter;
    private bool isTimerActive;
    private Sprite getSprite;
    private string itemDescription;

    private Dictionary<Toggle, GameObject> compareObjects;

    [BoxGroup("SO List")]
    [SerializeField]
    public List<PrintableItemsSO> _printableItemsSos = new List<PrintableItemsSO>();

    /*[BoxGroup("SO List")]*/
    [SerializeField] private PrintableItemsSO _currentlyPrinting;


    private void Start()
    {
        if (instaceID == 0)
        {
            instaceID = GetInstanceID();
        }

        if (_toggleGroup == null)
        {
            _toggleGroup = GetComponent<ToggleGroup>();
        }

        /*
        foreach (var toggle in _toggles)
        {
            foreach (var prefab in prefabs)
            {
                compareObjects.Add(toggle, prefab);
                Debug.Log(compareObjects);
                debugText.text += compareObjects;
            }
        }
        */
        for (int i = 0; i < _printableItemsSos.Count; i++)
        {
            Toggle tempToggle = Instantiate(_togglePrefab, _toggleGroup.transform).GetComponent<Toggle>();
            //tempToggle = GetComponent<Toggle>();

            //itemDescription = _printableItemsSos[i].description;
            tempToggle.graphic.GetComponent<Image>().sprite = _printableItemsSos[i].sprite;
            _printableItemsSos[i].objectName = _printableItemsSos[i].name;
            tempToggle.GetComponentInChildren<TextMeshProUGUI>().text = _printableItemsSos[i].objectName;
            //itemDescription = _printableItemsSos[i].description;
            tempToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(); });
            tempToggle.group = _toggleGroup;
            tempToggle.isOn = false;
        }
    }


    [ContextMenu("PrintItem")]
    public void OnClickPrint()
    {
        //debugText.text = "Clicked button";

        Toggle selectedToggle = null;
        int index = -1;
        for (int i = 0; i < _toggleGroup.transform.childCount; i++)
        {
            if (_toggleGroup.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                selectedToggle = _toggleGroup.transform.GetChild(i).GetComponent<Toggle>();
                //selectedToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(_printableItemsSos[i].description); });
                index = i;
                break;
            }
        }


        if (selectedToggle != null)
        {
            //itemDescription = _printableItemsSos[index].description;
            //debugText.text += "\n" + _printableItemsSos[index].name + " is being printed";
            _currentlyPrinting = _printableItemsSos[index];
            printPanel.SetActive(false);
            timerText.gameObject.SetActive(true);
            isTimerActive = true;
            maxTimer = _printableItemsSos[index].timeToInstantiate;
            timerCounter = maxTimer;
            animator.SetTrigger("Close");
        }
        else
        {
            //debugText.text += "\nSelectedToggle is null";
        }
    }

    void ToggleValueChanged()
    {
        Toggle selectedToggle = null;
        int index = -1;
        for (int i = 0; i < _toggleGroup.transform.childCount; i++)
        {
            if (_toggleGroup.transform.GetChild(i).GetComponent<Toggle>().isOn)
            {
                selectedToggle = _toggleGroup.transform.GetChild(i).GetComponent<Toggle>();
                //selectedToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(_printableItemsSos[i].description); });
                index = i;
                break;
            }
        }

        debugText.text = _printableItemsSos[index].description;
    }

    private void Update()
    {
        if (timerCounter > 0)
        {
            timerCounter -= Time.deltaTime;
        }

        if (isTimerActive)
        {
            DisplayTime(timerCounter);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            isTimerActive = false;
            printPanel.SetActive(true);
            timerText.gameObject.SetActive(false);
            PrintObjects();
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }

    [ContextMenu("PrintObjects")]
    private void PrintObjects()
    {
        ulong @ulong = Convert.ToUInt32(maxTimer);
        animator.SetTrigger("Open");
        microwaveSound.Play(@ulong);
        Instantiate(_currentlyPrinting.prefab, parent);
    }
}