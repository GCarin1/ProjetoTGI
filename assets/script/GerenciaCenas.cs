using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciaCenas : MonoBehaviour
{
    public void TrocarCenaPC() {
         SceneManager.LoadScene("Kali");
    }
    public void TrocarCenaMenu() {
        SceneManager.LoadScene("menu");
    }
    public void TrocarCenaLogin() {
        SceneManager.LoadScene("login");
    }
    public void TrocarCenaRoom() {
        SceneManager.LoadScene("room");
    }
    public void TrocarCenaCreditos() {
        SceneManager.LoadScene("creditos");
    }
    public void TrocarCenaInfo() {
        SceneManager.LoadScene("info");
    }
}
