using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


public class DialogueTreeManager : MonoBehaviour
{
    public Dictionary<string, float> variables = new Dictionary<string, float>();
    public List<DialogueOBJ> dREF= new List<DialogueOBJ>();
    public List<Character> chars = new List<Character>();
    public Dictionary<DialogueOBJ,DialogueData> dialogues = new Dictionary<DialogueOBJ, DialogueData>();
    public static DialogueTreeManager tree;


    public Transform dParent;
    public GameObject dialoguePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tree = this;
    }

    public void newDialogue() {
        GameObject g = Instantiate(dialoguePrefab, dParent);
        g.GetComponent<DialogueOBJ>().Init();
    }

    public void export(string path, string filename) {
        try
        {
            DialogueTree export = new DialogueTree();
            export.chars = chars.ToArray();
            export.dialogues = dialogues.Values.ToArray<DialogueData>();
            export.variables = variables;
            string exp = JsonConvert.SerializeObject(export, Formatting.Indented);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "/" + filename + ".wasde"))
            {
                FileStream fs = File.Create(path + "/" + filename + ".wasde");
                fs.Close();
            }
            File.WriteAllText(path + "/" + filename + ".wasde", exp);

            Application.OpenURL(path);
        }
        catch {
            return;
        }
    }
    public void Save(string path, string filename)
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

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "/" + filename + ".was"))
            {
                FileStream fs = File.Create(path + "/" + filename + ".was");
                fs.Close();
            }
            File.WriteAllText(path + "/" + filename + ".was", exp);

            Application.OpenURL(path);
        }
        catch
        {
            return;
        }
    }
}
