using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTVProviderLibrary.Memento
{
    public class Caretaker
    {
        private Stack<SubscriptionMemento> subscriptionHistory = new Stack<SubscriptionMemento>();

        public void AddSubscriptionMemento(SubscriptionMemento memento)
        {
            subscriptionHistory.Push(memento);
        }

        public SubscriptionMemento UndoSubscriptionChanges()
        {
            if (subscriptionHistory.Count > 0)
            {
                return subscriptionHistory.Pop();
            }
            return null; // Nema više istorije
        }
    }
}
