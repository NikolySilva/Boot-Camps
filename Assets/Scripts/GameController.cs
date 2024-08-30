using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Transform[] casas; // array das casas do tabuleiro
    public Player player; // Refer�ncia ao objeto Player
    public GameObject painelPerguntas; // Painel de perguntas
    public TMP_Text textoPergunta; // Texto da pergunta
    public TMP_Text botao1Texto; // Texto da op��o 1
    public TMP_Text botao2Texto; // Texto da op��o 2
    public GameObject painelErro;
    public TMP_Text indicaErro;
    public TMP_Text volteUmaCasa;

    public Pergunta[] perguntas; // Array de perguntas
    private int indicePergunta = 0;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        ExibirPergunta();
    }

    void ExibirPergunta()
    {
        // Exibe o painel de perguntas com a pergunta atual
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
        painelPerguntas.SetActive(false);

        if (correta)
        {
            int passos = Random.Range(3, 8); // Sorteia um n�mero de 3 a 8
            Debug.Log("O jogador anda " + passos);
            StartCoroutine(MoverJogador(passos));
        }
        else
        {
            if (player.IndiceAtual() == 0)
            {
                Debug.Log("Player est� na posi��o inicial e n�o pode retroceder");
                ProximaPergunta(); // Avan�a para a pr�xima pergunta sem mover o pe�o
            }
            else
            {
                StartCoroutine(ExibirErroERetroceder());
            }
        }
    }

    IEnumerator ExibirErroERetroceder()
    {
        //Quero que nessa linha um painel de erro apare�a
        painelErro.SetActive(true);
        yield return new WaitForSeconds(2);
        painelErro.SetActive(false);
        Debug.Log("O jogador retrocede 1 casa");
        StartCoroutine(MoverJogador(-1));
    }

    IEnumerator MoverJogador(int passos)
    {
        player.Mover(passos);
        yield return new WaitUntil(() => !player.IsMoving);

        // Verifica se o jogo terminou
        if (player.IndiceAtual() == casas.Length - 1)
        {
            Debug.Log("Parab�ns, voc� alcan�ou a �ltima casa!");
            painelPerguntas.SetActive(false); //Esconde o painel
        }
        else
        {
            ProximaPergunta(); // Carrega a pr�xima pergunta
        }
    }

    void ProximaPergunta()
    {
        // Linha pronta, n�o mexa nela
        indicePergunta = (indicePergunta + 1) % perguntas.Length; // Avan�a para a pr�xima pergunta
        ExibirPergunta();
    }
}
