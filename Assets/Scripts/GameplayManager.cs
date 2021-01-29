using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    #region variable
    public static GameplayManager Instance;

    public GameObject player;
    //public GameObject boss;
    public float Score = 0;
    public GameObject panelGameOver;
    public GameObject panelWin;
    public GameObject Life3;
    public GameObject Life2;
    public GameObject Life1;
    public GameObject BulletG;
    public GameObject Camera;
    #endregion


    #region Awake
    void Awake()
    {
        if (Instance == null)
        { Instance = this; }
        else if (Instance != null)
        { Destroy(gameObject); }
    }
    #endregion


    #region Update
    public void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.X))
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }

        if(Score<1000)
        {
            BulletG.SetActive(false);
        }

        if (Score >= 1000)
        {
            BulletG.SetActive(true);
            if (Input.GetKey("g"))
            {
                Instantiate(player.GetComponent<Player>().bulletG, player.GetComponent<Player>().pointfire2.position, player.GetComponent<Player>().pointfire2.rotation);
                Score = 0;
            }
        }
        /*if (boss.GetComponent<Boss>().healthPts <= 0)
        {
            ShowWin();
        }*/
    }
    #endregion

    #region function
   

    public void ShowLife3()
    {
        Life3.SetActive(true);
        Life2.SetActive(false);
        Life1.SetActive(false);
    }

    public void ShowLife2()
    {
        Life3.SetActive(false);
        Life2.SetActive(true);
        Life1.SetActive(false);
    }

    public void ShowLife1()
    {
        Life3.SetActive(false);
        Life2.SetActive(false);
        Life1.SetActive(true);
    }

    public void ShowGameOver()
    {
        panelGameOver.SetActive(true);
        Camera.SetActive(true);
    }

    public void ShowWin()
    {
        panelWin.SetActive(true);
    }

    public void OnClick_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClick_Continue()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene(1);
    }


    public void OnClick_Retry2()
    {
        SceneManager.LoadScene(2);
    }

    #endregion
}
