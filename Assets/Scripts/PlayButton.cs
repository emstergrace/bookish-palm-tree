using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button button;
    public string sceneName = "SampleScene";

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => OnPlayPressed());
    }

    void OnPlayPressed() {
        SceneManager.LoadScene(sceneName);
	}
}
