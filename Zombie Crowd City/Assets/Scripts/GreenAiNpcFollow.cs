using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenAiNpcFollow : MonoBehaviour
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
            GreenAiScripts.Instance.NumberScore++;

            GreenAiScripts.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            Destroy(other.gameObject);

            GreenAiScripts.Instance.citizenFollowGreenPlayer();
        }


        if (other.tag == "OrangeTeam")
        {
            GreenAiScripts.Instance.NumberScore++;

            OrangeAIScripts.Instance.NumberScore--;

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore--.ToString();

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            GreenAiScripts.Instance.citizenFollowGreenPlayer();
        }

        if (other.tag == "BlueTeam")
        {
            GreenAiScripts.Instance.NumberScore++;

            BlueAIScripts.Instance.NumberScore--;

            if (BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore--.ToString();

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            GreenAiScripts.Instance.citizenFollowGreenPlayer();
        }

        if (other.tag == "YellowTeam")
        {
            GreenAiScripts.Instance.NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            GreenAiScripts.Instance.citizenFollowGreenPlayer();
        }

        

        if (other.tag == "Bot Player")
        {
            GreenAiScripts.Instance.NumberScore++;

            PlayerController.Instance.NumberScore--;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore--.ToString();

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            GreenAiScripts.Instance.citizenFollowGreenPlayer();
        }
    }
}
