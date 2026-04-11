using System;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private bool loadAdditionalLevels = false;
    private const string Level1 = "Level 1";
    
    private void Start() {
        #if UNITY_EDITOR
        if (loadAdditionalLevels) {
            LoadLevels();
        }
#else
        LoadLevels();
#endif
        
        FadeManager.Instance.FadeFromBlack();
    }
    private void LoadLevels() {
        SceneManager.LoadScene(Level1, LoadSceneMode.Additive);

    }

}
