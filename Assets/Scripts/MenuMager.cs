using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMager : MonoBehaviour
{
    public void CambiarDeEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
