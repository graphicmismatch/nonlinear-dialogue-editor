using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class contentScaler : MonoBehaviour
{
    public static float height;
    public static float width;
    public static float zheight;
    public static float zwidth;
    public static Vector2 bounds;
    public RectTransform content;
    public static contentScaler inst;
    public static Vector2 padding;
    public RectTransform scale;

    // Start is called before the first frame update
    public void Awake()
    {
        padding = new Vector2(30, 30);
        height = content.rect.height;
        width = content.rect.width;
        inst = this;
    }
    public void Start()
    {
        
        ForceUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ForceUpdateUI()
    {
 
    }
    public static void ForceUpdate()
    {
        inst.scale.sizeDelta = new Vector2(width*inst.scale.localScale.x,height * inst.scale.localScale.y);
        inst.content.sizeDelta = inst.scale.sizeDelta;

    }
    public static void updateBounds(Vector2 nb,Vector2 size) {
        if (Mathf.Abs(nb.x) >= (width - padding.x) / 2) {
            width = (Mathf.Abs(nb.x) + padding.x) * 2;
            width += size.x;
        }
        if (Mathf.Abs(nb.y) >= (height - padding.y) / 2)
        {
            height = (Mathf.Abs(nb.y) + padding.y) * 2;
            height += size.y;
        }
        
        ForceUpdate();
    }
    public static void updateZoom()
    {
        
        ForceUpdate();
    }
}
