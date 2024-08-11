using UnityEngine;

public class charHelper : MonoBehaviour
{
    public int id;

    public void editchar(int value) {
        EditPanelManager.inst.EditCharacter(id, value);
    }
    public void currentlySpeaking(bool t) {
        if (t) {
            EditPanelManager.inst.EditSpeaking(id);
        }
    }
    
}
