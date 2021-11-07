using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine.SceneManagement;

    public class GameBehavior : MonoBehaviour
    {
        public bool showWinScreen = false;
        public bool showLoseScreen = false;

        public string labelText = "Hit all 4 goals to win!";
        public int goalNum = 4;

        private int _goalsCollected = 0;
        public int Goals
        {
            get { return _goalsCollected; }
            set {
            _goalsCollected = value; 
            Debug.LogFormat("Goals: {0}", _goalsCollected);
            if(_goalsCollected >= goalNum)
            {
                labelText = "You've hit all the goals!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Goal hit, only " + (goalNum -
                _goalsCollected) + " more to go!";
            }
                }
        }


        private int _playerHealth = 3;
        public int Health
        {
            get { return _playerHealth; }
            set {
            _playerHealth = value;
            Debug.LogFormat("Health: {0}", _playerHealth);
            if(_playerHealth == 0){
                showLoseScreen = true;
                Time.timeScale = 0f;
            }
            }
        }

        void OnGUI()
        {
            GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" +
            _playerHealth);
            
            GUI.Box(new Rect(20, 50, 150, 25), "Goals Hit: " +
            _goalsCollected);

            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -
            50, 300, 50), labelText);

            if (showWinScreen)
            {
                if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU WON!"))
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                }
            }

            if (showLoseScreen)
            {
                if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "YOU LOST :("))
                {
                    SceneManager.LoadScene(0);
                    Time.timeScale = 1.0f;
                }
            }


        }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
