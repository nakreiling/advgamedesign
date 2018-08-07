using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class nextScene : MonoBehaviour {

    public void changeToScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
