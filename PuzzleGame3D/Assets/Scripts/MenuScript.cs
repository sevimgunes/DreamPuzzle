using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MenuPanel;

    public void Level1() //level 1 butonumuz için methodumuz
    {
        SceneManager.LoadScene(1);
        MenuPanel.SetActive(false);

    }
    public void Level2() //level 2 butonumuz için methodumuz
    {
        SceneManager.LoadScene(2);
        MenuPanel.SetActive(false);

    }
    public void Level3() //level 3 butonumuz için methodumuz
    {
        SceneManager.LoadScene(3);
        MenuPanel.SetActive(false);

    }
    public void QuitGame()
    {
        Application.Quit();
    }

   





}
