using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Vector2 cursorHotspot;

    public Texture2D cursorHand;
    public Vector2 handHotspot;
    
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorHand, handHotspot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorNormal, cursorHotspot, CursorMode.Auto);
    }
}
