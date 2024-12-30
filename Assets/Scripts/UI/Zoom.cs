using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Zoom : MonoBehaviour
{
    public RectTransform rt;
    public float curScale;
    public float zoomInSens;
    public float zoomOutSens;
    public Vector2 zoomBounds;
    public Slider zoomSlider;
    public static bool doZoom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doZoom = true;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDoZoom(bool t) { doZoom = t; }

    public void OnScroll(InputAction.CallbackContext ctx) {
        if (!doZoom) { return; }
        Vector2 v = ctx.ReadValue<Vector2>();
        if (!Mathf.Approximately(v.y, 0))
        {
            if (v.y > 0)
            {
                curScale += zoomInSens;
                
            }
            else if (v.y < 0)
            {
                curScale -= zoomOutSens;              
            }
            
            curScale = Mathf.Clamp(curScale, zoomBounds.x, zoomBounds.y);
            rt.localScale = Vector3.one * curScale;
            contentScaler.updateZoom();
            zoomSlider.value = curScale;
        }
        
    }

    public void setScroll(float n) {
        curScale = n;
        rt.localScale = Vector3.one * curScale;
        contentScaler.updateZoom();
    }
    public void resetScroll()
    {
        curScale = 1;
        rt.localScale = Vector3.one * curScale;
        contentScaler.updateZoom();
        zoomSlider.value = curScale;
    }
}
