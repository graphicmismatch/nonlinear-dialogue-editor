using UnityEngine;
using System.Collections.Generic;
using System.Linq;




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
}
