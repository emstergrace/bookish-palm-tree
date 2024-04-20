using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{

    public Button button;
    public GameObject SettingsPanel;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => OnSettingsPressed());
    }

    void OnSettingsPressed() {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
	}
}
