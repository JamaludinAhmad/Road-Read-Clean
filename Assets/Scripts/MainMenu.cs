using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void mulaiGame(){
        SceneManager.LoadScene("Main");
        print("Game dimulai");

    }
    
}
