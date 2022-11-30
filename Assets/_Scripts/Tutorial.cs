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
    [SerializeField] GameObject guide;
    [SerializeField] GameObject tutorialRadio;
    [SerializeField] GameObject tutorialChip;
    [SerializeField] GameObject TutorialPanelMovement;
    [SerializeField] GameObject TutorialPanelTablet;
    [SerializeField] GameObject TutorialPanelPickup;
    [SerializeField] GameObject TutorialPanelConnect;
    [SerializeField] GameObject TutorialPanelSolder;
    // Start is called before the first frame update
    void Start()
    {
        TutorialPanelMovement.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TutorialProgress();
        TutorialTabeletUsing();
        TutorialWASDPressing();
        TutorialPickUpChip();
        TutorialConnectChip();
        TutorialSolderChip();
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
        if (TutorialPanelConnect.activeInHierarchy && guide.transform.childCount == 1)
        {
            pickedUpChip = false;
            connectedChip = true;
        }
    }

    void TutorialSolderChip()
    {
        if (TutorialPanelSolder.activeInHierarchy && tutorialChip.activeInHierarchy)
        {

        }
    }
}
