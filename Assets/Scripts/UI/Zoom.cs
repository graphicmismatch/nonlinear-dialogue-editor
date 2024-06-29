using UnityEngine;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    public RectTransform rt;
    public float curScale;
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

        if (v.y > 0)
        {
            curScale += 0.1f;
            rt.localScale = Vector3.one * curScale;
            contentScaler.updateZoom();
        }
        else if (v.y < 0) {
            curScale -= 0.1f;
            rt.localScale = Vector3.one * curScale;
            contentScaler.updateZoom();
        }
    
    }
}
