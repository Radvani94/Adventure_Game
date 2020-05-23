using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace GameSpace
{
    public enum GameState {  Menu, Play, End };
    abstract public class GenericState : MonoBehaviour
    {
        public void StateEntry()
        {

        }

        public void StateUpdate()
        {
            Debug.Log("Wrong Update");
        }

        public void StateExit()
        {

        }
    }

    
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }
        public static StateMenu MenuInstance { get; private set; }
        public static StateGame GameInstance { get; private set; }
        public static StateEnd EndInstance { get; private set; }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            if (MenuInstance == null)
            {
                MenuInstance = new StateMenu();
            }
            if (GameInstance == null)
            {
                GameInstance = new StateGame();
            }
            if (EndInstance == null)
            {
                EndInstance = new StateEnd();
            }

        }


        public GameState CurrState;
        public GameObject screenFade;
        public int ScoreToEnd = 10;
        public int ScoreNow = 0;
        
        public GameState GetCurrState()
        {
            return CurrState;
        }

        public bool TransitionToState(GameState NewState)
        {  
            if (CurrState != NewState)
            {
                //StartCoroutine("FadeIn");
                switch (CurrState)
                {
                    case GameState.Menu:
                        MenuInstance.StateExit();
                        break;
                    case GameState.Play:
                        GameInstance.StateExit();
                        break;
                    case GameState.End:
                        EndInstance.StateExit();
                        break;
                }


                switch (NewState)
                {
                    case GameState.Menu:
                        MenuInstance.StateEntry();
                        break;
                    case GameState.Play:
                        SceneManager.LoadScene("Character Testing");
                        GameInstance.StateEntry();
                        break;
                    case GameState.End:
                        EndInstance.StateEntry();
                        break;
                }
                CurrState = NewState;
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator FadeIn()
        {

            while (screenFade.GetComponent<Image>().color.a >= 0)
            {
                screenFade.GetComponent<Image>().color -= new Color(0, 0, 0, .05f);
                Debug.Log(screenFade.GetComponent<Image>().color.a.ToString());

                yield return null;
            }
        }
        void Start()
        {
            //Initialize Game

            
            //screenFade = GameObject.FindGameObjectWithTag("Fader");
            TransitionToState(GameState.Menu);
        }

        // Update is called once per frame
        void Update()
        {
            switch (CurrState)
            {
                case GameState.Menu:
                    MenuInstance.StateUpdate();
                    break;
                case GameState.Play:
                    GameInstance.StateUpdate();
                    break;
                case GameState.End:
                    EndInstance.StateUpdate();
                    break;
            }
        }

        public void doPlayGame()
        {
            Debug.Log("Play Game");
            TransitionToState(GameState.Play);
        }
        public void doExitGame()
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }

}
