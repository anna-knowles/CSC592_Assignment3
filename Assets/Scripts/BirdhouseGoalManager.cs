
using UnityEngine;
using TMPro;

public class BirdhouseGoalManager : MonoBehaviour
{
    public GameObject[] goals;
    private int currentGoal = 0;

    public TMP_Text instructionText;
    public string[] instructions;

    public ParticleSystem fireworks;

    void Start()
    {
        ShowCurrentGoal();
    }


    public void ShowCurrentGoal()
    {
        for (int i = 0; i < goals.Length; i++)
        {
            goals[i].SetActive(i == currentGoal);
        }

        if (currentGoal < instructions.Length)
        {
            instructionText.text = instructions[currentGoal];
        }
        else
        {
            instructionText.text = "Birdhouse Complete!";
            fireworks.Play();
        }
    }


    public void AdvanceGoal()
    {
        currentGoal++;
        ShowCurrentGoal();
    }
}
