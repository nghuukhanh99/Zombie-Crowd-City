using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YellowAINpcFollow : MonoBehaviour
{
    public Transform playerPos;

    UnityEngine.AI.NavMeshAgent agent;

    Animator anim;

    Rigidbody rb;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        agent.destination = playerPos.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Citizen")
        {
            YellowAIScripts.Instance.NumberScore++;


            YellowAIScripts.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            Destroy(other.gameObject);

            YellowAIScripts.Instance.citizenFollowYellowPlayer();
        }

        if (other.tag == "GreenTeam")
        {
            YellowAIScripts.Instance.NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            YellowAIScripts.Instance.citizenFollowYellowPlayer();
        }

        if (other.tag == "BlueTeam")
        {
            YellowAIScripts.Instance.NumberScore++;

            BlueAIScripts.Instance.NumberScore--;

            if (BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore--.ToString();

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            YellowAIScripts.Instance.citizenFollowYellowPlayer();
        }

        if (other.tag == "OrangeTeam")
        {
            YellowAIScripts.Instance.NumberScore++;

            OrangeAIScripts.Instance.NumberScore--;

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore--.ToString();

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            YellowAIScripts.Instance.citizenFollowYellowPlayer();
        }

        

        if (other.tag == "Bot Player")
        {
            YellowAIScripts.Instance.NumberScore++;

            PlayerController.Instance.NumberScore--;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore--.ToString();

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            YellowAIScripts.Instance.citizenFollowYellowPlayer();
        }
    }
}
