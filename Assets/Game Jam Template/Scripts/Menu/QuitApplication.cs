using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour {

    public void Quit()
    {

#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;

#endif

#if UNITY_ANDROID
        //Stop the game by killing its process
        System.Diagnostics.Process.GetCurrentProcess().Kill();

#endif


    }
}
