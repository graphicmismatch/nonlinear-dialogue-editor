using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
public class CharCreatorManager : MonoBehaviour
{
    public List<CharacterObj> chars;
    public static CharCreatorManager inst;
    public UnityEvent forceReload;
    public GameObject charObj;
    public CharacterObj nullchar;
    public GameObject parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        inst = this;
        chars = new List<CharacterObj>();
        chars.Add(nullchar);
       
    }
    void Start()
    {
        Character nc = new Character();
        nc.id = 0;
        nc.Name = "No Character";
        DialogueTreeManager.tree.chars.Add(nc);
    }

    public void spawnChar() {
        Instantiate(charObj, parent.transform);
    }
}
