using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    int m_honey;

    int m_score;

    public void AddHoney(int honey)
    {
        if (m_honey + honey <= 100)
        {
            m_honey += honey; 
        }
        else
        {
            m_honey = 100; 
        }
    }

    public int GetHoney()
    {
        return m_honey; 
    }

    public void AddScore(int scoreAdded)
    {
        m_score +=scoreAdded;
    }

    public int GetScore()
    {
        return m_score;
    }
}
