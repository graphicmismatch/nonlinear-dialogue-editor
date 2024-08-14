using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class EditPanelManager : MonoBehaviour
{

    public DialogueOBJ currentlyEditing;
    public static EditPanelManager inst;

    public GameObject Panel;
    public TMP_InputField title;
    public TMP_Text id;

    public TMP_Dropdown[] charSel;
    public Toggle[] speakSel;

    public TMP_InputField content;

    public ConnectionDisplayManager cdm;

    private void Awake()
    {
        inst = this;


    }

    public void Load(DialogueOBJ d) {
        Panel.SetActive(true);
        currentlyEditing = d;
        title.text = currentlyEditing.dd.title;
        id.text = currentlyEditing.dd.id + "";
        content.text = currentlyEditing.dd.line;
        cdm.init();
        int j = 0;
        foreach (var v in charSel) {
            v.ClearOptions();
            v.AddOptions(genCharTitles(DialogueTreeManager.tree.chars.ToArray()));
            v.value = currentlyEditing.dd.charIDs[j];
            j++;
        }

            speakSel[currentlyEditing.dd.charCurrentlySpeaking].isOn = true;


    }

    public void onClosePanel() {
        currentlyEditing.UpdateDisplay();
    }
    List<string> genCharTitles(Character[] op)
    {
        List<string> temp = new List<string>();
        foreach(Character o in op)
        {
            temp.Add(o.Name);
        }
        return temp;
    }
    public void EditTitle(string value) {
        currentlyEditing.dd.title = value;
    }
    public void EditCharacter(int id, int value) {
        currentlyEditing.dd.charIDs[id] = value;
    }
    public void EditSpeaking(int id)
    {
        currentlyEditing.dd.charCurrentlySpeaking = id;
    }
    public void ClearSpeaking()
    {
        currentlyEditing.dd.charCurrentlySpeaking = -1;
    }
    public void EditLine(string value)
    {
        currentlyEditing.dd.line = value;
    }
    public void EditConnection(int id, int connID, string value)
    {
        if (connID == null) {
            connID = 0;
        }
        currentlyEditing.dd.options[id].id = connID;
        currentlyEditing.dd.options[id].title = value;
    }
    public void EditConnection(int id, string value)
    {
        currentlyEditing.dd.options[id].title = value;
    }
    public void EditConnection(int id, int connID)
    {
        if (connID == null)
        {
            connID = 0;
        }
        currentlyEditing.dd.options[id].id = connID;
    }
    public void AddConnection()
    {
        OptionData[] temp = new OptionData[currentlyEditing.dd.options.Length + 1];
        for (int i = 0; i < currentlyEditing.dd.options.Length; i++) {
            temp[i] = currentlyEditing.dd.options[i];
        }
        temp[currentlyEditing.dd.options.Length] = new OptionData();
        currentlyEditing.dd.options = temp;
    }
    public void RemoveConnection(int id)
    {
        if (id >= currentlyEditing.dd.options.Length || id < 0) { 
            return;
        }
        OptionData[] temp = new OptionData[currentlyEditing.dd.options.Length -1];
        int t = 0;
        for (int i = 0; i < currentlyEditing.dd.options.Length; i++)
        {
            if (i == id) {
                continue;
            }
            temp[t] = currentlyEditing.dd.options[i];
            t++;
        }
        currentlyEditing.dd.options = temp;
    }
    public void SwapConnection(int a, int b)
    {
        if (a >= currentlyEditing.dd.options.Length || a < 0|| b >= currentlyEditing.dd.options.Length || b < 0)
        {
            return;
        }
        OptionData temp = currentlyEditing.dd.options[b];
        currentlyEditing.dd.options[b] = currentlyEditing.dd.options[a];
        currentlyEditing.dd.options[a] = temp;
    }
}
