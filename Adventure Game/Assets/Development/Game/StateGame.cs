using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpace
{

    public class StateGame : GenericState
    {
        public void StateEntry()
        {
            Debug.Log("PLAY ENTRY");
        }

        public void StateUpdate()
        {
            if (Game.Instance.ScoreNow >= Game.Instance.ScoreToEnd)
            {
                Debug.Log("QUIT");
                Game.Instance.TransitionToState(GameState.End);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("QUIT");
                Application.Quit();
            }
        }

        public void StateExit()
        {
            Debug.Log("PLAY EXIT");
        }
    }
}
