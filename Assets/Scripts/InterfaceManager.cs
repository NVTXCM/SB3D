using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
#region variable
    public GameObject panelTerrain;
    public GameObject panelHuongMuiTC;
    public GameObject panelSCH;
    public GameObject panelBB;
    public GameObject panelPKKQ;
    public GameObject panelHQ;
    public GameObject panelPB;
    public Camera mainCam;
#endregion variable
    // Start is called before the first frame update
    void Start()
        
    {
       
        SetViewHidePanel(panelTerrain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetViewHidePanel(GameObject panel)
        {
            panelBB.gameObject.SetActive(false);
            panelHQ.gameObject.SetActive(false);
            panelHuongMuiTC.gameObject.SetActive(false);
            panelPB.gameObject.SetActive(false);
            panelPKKQ.gameObject.SetActive(false);
            panelSCH.gameObject.SetActive(false);
            panelTerrain.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
        }

    public void EnableDisableCameraController(bool bSet) 
        {
            mainCam.GetComponent<maxCamera>().enabled = bSet;
        }
}
