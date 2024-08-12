using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class ConnectionDisplayManager : MonoBehaviour
{
    public int currID;
    public TMP_Dropdown connNo;

    public GameObject[] whileActive;
    public bool active = false;
    public TMP_InputField content;
    public TMP_InputField connIddisp;
    public void init() {
        if (EditPanelManager.inst.currentlyEditing.dd.options.Length > 0)
        {
            foreach (GameObject g in whileActive)
            {
                g.SetActive(true);
            }

            UpdateConnList();
            UpdateId(0);
            active = true;
        }
        else {
            foreach (GameObject g in whileActive) {
                g.SetActive(false);
            }

            active = false;
        }
    }
    
    public void UpdateId(int value) {
        currID = value;
        connIddisp.text = EditPanelManager.inst.currentlyEditing.dd.options[currID].id+"";
        content.text = EditPanelManager.inst.currentlyEditing.dd.options[currID].title;
        connNo.value = value;
    }
    public void UpdateConnId(string value)
    {
        if (value == null || value == "") {
            value = "0";
        }
        EditPanelManager.inst.EditConnection(currID, int.Parse(value));
    }
    public void UpdateConnText(string value)
    {
        EditPanelManager.inst.EditConnection(currID, value);
    }
    public void removeElement() {
        EditPanelManager.inst.RemoveConnection(currID);
        UpdateConnList();
    
    }
    public void UpdateConnList() {
        if (!active) {
            active = true;
            foreach (GameObject g in whileActive)
            {
                g.SetActive(true);
            }

            UpdateId(0);
        }
        connNo.ClearOptions();

        if (EditPanelManager.inst.currentlyEditing.dd.options.Length <= 0) {
            foreach (GameObject g in whileActive)
            {
                g.SetActive(false);
            }

            active = false;
            return;
        }
        connNo.AddOptions(genTitles(EditPanelManager.inst.currentlyEditing.dd.options.Length));
        UpdateId(EditPanelManager.inst.currentlyEditing.dd.options.Length-1);
    }

    List<string> genTitles(int l) {
        List<string> temp = new List<string>();
        for (int i = 0; i < l; i++) {
            temp.Add("Connection "+i);
        }
        return temp;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
