using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum States 
{
    MainMenu,
    Ej1,
    Ej2,
    Ej3,
    Ej4,
    Ej5,
    Ej6,
    Ej11,
    Ej13,
    Ej15,
    Ej17,
    Ej18
}
public class WindowsManager : MonoBehaviour
{
    private int tp;
    private int ej;
    private string nextScene;
    private string prevScene;
    private string mm;

    [SerializeField] private States currentState;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void Update()
    {

        switch (currentState)
        {
            case States.MainMenu:

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej1;
                    SceneManager.LoadScene("TP01_EJ01_Scene");
                }
                break;

            case States.Ej1:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej2;
                    SceneManager.LoadScene("TP02_EJ02_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;


            case States.Ej2:

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej1;
                    SceneManager.LoadScene("TP01_EJ01_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej3;
                    SceneManager.LoadScene("TP02_EJ03_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej3:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej2;
                    SceneManager.LoadScene("TP02_EJ02_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej4;
                    SceneManager.LoadScene("TP03_EJ04_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej4:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej3;
                    SceneManager.LoadScene("TP02_EJ03_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej5;
                    SceneManager.LoadScene("TP03_EJ05_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej5:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej4;
                    SceneManager.LoadScene("TP03_EJ04_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej6;
                    SceneManager.LoadScene("TP05_EJ06_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej6:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej5;
                    SceneManager.LoadScene("TP03_EJ05_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej11;
                    SceneManager.LoadScene("TP06_EJ11_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej11:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej6;
                    SceneManager.LoadScene("TP05_EJ06_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej13;
                    SceneManager.LoadScene("TP07_EJ13_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej13:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej11;
                    SceneManager.LoadScene("TP06_EJ11_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej15;
                    SceneManager.LoadScene("TP08_EJ15_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej15:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej13;
                    SceneManager.LoadScene("TP07_EJ13_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentState = States.Ej17;
                    SceneManager.LoadScene("TP09_EJ17_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej17:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej15;
                    SceneManager.LoadScene("TP08_EJ15_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                   currentState = States.Ej18;
                   SceneManager.LoadScene("TP10_EJ18_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;

            case States.Ej18:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentState = States.Ej15;
                    SceneManager.LoadScene("TP09_EJ17_Scene");
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                   // currentState = States.Ej18;
                   // SceneManager.LoadScene("TP10_EJ18_Scene");
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    currentState = States.MainMenu;
                    SceneManager.LoadScene("MainMenu");
                }
                break;
        }
    }
    


}

