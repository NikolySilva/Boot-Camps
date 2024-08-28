using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Transform[] casas; // array das casas do tabuleiro
    public Player player; //Referência ao objeto Player
    public GameObject painelPerguntas; //Painel de perguntas
    public TMP_Text textoPergunta; //Texto da pergunta
    public TMP_Text botao1Texto; //texto da opção 1
    public TMP_Text botao2Texto; //texto da opção 2

    public Pergunta[] perguntas; //Array de perguntas
    private int indicePergunta = 0;

    IEnumerator Start()
    {
        if(casas == null || casas.Length == 0)
        {
            Debug.Log("O array casas não foi configurado corretamente");
        }
        else
        {
            yield return new WaitForSeconds(2);
            ExibirPergunta();
        }
        
    }


    void ExibirPergunta()
    {
        //Exibe o painel de perguntas com a pergunta atual
        painelPerguntas.SetActive(true);
        Pergunta perguntaAtual = perguntas[indicePergunta];
        textoPergunta.text = perguntaAtual.pergunta;
        botao1Texto.text = perguntaAtual.opcao1;
        botao2Texto.text = perguntaAtual.opcao2;
    }

    public void Opcao1()
    {
        VerificarResposta(perguntas[indicePergunta].respostaCorreta == 2);
    }
    public void Opcao2()
    {
        VerificarResposta(perguntas[indicePergunta].respostaCorreta == 1);
    }

    void VerificarResposta(bool correta)
    {
        if (correta)
        {
            int passos = Random.Range(1, 7); // Sorteia um número de 1 a 6
            Debug.Log("O jogador anda" + passos);
            player.MoverParaFrente(passos);
        }
        else
        {
            if(player.IndiceAtual() == 0)
            {
                Debug.Log("Player está na osição inicial e não pode retroceder");
            }
            else
            {
                player.MoverParaTras(1); //Move  player para tras
            }
        }

        //verifica se o jogo terminou
        if(player.IndiceAtual() == casas.Length - 1)
        {
            Debug.Log("Parabens você alcançou a última casa!");
            painelPerguntas.SetActive(false); // esconde o painel
        }
        else
        {
            ProximaPergunta(); //carrega proxima pergunta
        }
    }
    void ProximaPergunta()
    {
        indicePergunta = (indicePergunta + 1) % perguntas.Length; //avança para a próxima pergunta
        ExibirPergunta();
    }


    /*public Transform[] casas;
    public Player jogador;
    public GameObject painel;
    public Pergunta[] perguntas;
    public TMP_Text textoPerg;
    private int indicePerg = 0;

    public void Opcao1()
    {
        if (perguntas[indicePerg].resposta)
        {
            int passos = Random.Range(1, 6);
            jogador.MoverParaFrente(passos);

            Debug.Log("O jogador moveu " + passos + "passos");
        }

        ProximaPergunta();
        
    }

    public void Opcao2()
    {
        if (!perguntas[indicePerg].resposta)
        {
            jogador.MoverParaTras(1);
        }

        ProximaPergunta();
    }

    void ProximaPergunta()
    {
        indicePerg = (indicePerg + 1) % perguntas.Length;
        textoPerg.text = perguntas[indicePerg].pergunta;
    }




    // Start is called before the first frame update
    void Start()
    {
        textoPerg.text = perguntas[indicePerg].pergunta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
