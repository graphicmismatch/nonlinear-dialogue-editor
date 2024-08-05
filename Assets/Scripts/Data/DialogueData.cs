using UnityEngine;
using System.Collections.Generic;

public class DialogueData
{
    public int id;
    public string title;
    public string line;
    public OptionData[] options = new OptionData[0];
    public VarConstOperation[] variableConstantOperations;
    public VarVarOperation[] variableVariableOperations;

    //left to right
    public int[] charIDs;

    //-1,0,1 for left, center, right
    public int charCurrentlySpeaking;
    public DialogueData() { }
    public DialogueData(DialogueData dd) {
        
        id = dd.id;
        title = dd.title;
        line = dd.line;
        options = dd.options ;
        variableConstantOperations = dd.variableConstantOperations;
        variableVariableOperations = dd.variableVariableOperations;
        charIDs = dd.charIDs;
        charCurrentlySpeaking = dd.charCurrentlySpeaking;
}

}
