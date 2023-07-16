using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnEnable() {
        PlayerPrefs.SetInt("hits", 0);
        PlayerPrefs.SetInt("shoots", 0);
        PlayerPrefs.SetInt("stagesCleared", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {
        SceneManager.LoadScene("PCGScene");
    }
}
