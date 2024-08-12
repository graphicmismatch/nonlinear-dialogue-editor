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

    public void export() {
        DialogueTree export = new DialogueTree();
        export.chars = chars.ToArray();
        export.dialogues = dialogues.Values.ToArray<DialogueData>();
        export.variables = variables;
        string exp = JsonConvert.SerializeObject(export,Formatting.Indented);
        if (!File.Exists(Application.persistentDataPath + "/export.wasde"))
        {
           FileStream fs =  File.Create(Application.persistentDataPath + "/export.wasde");
            fs.Close();
        }
        File.WriteAllText(Application.persistentDataPath + "/export.wasde",exp);
        
        Application.OpenURL(Application.persistentDataPath);
    }
}
