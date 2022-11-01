using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorMultiplayer : Diretor
{
    private bool alguemMorto;
    private int pontosDesdeAMorte;
    private Jogador[] jogadores;
    private InterfaceCanvasInativo interfaceCanvasInativo;

    [SerializeField]
    private int pontosParaReviver = 2;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        jogadores = GameObject.FindObjectsOfType<Jogador>();
        interfaceCanvasInativo = GameObject.FindObjectOfType<InterfaceCanvasInativo>();
    }

    public void ReviverSePrecisar()
    {
        if (alguemMorto)
        {
            pontosDesdeAMorte++;

            interfaceCanvasInativo.AtualizarTexto(pontosParaReviver - pontosDesdeAMorte);
            if (pontosDesdeAMorte >= pontosParaReviver)
            {
                interfaceCanvasInativo.Sumir();
                ReviverJogadores();
            }
        }

    }

    public void AvisarQueAlguemMorreu(Camera camera)
    {
        if (alguemMorto)
        {
            FinalizarJogo();
            interfaceCanvasInativo.Sumir();
        }
        else
        {
            alguemMorto = true;
            pontosDesdeAMorte = 0;
            interfaceCanvasInativo.AtualizarTexto(pontosParaReviver);
            interfaceCanvasInativo.Mostrar(camera);
        }
    }

    private void ReviverJogadores()
    {
        alguemMorto = false;
        foreach (var jogador in jogadores)
        {
            jogador.Ativar();
        }
    }

    public override void ReiniciarJogo()
    {
        base.ReiniciarJogo();
        ReviverJogadores();
    }
}
