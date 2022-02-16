using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NpcFollow : MonoBehaviour
{
    public Transform playerPos;

    NavMeshAgent agent;

    Animator anim;

    Rigidbody rb;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {

            anim.SetBool("isRunning", false);

        }

        agent.destination = playerPos.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Citizen")
        {
            PlayerController.Instance.NumberScore++;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            Destroy(other.gameObject);
            PlayerController.Instance.citizenFollowPlayer();
        }

        if (other.tag == "BlueTeam")
        {
            PlayerController.Instance.NumberScore++;

            BlueAIScripts.Instance.NumberScore--;

            if (BlueAIScripts.Instance.NumberScore <= 0)
            {
                BlueAIScripts.Instance.NumberScore = 0;
            }

            BlueAIScripts.Instance.Score.text = BlueAIScripts.Instance.NumberScore--.ToString();

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            PlayerController.Instance.citizenFollowPlayer();
        }

        if (other.tag == "GreenTeam")
        {
            PlayerController.Instance.NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            PlayerController.Instance.citizenFollowPlayer();
        }

        if (other.tag == "OrangeTeam")
        {
            PlayerController.Instance.NumberScore++;

            OrangeAIScripts.Instance.NumberScore--;

            if (OrangeAIScripts.Instance.NumberScore <= 0)
            {
                OrangeAIScripts.Instance.NumberScore = 0;
            }

            OrangeAIScripts.Instance.Score.text = OrangeAIScripts.Instance.NumberScore--.ToString();

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            PlayerController.Instance.citizenFollowPlayer();
        }

        if (other.tag == "YellowTeam")
        {
            PlayerController.Instance.NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore.ToString();

            other.gameObject.SetActive(false);

            PlayerController.Instance.citizenFollowPlayer();
        }
    }
}
