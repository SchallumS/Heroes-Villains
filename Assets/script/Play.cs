using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Play : MonoBehaviour
{

    [SerializeField] private GameObject playchoice;

    void Start()
    {
        playchoice.SetActive(false);
    }

    void Update()
    {
        
    }
    public void playGame ()
    {
        //SceneManager.LoadScene ("Game", LoadSceneMode.Single);
        playchoice.SetActive(true);

    }
}