using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public Button respawnButton;

    void Start()
    {
        Button btn = respawnButton.GetComponent<Button>();
        btn.onClick.AddListener(Reset);
    }
    void Reset()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.UnloadSceneAsync("GameOver");
    }
}
