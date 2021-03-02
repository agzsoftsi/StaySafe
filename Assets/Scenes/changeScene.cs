using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Change Scene when Click is pressed
    public void ChangeE(string nameScene){

        SceneManager.LoadScene(nameScene);
    }

     // Exit of the game
    // public void CloseGame(){
        // Application.Quit();
     //}

}
