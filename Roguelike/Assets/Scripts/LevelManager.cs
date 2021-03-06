﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {    


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Dont destroy on load: " + name);
       
    }
    

    public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);  
              
	}	

	public void LoadNextLevel(){
        Debug.Log("LoadNextLevel Requested");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
	}

    

    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Debug.Log("Quit requested");
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }    

}
