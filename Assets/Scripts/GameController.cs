using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Transform[] casas;
    public Player jogador;
    public GameObject painel;
    public Pergunta[] perguntas;
    public TMP_Text textoPerg;
    private int indicePerg = 0;

    public void Opcao1()
    {
        if (perguntas[indicePerg].resposta)
        {

        }
        
    }

    public void Opcao2()
    {
        if (!perguntas[indicePerg].resposta)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textoPerg.text = perguntas[indicePerg].pergunta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
