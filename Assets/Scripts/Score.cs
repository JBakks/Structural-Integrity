using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    Dictionary<string, int> score;
    public static Score instance;
    public Debugger debugger;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = new Dictionary<string, int>();
        Damage[] damages = Resources.LoadAll<Damage>("Damage");
        debugger.AddText("Damages Length: " + damages.Length);
        foreach (Damage damage in damages)
        {
            debugger.AddText("Damages: " + damage);
            score.Add(damage.name, 0);
            debugger.AddText("Error");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(Damage damage, int amount)
    {
        score[damage.name] += amount;
    }

    public int GetScore(Damage damage)
    {
        return score[damage.name];
    }

    public void IncreaseScore(Damage damage)
    {
        score[damage.name]++;
    }

    public void DecreaseScore(Damage damage)
    {
        score[damage.name]--;
    }

    public void SetScore(string damageName, int amount)
    {
        score[damageName] += amount;
    }

    public int GetScore(string damageName)
    {
        return score[damageName];
    }

    public void IncreaseScore(string damageName)
    {
        score[damageName]++;
    }

    public void DecreaseScore(string damageName)
    {
        score[damageName]--;
    }
}
