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
            if(Input.GetButtonDown("Quit"))
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
