using UnityEngine;

public class LineData : MonoBehaviour, IListItemData
{
    string s;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void init(string[] args) {
        s = args[0];
    }
}
