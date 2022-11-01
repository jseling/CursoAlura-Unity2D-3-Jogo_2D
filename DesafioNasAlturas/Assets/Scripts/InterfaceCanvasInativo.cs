using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceCanvasInativo : MonoBehaviour
{
    [SerializeField]
    private GameObject fundo;

    [SerializeField]
    private Text texto;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mostrar(Camera camera)
    {
        fundo.SetActive(true);
        canvas.worldCamera = camera;
    }

    public void Sumir()
    {
        fundo.SetActive(false);
    }

    public void AtualizarTexto(int pontosParaReviver)
    {
        texto.text = pontosParaReviver.ToString();
    }
}
