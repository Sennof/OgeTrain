using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Data/Question", order = 1)]

public class Question : ScriptableObject
{
    public string Proposal;

    public List<string> Answers = new(new string[4]);
}
