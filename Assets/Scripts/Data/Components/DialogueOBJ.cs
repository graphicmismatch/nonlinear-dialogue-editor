using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueOBJ : MonoBehaviour
{
    public TMP_Text Title;
    public GameObject TreeEndNotif;

    public DialogueData dd;

    public Transform entry;
    public Transform exit;
    public List<Transform> ds;
    public List<GameObject> lines;
    public GameObject lineObj;
    private void Start()
    {
        ds = new List<Transform>();
        lines = new List<GameObject>();
        DialogueTreeManager.tree.refreshLines.AddListener(UpdateLines);
        DialogueTreeManager.tree.fullLineRefresh.AddListener(UpdateDisplay);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadData(DialogueData d) {
        dd = new DialogueData(d);
        DialogueTreeManager.tree.dREF.Add(this);
        DialogueTreeManager.tree.dialogues.Add(this, dd);
        UpdateDisplay();

    }
    public void Init() {
        dd = new DialogueData();
        
      
        dd.id = DialogueTreeManager.tree.dREF.Count ;
        DialogueTreeManager.tree.dREF.Add(this);
        DialogueTreeManager.tree.dialogues.Add(this, dd);
        UpdateDisplay();

    }
    public void UpdateDisplay() {
        Title.text = dd.id.ToString() + '-' + dd.title;
        ds.Clear();
        foreach (OptionData op in dd.options) {
            if (op.id >= 0 && op.id < DialogueTreeManager.tree.dREF.Count && op.id != dd.id && DialogueTreeManager.tree.dREF[op.id].entry != null) {
                ds.Add(DialogueTreeManager.tree.dREF[op.id].entry);
            }
        }
        foreach (GameObject g in lines) {
            Destroy(g);
        }
        lines = new List<GameObject>();
        foreach (Transform e in ds)
        {
            if (e == null) {
                ds.Remove(e);
                continue;
            }
            GameObject g = Instantiate(lineObj, exit);
            List<Vector2> pts = new List<Vector2>();
            pts.Add(Vector2.zero);
            pts.Add(exit.InverseTransformPoint(e.position));
            g.GetComponent<UILineRenderer>().points = pts;
            lines.Add(g);
        }
        UpdateLines();

    }

    public void UpdateLines() {
        int counter = 0;
        foreach (GameObject g in lines) {
            if (ds[counter] == null) {
                continue;
            }
            List<Vector2> pts = new List<Vector2>();
            pts.Add(Vector2.zero);
            pts.Add(exit.InverseTransformPoint(ds[counter].position));
            g.GetComponent<UILineRenderer>().points = pts;
            g.GetComponent<UILineRenderer>().SetAllDirty();
            counter++;
        }
    }
}
