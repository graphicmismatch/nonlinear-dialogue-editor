using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DialogueTree{
    public Dictionary<string, float> variables;
    public List<DialogueData> dialogues;
}
public class DialogueTreeManager : MonoBehaviour
{
    public Dictionary<string, float> variables = new Dictionary<string, float>();
    public List<DialogueOBJ> dialogues = new List<DialogueOBJ>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
