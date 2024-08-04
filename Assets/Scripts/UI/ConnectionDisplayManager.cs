using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ConnectionDisplayManager : MonoBehaviour
{
    public int currID;
    public Dropdown connNo;
    public void UpdateId(int value) {
        currID = value;
    }
    public void removeElement() {
        EditPanelManager.inst.RemoveConnection(currID);
        UpdateConnList();
    
    }
    public void UpdateConnList() {
        connNo.ClearOptions();
        connNo.AddOptions(genTitles(EditPanelManager.inst.currentlyEditing.dd.options.Length));
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
