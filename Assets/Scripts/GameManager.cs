using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Guardado de datos
    public ExampleData data;
    public const string pathData = "DataTest";
    public const string nameFileData = "TestingExample";
    public int puntos;
    public int tamañoMaxListas = 5;

    //dificultad
    bool elegidaDificultad;
    public string dificultad;
    private float gameFixedTimestepHard = 0.08f;
    private float gameFixedTimestepNormal = 0.2f;
    private float gameFixedTimestepEasy = 0.4f;
    void Start()
    {
        var dataFound = SaveLoadSystemData.LoadData<ExampleData>(pathData, nameFileData);
        if (dataFound != null)
        {
            data = dataFound;
        }
        else
        {
            data = new ExampleData();
        }

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" && !elegidaDificultad)
        {
            if (dificultad == "e")
            {
                Time.fixedDeltaTime = gameFixedTimestepEasy;
            }
            else if (dificultad == "n")
            {
                Time.fixedDeltaTime = gameFixedTimestepNormal;
            }
            else if (dificultad == "h")
            {
                Time.fixedDeltaTime = gameFixedTimestepHard;
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

    public void Dificultad(string dificulty)
    {
        dificultad = dificulty;
        SceneManager.LoadScene("Game");
    }
    public void GuardarPuntaje(int puntaje)
    {
        puntos = puntaje;
        if (dificultad == "e")
        {
            data.mejoresPuntajeEasy.Add(puntaje);
            data.mejoresPuntajeEasy.Sort((a, b) => b.CompareTo(a));
            if (data.mejoresPuntajeEasy.Count > tamañoMaxListas)
            {
                data.mejoresPuntajeEasy = data.mejoresPuntajeEasy.GetRange(0, tamañoMaxListas);
            }
        }
        else if (dificultad == "n")
        {
            data.mejoresPuntajeNormal.Add(puntaje);
            data.mejoresPuntajeNormal.Sort((a, b) => b.CompareTo(a));
            if (data.mejoresPuntajeNormal.Count > tamañoMaxListas)
            {
                data.mejoresPuntajeNormal = data.mejoresPuntajeNormal.GetRange(0, tamañoMaxListas);
            }
        }
        else if (dificultad == "h")
        {
            data.mejoresPuntajeHard.Add(puntaje);
            data.mejoresPuntajeHard.Sort((a, b) => b.CompareTo(a));
            if (data.mejoresPuntajeHard.Count > tamañoMaxListas)
            {
                data.mejoresPuntajeHard = data.mejoresPuntajeHard.GetRange(0, tamañoMaxListas);
            }
        }
        SaveData();
    }
    public void SaveData()
    {
        SaveLoadSystemData.SaveData(data, pathData, nameFileData);
    }
    //Singleton
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
