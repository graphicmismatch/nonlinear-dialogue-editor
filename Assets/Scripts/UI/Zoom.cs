using UnityEngine;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    public RectTransform rt;
    public float curScale;
    public float zoomInSens;
    public float zoomOutSens;
    public Vector2 zoomBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScroll(InputAction.CallbackContext ctx) {
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
        }
        
    }
}
