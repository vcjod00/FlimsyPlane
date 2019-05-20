using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitonClick : MonoBehaviour
{
    //quits app when quits from menu
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
