using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notify : MonoBehaviour
{
    private static Notify instance;
    public static Notify Instance
    {

        get
        {
            if (instance == null) instance = FindAnyObjectByType<Notify>();
            return instance;
        }
    }


    public GameObject panel;
    public TextMeshProUGUI txt_Message;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Show(string message)
    {
        txt_Message.text = $"<color=black> {message} </color>";
        panel.gameObject.SetActive(true);
    }
    public void ShowError(string message)
    {
        txt_Message.text = $"<color=red> {message} </color>";
        panel.gameObject.SetActive(true);
    }

}
