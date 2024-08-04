using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class DialogueOBJ : MonoBehaviour
{
    public TMP_Text Title;
    public OptionManager options;
    public GameObject TreeEndNotif;

    public DialogueData dd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        dd = new DialogueData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadData(DialogueData d) {
        dd = new DialogueData(d);
    }
    public void Init() {
        DialogueTreeManager.tree.dREF.Add(this);
        DialogueTreeManager.tree.dialogues.Add(this, dd);
        if (DialogueTreeManager.tree.dialogues.Count > 1)
        {
            dd = new DialogueData(DialogueTreeManager.tree.dREF[DialogueTreeManager.tree.dialogues.Count - 2].dd);
        }
        dd.id = DialogueTreeManager.tree.dialogues.Count - 1;

    }
}
