﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayne.Lib.StateEngine;
using Wayne.Lib.StateEngine.Generic;

namespace Semaforo.States
{
    class Yellow: State<Form1>
    
    {


        protected override void Enter(StateEntry stateEntry, ref Transition transition)
        {
            base.Enter(stateEntry, ref transition);
            Main.turnOnYellow();
        }

        protected override void HandleEvent(StateEngineEvent stateEngineEvent, ref Transition transition)
        {
            base.HandleEvent(stateEngineEvent, ref transition);

            if (stateEngineEvent.Type.Equals(SemaforoEvent.buttonClick))
            {
                stateEngineEvent.Handled = true;
                transition = new Transition(this, SemaforoTransition.yellowToRed);
            }
            if (stateEngineEvent.Type.Equals(SemaforoEvent.resetButtonClick))
            {
                stateEngineEvent.Handled = true;
                transition = new Transition(this, SemaforoTransition.yellowToGreen);
            }
            if (stateEngineEvent.Type.Equals(SemaforoEvent.startBlinkEvent))
            {
                stateEngineEvent.Handled = true;
                transition = new Transition(this, SemaforoTransition.startBlinking);
            }

        }
        protected override void Exit()
        {
            Main.turnOffYellow();
            base.Exit();
        }

        
    }
}
