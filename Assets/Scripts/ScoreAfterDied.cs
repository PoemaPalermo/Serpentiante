using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAfterDied : MonoBehaviour
{
    public Text txtMejorPuntaje;
    public Text txtUltimoPuntaje;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.dificultad == "e")
        {
            txtMejorPuntaje.text = GameManager.Instance.data.mejoresPuntajeEasy[0].ToString();
            txtUltimoPuntaje.text = GameManager.Instance.puntos.ToString();
        }
        else if (GameManager.Instance.dificultad == "n")
        {
            txtMejorPuntaje.text = GameManager.Instance.data.mejoresPuntajeNormal[0].ToString();
            txtUltimoPuntaje.text = GameManager.Instance.puntos.ToString();
        }
        else if (GameManager.Instance.dificultad == "h")
        {
            txtMejorPuntaje.text = GameManager.Instance.data.mejoresPuntajeHard[0].ToString();
            txtUltimoPuntaje.text = GameManager.Instance.puntos.ToString();
        }
    }
}