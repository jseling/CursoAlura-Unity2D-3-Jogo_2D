using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;

    [SerializeField]
    private float tempoParaGerarDificil;

    private float cronometro;

    [SerializeField]
    private GameObject obstaculoPrefab;

    private ControleDificuldade controleDificuldade;
    private bool parado;

    // Start is called before the first frame update
    void Awake()
    {
        cronometro = tempoParaGerarFacil;
    }

    private void Start()
    {
        controleDificuldade = GameObject.FindObjectOfType<ControleDificuldade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parado)
        {
            return;
        }

        cronometro -= Time.deltaTime;
        if(cronometro <= 0)
        {
            Instantiate(obstaculoPrefab, transform.position, Quaternion.identity);
            cronometro = Mathf.Lerp(tempoParaGerarFacil, tempoParaGerarDificil, controleDificuldade.Dificuldade);
        }
    }

    public void Parar()
    {
        parado = true;
    }

    public void Recomecar()
    {
        parado = false;
    }
}
