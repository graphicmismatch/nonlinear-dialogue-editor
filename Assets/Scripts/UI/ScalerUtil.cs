using UnityEngine;

public class ScalerUtil : MonoBehaviour
{
    public RectTransform thisObj;

    public bool doWidth;
    public bool doHeight;

    private void Update()
    {
        Scale();
    }

    public void Scale() {
        int l = transform.childCount;
        Vector2 Temp = new Vector2();


        for (int i = 0; i < l; i++) {
            RectTransform v = transform.GetChild(i).GetComponent<RectTransform>();
            if (doWidth)
            {
                Temp += new Vector2(v.sizeDelta.x, 0);
            }
            if (doHeight)
            {
                Temp += new Vector2(0, v.sizeDelta.y);
            }
        }
        if (Temp.x == 0) {
            Temp += new Vector2(thisObj.sizeDelta.x,0);
        }
        if (Temp.y == 0)
        {
            Temp += new Vector2(0,thisObj.sizeDelta.y);
        }
        thisObj.sizeDelta = Temp;

    }
}
