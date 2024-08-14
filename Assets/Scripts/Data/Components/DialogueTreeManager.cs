using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Events;

public class DialogueTreeManager : MonoBehaviour
{
    public Dictionary<string, float> variables = new Dictionary<string, float>();
    public List<DialogueOBJ> dREF= new List<DialogueOBJ>();
    public List<Character> chars = new List<Character>();
    public Dictionary<DialogueOBJ,DialogueData> dialogues = new Dictionary<DialogueOBJ, DialogueData>();
    public static DialogueTreeManager tree;
    public UnityEvent refreshLines;
    public UnityEvent fullLineRefresh;
    public string folder;
    public string file;

    public Transform dParent;
    public GameObject dialoguePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tree = this;
    }
    public void loadFile(DialogueTreeSave dts) { 
    
    }
    public void newDialogue() {
        GameObject g = Instantiate(dialoguePrefab, dParent);
        
        g.GetComponent<DialogueOBJ>().Init();
        fullLineRefresh.Invoke();
    }

    public void export() {
        try
        {
            DialogueTree export = new DialogueTree();
            export.chars = chars.ToArray();
            export.dialogues = dialogues.Values.ToArray<DialogueData>();
            export.variables = variables;
            string exp = JsonConvert.SerializeObject(export, Formatting.Indented);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(folder + "/" + file + ".wasde"))
            {
                FileStream fs = File.Create(folder + "/" + file + ".wasde");
                fs.Close();
            }
            File.WriteAllText(folder + "/" + file + ".wasde", exp);

            Application.OpenURL(folder);
        }
        catch {
            return;
        }
    }


    public void Save()
    {
        try
        {
            DialogueTreeSave export = new DialogueTreeSave();
            export.chars = chars.ToArray();
            List<DialogueObjSave> ds = new List<DialogueObjSave>();
            foreach (DialogueOBJ v in dREF) {
                ds.Add(new DialogueObjSave(v.dd,v.gameObject.transform.localPosition));
            }
            export.dialogues = ds.ToArray();
            export.variables = variables;
            string exp = JsonConvert.SerializeObject(export, Formatting.Indented);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(folder + "/" + file + ".was"))
            {
                FileStream fs = File.Create(folder + "/" + file + ".was");
                fs.Close();
            }
            File.WriteAllText(folder + "/" + file + ".was", exp);

            Application.OpenURL(folder);
        }
        catch
        {
            return;
        }
    }
}
