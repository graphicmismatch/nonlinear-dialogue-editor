using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueOBJ : MonoBehaviour
{
    public TMP_Text Title;
    public GameObject TreeEndNotif;

    public DialogueData dd;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadData(DialogueData d) {
        dd = new DialogueData(d);
        UpdateDisplay();

    }
    public void Init() {
        dd = new DialogueData();
        
        if (DialogueTreeManager.tree.dialogues.Count > 1)
        {
            dd = new DialogueData(DialogueTreeManager.tree.dREF[DialogueTreeManager.tree.dialogues.Count - 2].dd);
        }
      
        dd.id = DialogueTreeManager.tree.dREF.Count ;
        DialogueTreeManager.tree.dREF.Add(this);
        DialogueTreeManager.tree.dialogues.Add(this, dd);
        UpdateDisplay();

    }
    public void UpdateDisplay() {
        Title.text = dd.id.ToString() + '-' + dd.title;
    }
}
