﻿using System;
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
        private static readonly int MILLISECONDS_PER_SECOND = 1000;
        private static readonly int UPDATES_PER_SECOND = 70;
        private int timeSpanMilliseconds = MILLISECONDS_PER_SECOND / UPDATES_PER_SECOND;


        public KeyboardListener()
        {
            KeyboardCurrentState = new KeyboardChangeState();
            Subscribers = new List<IInputSubscriber>();
        }

        public void Update(KeyboardState currentState, GameTime gameTime)
        {
            
            
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            KeyboardCurrentState.SetState(currentState);

            if (KeyboardCurrentState.HasChanged() && (int)elapsedTime >= TimeSpan.FromMilliseconds(10).TotalMilliseconds)
            {
                notifySubscribers(gameTime);
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
        public void notifySubscribers(GameTime gameTime)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.NotifyOfChange(KeyboardCurrentState, gameTime);
            }
        }
    
    }
}
