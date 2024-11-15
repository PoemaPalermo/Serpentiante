using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int[] mejorPuntajeEasy;
    public int[] mejorPuntajeNormal;
    public int[] mejorPuntajeHard;
    public string dificultad;
    public void Dificultad(string dificulty)
    {
        dificultad = dificulty;
        SceneManager.LoadScene("Game");
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
