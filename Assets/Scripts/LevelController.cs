using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    AnglerFish _anglerFish;
    public string _nextLevelName;

    private void OnEnable()
    {
        _anglerFish = FindObjectOfType<AnglerFish>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!_anglerFish.gameObject.activeSelf)
        {
            GoBackToMainMenu();
        }
        if (_anglerFish.goalReached == true)
        {
            Debug.Log("_anglerFish.goalReached == true (from level conoller" );
            GoToNextLevel();
           // _anglerFish.goalReached = false; 
        }
        
    }

    void GoToNextLevel()
    {
        Debug.Log("Go To Next Level " + _nextLevelName);

        SceneManager.LoadScene(_nextLevelName);
        
    }
    public void GoBackToMainMenu()
    {
        Debug.Log("Go To Main Menu");
        SceneManager.LoadScene(0);
    }

}
