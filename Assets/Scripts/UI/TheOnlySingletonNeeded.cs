using UnityEngine;

public class TheOnlySingletonNeeded : MonoBehaviour
{
    public static bool loaded;
    public static DialogueTreeSave save;
    public static TheOnlySingletonNeeded inst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inst != null && inst != this)
        {
            Destroy(this);
            return;
        }

        inst = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
