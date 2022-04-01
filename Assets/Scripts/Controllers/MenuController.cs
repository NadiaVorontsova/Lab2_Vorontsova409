using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene(2);
    }

    private AudioSource audio;

    private void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }
    public void OnClickSoundUp()
    {
        audio.volume += 0.1f;
        Debug.Log("OnClickSoundUp");
    }
    public void OnClickSoundDown()
    {
        audio.volume -= 0.1f;
        Debug.Log("OnClickSoundDown");
    }

    
}
