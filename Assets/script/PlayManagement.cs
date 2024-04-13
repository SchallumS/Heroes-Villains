using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayManagement : MonoBehaviour
{
    [SerializeField] GameObject[] button;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         button[0].SetActive(false);
        button[1].SetActive(false);
    }

    public void backManagement ()
    {
        button[0].SetActive(true);
        button[1].SetActive(true);
        button[2].SetActive(false);
    }

    public void J1J2 ()
    {
        PlayerPrefs.SetInt("mode", 1);
        SceneManager.LoadScene ("Game", LoadSceneMode.Single);
    }

    public void J1AI ()
    {
        PlayerPrefs.SetInt("mode", 2);
        SceneManager.LoadScene ("Game", LoadSceneMode.Single);
    }
}
