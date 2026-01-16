using System.Collections.Generic;
using UnityEngine;
using System;
public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();
    private int scoreMultiplier = 1;
    public static event Action<int, int> OnScoreChange;

    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo;
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;
    }
    private void CheckForCombo(string tag, int bumperValue)
    {
        bumperTags.Add(tag);
        if (bumperTags.Count > 1)
        {
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;                          //verhoog de multiplier
            }
            else                                            //als ze niet gelijk zijn
            {
                scoreMultiplier = 1;                        //reset multiplier
                bumperTags.Clear();                         //leeg de lijst met tags
            }
        }                                                   //voeg score toe aan de ScoreManager
        ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);
        OnScoreChange?.Invoke(ScoreManager.Instance.score, scoreMultiplier);
    }
}