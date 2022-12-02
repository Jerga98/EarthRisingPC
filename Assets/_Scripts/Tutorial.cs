using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool moveW = false;
    bool moveA = false;
    bool moveS = false;
    bool moveD = false;
    bool usedTablet = false;
    bool pickedUpChip = false;
    bool connectedChip = false;
    bool solder = false;
    bool connectedWithCSHousing = false;
    bool passedConveyor = false;

    [SerializeField] GameObject guide;
    [SerializeField] GameObject tutorialRadio;
    [SerializeField] GameObject tutorialChip;
    [SerializeField] GameObject tutorialCubesat;
    [SerializeField] GameObject tutorialPosition;
    [SerializeField] GameObject tutorialSides;

    [SerializeField] GameObject tabletPanel;
    [SerializeField] GameObject missionPanel;
    [SerializeField] GameObject pausePanel;

    [SerializeField] GameObject TutorialPanelMovement;
    [SerializeField] GameObject TutorialPanelTablet;
    [SerializeField] GameObject TutorialPanelPickup;
    [SerializeField] GameObject TutorialPanelConnect;
    [SerializeField] GameObject TutorialPanelSolder;
    [SerializeField] GameObject TutorialPanelCubesat;
    [SerializeField] GameObject TutorialPanelCubeSide;
    [SerializeField] GameObject TutorialPanelLaunch;
    [SerializeField] GameObject TutorialPanelEnd;
    [SerializeField] GameObject LaunchPanel;

    //OnContactChangeColor onContact;

    // Start is called before the first frame update
    void Start()
    {
        TutorialPanelMovement.SetActive(true);
        //onContact = FindObjectOfType<OnContactChangeColor>();
    }

    FirstPersonController firstPerson;

    private void Awake()
    {
        firstPerson = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        TutorialProgress();
        TutorialTabeletUsing();
        TutorialWASDPressing();
        TutorialPickUpChip();
        TutorialConnectChip();
        //TutorialSolderChip();
        TutorialSolderingComplete();
        //TutorialCubesatComp();
        TutorialCubesatComp();
        TutorialConveyorBelt();
        TutorialLaunch();
    }

    void TutorialProgress()
    {
        if(TutorialPanelMovement.activeInHierarchy && moveW == true && moveA == true && moveS == true && moveD == true)
        {
            TutorialPanelMovement.SetActive(false);
            TutorialPanelTablet.SetActive(true);
        }
        else if (usedTablet == true)
        {
            TutorialPanelTablet.SetActive(false);
            TutorialPanelPickup.SetActive(true);
        }
        else if (pickedUpChip == true)
        {
            TutorialPanelPickup.SetActive(false);
            TutorialPanelConnect.SetActive(true);
        }
        else if (connectedChip == true)
        {
            TutorialPanelSolder.SetActive(true);
            TutorialPanelConnect.SetActive(false);
        }
        else if(solder == true)
        {
            tutorialCubesat.SetActive(true);
            TutorialPanelSolder.SetActive(false);
            TutorialPanelCubesat.SetActive(true);
        }
        else if(connectedWithCSHousing == true)
        {
            //tutorialSides.SetActive(true);
            TutorialPanelCubesat.SetActive(false);
            TutorialPanelCubeSide.SetActive(true);
        }
        else if(passedConveyor == true)
        {
            Debug.Log("Launch jebeni panel jebote");
            TutorialPanelCubeSide.SetActive(false);
            TutorialPanelLaunch.SetActive(true);
        }

    }
    void TutorialWASDPressing()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveW = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveA = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveS = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveD = true;
        }
    }

    void TutorialTabeletUsing()
    {
        if (TutorialPanelTablet.activeInHierarchy && Input.GetKeyDown(KeyCode.T))
        {
            usedTablet = true;
        }
    }

    void TutorialPickUpChip()
    {
        if (TutorialPanelPickup.activeSelf && guide.transform.childCount == 1)
        {
            usedTablet = false;
            pickedUpChip = true;
            tutorialRadio.SetActive(true);
        }
    }
    void TutorialConnectChip()
    {
        if (TutorialPanelConnect.activeInHierarchy && tutorialChip.activeInHierarchy)
        {
            pickedUpChip = false;
            connectedChip = true;
        }
    }

    //void TutorialSolderChip()
    //{
    //    if (TutorialPanelSolder.activeInHierarchy && tutorialChip.activeInHierarchy)
    //    {
    //        connectedChip = false;
    //        solder = true;
    //    }
    //}
    void TutorialSolderingComplete()
    {
        if (TutorialPanelSolder.activeInHierarchy && OnContactChangeColor.tutorialIsFinished)
        {
            connectedChip = false;
            solder = true;

        }
    }

    void TutorialCubesatComp()
    {
        if (TutorialPanelCubesat.activeInHierarchy && tutorialPosition.transform.childCount == 1)
        {
            connectedWithCSHousing = true;
            solder = false;
        }
    }

    void TutorialConveyorBelt()
    {
        if (TutorialPanelCubeSide.activeInHierarchy && CubeSatCheck.launchableTutorial)
        {
            connectedWithCSHousing = false;
            passedConveyor = true;
        }
    }

    void TutorialLaunch()
    {
        if (TutorialPanelLaunch.activeInHierarchy && LaunchPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            passedConveyor = false;
            StartCoroutine(EndTutorial());
            Debug.Log("završila korutina");

        }
    }

    IEnumerator EndTutorial()
    {
        Debug.Log("krenula korutina");
        yield return new WaitForSeconds(4f);

        tabletPanel.SetActive(false);
        missionPanel.SetActive(false);
        pausePanel.SetActive(false);
        PausePC.GameIsPaused = true;

        firstPerson.CanMove = false;
        Cursor.visible = true;
        PlayerPrefs.SetInt("FirstTime", 1);
        Cursor.lockState = CursorLockMode.None;
        TutorialPanelLaunch.SetActive(false);
        TutorialPanelEnd.SetActive(true);
        Time.timeScale = 0f;
        
    }
}
