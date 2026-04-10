using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    private const string Level1 = "Level 1";
    
    private void Start() {
        SceneManager.LoadScene(Level1, LoadSceneMode.Additive);
    }
}
