using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.ShopModule
{
    class Caretaker
    {
        private List<Memento> states = new List<Memento>();
        private int currentState = -1;

        public void AddState(Memento m)
        {
            if(states.Count > 0 && currentState < states.Count - 1)
            {
                states.RemoveRange(currentState, states.Count - currentState);
            }
            states.Add(m);
            currentState = states.Count - 1;
        }

        public Memento Undo()
        {
            return states[currentState--];
        }

        public Memento Redo()
        {
            return states[++currentState];
        }

        public bool CanUndo()
        {
            return currentState > -1;
        }

        public bool CanRedo()
        {
            return currentState < states.Count - 1;
        }

        public void Clear()
        {
            states = new List<Memento>();
            currentState = -1;
        }

    }
}
