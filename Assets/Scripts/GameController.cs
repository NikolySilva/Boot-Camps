using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Transform[] casas; // array das casas do tabuleiro
    public Player player; // Referência ao objeto Player
    public GameObject painelPerguntas; // Painel de perguntas
    public GameObject painelFinalizou; // painel da linha de chegada
    public TMP_Text textoPergunta; // Texto da pergunta
    public TMP_Text botao1Texto; // Texto da opção 1
    public TMP_Text botao2Texto; // Texto da opção 2
    public GameObject painelErro; //Painel de erro
    public TMP_Text indicaErro; //texto de erro
    public TMP_Text volteUmaCasa; //texto volte 1 casa

    public Pergunta[] perguntas; // Array de perguntas
    private int indicePergunta = 0;

    IEnumerator Start()
    {
        //ativa opainel de perguntas após 2 segundo do incio do jogo
        yield return new WaitForSeconds(2);
        ExibirPergunta();
    }

    void ExibirPergunta()
    {
        // Exibe o painel de perguntas com a pergunta e alternativas atuais
        painelPerguntas.SetActive(true);
        Pergunta perguntaAtual = perguntas[indicePergunta];
        textoPergunta.text = perguntaAtual.pergunta;
        botao1Texto.text = perguntaAtual.opcao1;
        botao2Texto.text = perguntaAtual.opcao2;
    }

    public void Opcao1()
    {
        VerificarResposta(perguntas[indicePergunta].respostaCorreta == 1);
    }
    public void Opcao2()
    {
        VerificarResposta(perguntas[indicePergunta].respostaCorreta == 2);
    }

    void VerificarResposta(bool correta)
    {
        //desabilita o painel de perguntas
        painelPerguntas.SetActive(false);

        if (correta)
        {
            int passos = Random.Range(3, 7); // Sorteia um número de 3 a 6
            Debug.Log("O jogador anda " + passos);
            StartCoroutine(MoverJogador(passos));
        }
        else
        {
            if (player.IndiceAtual() == 0)
            {
                //teste - Quero que exiba apenas que o jogador errou
                StartCoroutine(ExibirErroERetroceder());
                Debug.Log("Player está na posição inicial e não pode retroceder");
                
            }
            else
            {
                StartCoroutine(ExibirErroERetroceder());
            }
        }
    }

    IEnumerator ExibirErroERetroceder()
    {
        painelErro.SetActive(true);

        if (player.IndiceAtual() == 0)
        {
            volteUmaCasa.gameObject.SetActive(false);
            StartCoroutine(MoverJogador(0));
        }
        else
        {
            volteUmaCasa.gameObject.SetActive(true);
            StartCoroutine(MoverJogador(-1));
        }

        yield return new WaitForSeconds(1);

        painelErro.SetActive(false);


        //ProximaPergunta(); // Avança para a próxima pergunta sem mover o peão

        //Quero que nessa linha um painel de erro apareça
        //painelErro.SetActive(true);
        //yield return new WaitForSeconds(2);
        //painelErro.SetActive(false);
        //Debug.Log("O jogador retrocede 1 casa");
        //StartCoroutine(MoverJogador(-1));
    }

    IEnumerator MoverJogador(int passos)
    {
        player.Mover(passos);
        yield return new WaitUntil(() => !player.IsMoving);

        // Verifica se o jogo terminou
        if (player.IndiceAtual() == casas.Length - 1)
        {
            Debug.Log("Parabéns, você alcançou a última casa!");
            painelFinalizou.SetActive(true);
            painelPerguntas.SetActive(false); //Esconde o painel
        }
        else
        {
            yield return new WaitForSeconds(2);
            ProximaPergunta(); // Carrega a próxima pergunta
        }
    }

    void ProximaPergunta()
    {
        // Linha pronta, não mexa nela
        indicePergunta = (indicePergunta + 1) % perguntas.Length; // Avança para a próxima pergunta
        ExibirPergunta();
    }
}
