﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpace
{

    public class StateEnd : GenericState
    {
        public void StateEntry()
        {
            Debug.Log("END ENTRY");
            Debug.Log("QUIT");
            Application.Quit();
        }

        public void StateUpdate()
        {
            //Debug.Log("MENU ENTRY");
        }

        public void StateExit()
        {
            Debug.Log("END EXIT");
        }
    }
}
