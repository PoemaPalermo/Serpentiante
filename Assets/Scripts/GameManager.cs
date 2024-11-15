using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //puntos
    public int[] mejorPuntajeEasy;
    public int[] mejorPuntajeNormal;
    public int[] mejorPuntajeHard;

    //dificultad
    bool elegidaDificultad;
    public string dificultad;
    private float gameFixedTimestepHard = 0.08f;
    private float gameFixedTimestepNormal = 0.2f;
    private float gameFixedTimestepEasy = 0.4f;
    public void Dificultad(string dificulty)
    {
        dificultad = dificulty;
        SceneManager.LoadScene("Game");
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game"&& !elegidaDificultad)
        {
            if (dificultad == "e")
            {
                Time.fixedDeltaTime = gameFixedTimestepEasy;
                Debug.Log("Fixed Timestep cambiado a: " + gameFixedTimestepEasy);
            }
            else if (dificultad == "n")
            {
                Time.fixedDeltaTime = gameFixedTimestepNormal;
                Debug.Log("Fixed Timestep cambiado a: " + gameFixedTimestepNormal);
            }
            else if(dificultad == "h")
            {
                Time.fixedDeltaTime = gameFixedTimestepHard;
                Debug.Log("Fixed Timestep cambiado a: " + gameFixedTimestepHard);
            }
            else
            {
                Debug.Log("Error de programación: no se eligio la dificultad");
            }
            elegidaDificultad = true;
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            elegidaDificultad = false;
        }
    }
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
}
