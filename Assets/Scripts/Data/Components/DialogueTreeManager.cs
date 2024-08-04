using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public enum VarOperators
{
    ADD, SUB, MUL, DIV, EXP, LOG10, LOG, LESSTHAN, GREATERTHAN, EQUAL, LESSEQUAL, GREATEREQUAL
}
public struct OptionData
{
    public VarConstOperation[] constCheck;
    public VarVarOperation[] varCheck;
    public string title;
    public int id;
}
public struct VarConstOperation
{
    public string varName;
    public VarOperators op;
    public float num;
}
public struct VarVarOperation
{
    public string varName;
    public VarOperators op;
    public string var2Name;
}

public class DialogueTree{
    public Dictionary<string, float> variables;
    public List<Character> chars;
    public List<DialogueData> dialogues;
}
public struct Character {
    public int id;
    public string Name;
}


public class DialogueTreeManager : MonoBehaviour
{
    public Dictionary<string, float> variables = new Dictionary<string, float>();
    public List<DialogueOBJ> dREF= new List<DialogueOBJ>();
    public List<Character> chars = new List<Character>();
    public Dictionary<DialogueOBJ,DialogueData> dialogues = new Dictionary<DialogueOBJ, DialogueData>();
    public static DialogueTreeManager tree;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
