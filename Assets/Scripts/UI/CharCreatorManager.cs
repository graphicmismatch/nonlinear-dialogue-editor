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

       
    }
    void Start()
    {
        
    }
    public void init() {
        Character nc = new Character();
        nc.id = 0;
        nc.Name = "No Character";
        chars.Add(nullchar);
        DialogueTreeManager.tree.chars.Add(nc);
    }
    public void spawnChar() {
        GameObject g =Instantiate(charObj, parent.transform);
        g.GetComponent<CharacterObj>().init();
    }
    public void loadChar(Character[] sd)
    {
        init();
        foreach (Character s in sd)
        {
            if (s.id != 0) {
                GameObject g = Instantiate(charObj, parent.transform);
                g.GetComponent<CharacterObj>().loadChar(s.Name);
            }
            
        }
    }
}
