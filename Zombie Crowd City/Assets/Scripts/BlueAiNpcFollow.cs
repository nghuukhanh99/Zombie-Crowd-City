using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueAiNpcFollow : MonoBehaviour
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
            BlueAIScripts.Instance.NumberScore++;

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore.ToString();

            Destroy(other.gameObject);

            BlueAIScripts.Instance.citizenFollowBluePlayer();
        }

        if (other.tag == "GreenTeam")
        {
            BlueAIScripts.Instance.NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            BlueAIScripts.Instance.citizenFollowBluePlayer();
        }

        if (other.tag == "OrangeTeam")
        {
            BlueAIScripts.Instance.NumberScore++;

            OrangeAIScripts.Instance.NumberScore--;

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore--.ToString();

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            BlueAIScripts.Instance.citizenFollowBluePlayer();
        }

        if (other.tag == "YellowTeam")
        {
            BlueAIScripts.Instance.NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            BlueAIScripts.Instance.citizenFollowBluePlayer();
        }

        

        if (other.tag == "Bot Player")
        {
            BlueAIScripts.Instance.NumberScore++;

            PlayerController.Instance.NumberScore--;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore--.ToString();

            if (BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            BlueAIScripts.Instance.citizenFollowBluePlayer();
        }

    }
}
