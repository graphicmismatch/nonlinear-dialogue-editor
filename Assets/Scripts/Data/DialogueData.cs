using UnityEngine;

public enum VarOperators
{
    ADD, SUB, MUL, DIV, EXP, LOG10, LOG, LESSTHAN, GREATERTHAN, EQUAL, LESSEQUAL, GREATEREQUAL
}
public struct CharacterData {
    public string charName;
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
public class DialogueData
{
    public int id;
    public string title;
    public string line;
    public OptionData[] options;
    public VarConstOperation[] variableConstantOperations;
    public VarVarOperation[] variableVariableOperations;
    
}
