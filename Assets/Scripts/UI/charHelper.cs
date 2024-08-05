using UnityEngine;

public class charHelper : MonoBehaviour
{
    public int id;

    public void editchar(int value) {
        EditPanelManager.inst.EditCharacter(id, value);
    }
}
