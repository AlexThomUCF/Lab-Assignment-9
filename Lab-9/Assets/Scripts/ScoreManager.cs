using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    private List<IScoreObserver> observers = new List<IScoreObserver>();

    public void AddObserver(IScoreObserver observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void RemoveObserver(IScoreObserver observer)
    {
        if (observers.Contains(observer))
            observers.Remove(observer);
    }

    public void AddScore(int points)
    {
        score += points;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnScoreChanged(score);
        }
    }
}

