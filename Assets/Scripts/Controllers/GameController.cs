using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Model;
using System.Linq;

public class GameController : MonoBehaviour
{
    public Text CounterText;
    private int counter;
    public GameObject worm;
    List<Level> levels { get; set; }
    string currentLevelName { get; set; }
    public Text currentLevelNameText;
    public Text currentLevelTargetText;

    void Start()
    {

        counter = 0;
        Level levelFirst = new Level()
        {
            Id = 1,
            Name = "1",
            CountWorms = 2,
            WormHealth = 20,
        };
        Level levelSecond = new Level()
        {
            Id = 2,
            Name = "2",
            CountWorms = 5,
            WormHealth = 10,
        };
        Level levelThird = new Level()
        {
            Id = 3,
            Name = "3",
            CountWorms = 7,
            WormHealth = 5,
        };
        levels = new List<Level>();
        levels.Add(levelFirst);
        levels.Add(levelSecond);
        levels.Add(levelThird);

        currentLevelName = "1";

        currentLevelNameText.text = GetCurrentLevel().Name;
        currentLevelTargetText.text = GetCurrentLevel().CountWorms.ToString();


    }

    private Level GetCurrentLevel()
    {

        return levels.FirstOrDefault(x => x.Name == currentLevelName);
        
    }
    private Level GetNextLevel(int levelId) 
    {
        levelId++;
        return levels.FirstOrDefault(x => x.Id == levelId);
    }

    public void WormWasAte()
    {
        counter += 1;
        CounterText.text = counter.ToString();
        Spawn();

        if (CounterText.text == currentLevelTargetText.text)
        {
            var nextLevel = GetNextLevel(GetCurrentLevel().Id);
            currentLevelName = nextLevel.Name;
            currentLevelNameText.text = GetCurrentLevel().Name;
            currentLevelTargetText.text = GetCurrentLevel().CountWorms.ToString();
            counter = 0;
            CounterText.text = counter.ToString();

        }
    }
    public void Spawn()
    {
        Vector2 position = new Vector2(Random.Range(-11f, 31f), Random.Range(-3f, 3f));
        Instantiate(worm, position, Quaternion.identity);
    }

}
