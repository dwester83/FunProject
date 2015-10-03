using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game_DX.Input
{
    class KeyboardListener
    {
        private KeyboardChangeState KeyboardCurrentState { get; set; }
        private List<IInputSubscriber> Subscribers { get; set; }
        private double elapsedTime = 0;

        public KeyboardListener()
        {
            KeyboardCurrentState = new KeyboardChangeState();
            Subscribers = new List<IInputSubscriber>();
        }

        public void Update(KeyboardState currentState, GameTime gameTime)
        {
            
            
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            KeyboardCurrentState.SetState(currentState);

            if (KeyboardCurrentState.HasChanged() && (int)elapsedTime >= TimeSpan.FromMilliseconds(1000).TotalMilliseconds)
            {
                notifySubscribers();
            }

            if (elapsedTime > 1000) { elapsedTime = 0; }
        }
        public void AddSubscriber(IInputSubscriber subscriber)
        {
            if(subscriber != null && !Subscribers.Contains(subscriber))
            {
                Subscribers.Add(subscriber);
            }
        }
        public void RemoveSubscriber(IInputSubscriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }
        public void notifySubscribers()
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.NotifyOfChange(KeyboardCurrentState);
            }
        }
    
    }
}
