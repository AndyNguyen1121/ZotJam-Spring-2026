using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu {
    public class MainMenuManager : MonoBehaviour {
        
        public void LoadGame() {
            StartCoroutine(FadeToNewScene());
        }

        private IEnumerator FadeToNewScene() {
            FadeManager.Instance.FadeToBlack();
            yield return new WaitForSeconds(FadeManager.Instance.blackoutTime);
            SceneManager.LoadScene("Game");
        }
    }
}