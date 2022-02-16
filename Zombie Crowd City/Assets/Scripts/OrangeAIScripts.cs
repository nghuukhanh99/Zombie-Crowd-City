using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrangeAIScripts : MonoBehaviour
{
    public static OrangeAIScripts Instance;

    public GameObject citizenFollow;

    public GameObject orangePlayerPos;

    public GameObject spawnFollow;

    public Text Score;

    public int NumberScore;

    public int ScoreAfterCollision;

    public GameObject OrangeTeamAI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        NumberScore = 1;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Citizen")
        {
            NumberScore++;

            OrangeTeamAI.gameObject.SetActive(true);

            Score.text = NumberScore.ToString();

            Destroy(other.gameObject);

            citizenFollowOrangePlayer();
        }

        if (other.tag == "GreenTeam")
        {
            NumberScore++;

            GreenAiScripts.Instance.NumberScore--;

            GreenAiScripts.Instance.Score.text = GreenAiScripts.Instance.NumberScore--.ToString();

            if (GreenAiScripts.Instance.NumberScore <= 0)
            {
                GreenAiScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowOrangePlayer();
        }

        if (other.tag == "YellowTeam")
        {
            NumberScore++;

            YellowAIScripts.Instance.NumberScore--;

            YellowAIScripts.Instance.Score.text = YellowAIScripts.Instance.NumberScore--.ToString();

            if (YellowAIScripts.Instance.NumberScore <= 0)
            {
                YellowAIScripts.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowOrangePlayer();
        }

        if (other.tag == "Bot Player")
        {
            NumberScore++;

            PlayerController.Instance.NumberScore--;

            PlayerController.Instance.Score.text = PlayerController.Instance.NumberScore--.ToString();

            if (PlayerController.Instance.NumberScore <= 0)
            {
                PlayerController.Instance.NumberScore = 0;
            }

            Score.text = NumberScore.ToString();

            other.gameObject.SetActive(false);

            citizenFollowOrangePlayer();
        }
    }

    public void citizenFollowOrangePlayer()
    {

        Vector3 spawnFollowPos = new Vector3(spawnFollow.transform.position.x, spawnFollow.transform.position.y, spawnFollow.transform.position.z);

        GameObject NpcFollowPlayer = Instantiate(citizenFollow, spawnFollowPos, Quaternion.identity);

    }
}
