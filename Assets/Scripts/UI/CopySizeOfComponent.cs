using UnityEngine;

public class CopySizeOfComponent : MonoBehaviour
{
    public RectTransform target;
    public RectTransform thisObj;

    public bool doWidth;
    public bool doHeight;

    public Vector2 padding;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSize();
    }

    public void updateSize() {
        thisObj.sizeDelta = new Vector2((doWidth) ? target.sizeDelta.x+padding.x*2 : thisObj.sizeDelta.x, (doHeight) ? target.sizeDelta.y + padding.y * 2 : thisObj.sizeDelta.y);
    }
}
