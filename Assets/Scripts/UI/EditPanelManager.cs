using UnityEngine;

public class EditPanelManager : MonoBehaviour
{

    public DialogueOBJ currentlyEditing;
    public static EditPanelManager inst;

    private void Awake()
    {
        inst = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditCharacter(int id, int value) {
        currentlyEditing.dd.charIDs[id] = value;
    }
    public void EditSpeaking(int id)
    {
        currentlyEditing.dd.charCurrentlySpeaking = id;
    }
    public void EditLine(string value)
    {
        currentlyEditing.dd.line = value;
    }
    public void EditConnection(int id, int connID, string value)
    {
        currentlyEditing.dd.options[id].id = connID;
        currentlyEditing.dd.options[id].title = value;
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
