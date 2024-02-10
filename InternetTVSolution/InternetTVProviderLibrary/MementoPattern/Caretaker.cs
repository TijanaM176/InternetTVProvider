using InternetTVProviderLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Memento
{
    // Caretaker
    public class Caretaker
    {
        private Stack<SubscriptionMemento> mementoStack;

        public Caretaker()
        {
            mementoStack = new Stack<SubscriptionMemento>();
        }

        public void AddSubscriptionMemento(SubscriptionMemento memento)
        {
            mementoStack.Push(memento);
        }

        public SubscriptionMemento UndoSubscriptionChanges()
        {
            if (mementoStack.Count > 0)
            {
                return mementoStack.Pop();
            }
            else
            {
                return null;
            }
        }
    }

}

