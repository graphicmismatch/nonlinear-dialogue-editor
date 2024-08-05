using UnityEngine;
using System.Collections.Generic;
public interface IListItemData {
}
public class ListDisplay : MonoBehaviour
{
    public List<IListItemData> items = new List<IListItemData>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }
    public void AddItem(IListItemData item) { 
    
    }
}
