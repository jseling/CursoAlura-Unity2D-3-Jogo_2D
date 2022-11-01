using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Carrossel[] cenario;

    private GeradorDeObstaculos geradorDeObstaculos;

    private Aviao aviao;

    private bool estouMorto;
    // Start is called before the first frame update
    void Start()
    {
        cenario = GetComponentsInChildren<Carrossel>();
        geradorDeObstaculos = GetComponentInChildren<GeradorDeObstaculos>();
        aviao = GetComponentInChildren<Aviao>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desativar()
    {
        estouMorto = true;
        geradorDeObstaculos.Parar();
        foreach (var carrossel in cenario)
        {
            carrossel.enabled = false;
        }
    }

    public void Ativar()
    {
        if (estouMorto)
        {
            aviao.Reiniciar();
            geradorDeObstaculos.Recomecar();
            foreach (var carrossel in cenario)
            {
                carrossel.enabled = true;
            }
        }
        estouMorto = false;
    }
}
