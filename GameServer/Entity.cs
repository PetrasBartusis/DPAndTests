

using GameServer.Models;
using System.Collections.Generic;
using GameServer.State;
using System;
/**
* @(#) Entity.cs
*/
namespace GameServer
{
	public class Entity
	{

        Random random;
        private string name;
        private int hitpoints;
        private int currentHitpoints;
        private int attack;
        private int defence;
        private int poisonResistance = 0;
        private int fireResistance = 0;
        private int stunResistance = 0;
        private int fearResistance = 0;
        private bool guardianAngel = true;
        private List<IState> states = new List<IState>();

        public string Name { get => name; protected set => name = value; }
        public int Hitpoints { get => hitpoints; protected set => hitpoints = value; }
        public int CurrentHitpoints { get => currentHitpoints; set => currentHitpoints = value; }
        public int Attack { get => attack; protected set => attack = value; }
        public int Defence { get => defence; protected set => defence = value; }

        public Entity( string n, int hp, int a, int d )
        {
            random = new Random();
            name = n;
            Hitpoints = hp;
            Attack = a;
            Defence = d;
            CurrentHitpoints = hp;
		}

        public bool AddState(IState state)
        {
            foreach(IState s in states)
            {
                if(s.GetType() == state.GetType())
                {
                    return false;
                }
            }
            states.Add(state);
            return true;
        }

        public int GetStatesCount()
        {
            return states.Count;
        }

        public bool hasState(IState state)
        {
            foreach(IState s in states)
            {
                if(s.StateType() == state.StateType())
                {
                    return true;
                }
            }
            return false;
        }

        public void EndTurn()
        {
            //Remove states
            foreach (IState state in states)
            {
                switch (state.StateType())
                {
                    case StateType.BURN:
                        if (random.Next(0, 100) <= fireResistance)
                        {
                            states.Remove(state);
                        }
                        break;
                    case StateType.STUN:
                        if (random.Next(0, 100) <= stunResistance)
                        {
                            states.Remove(state);
                        }
                        break;
                    case StateType.FEAR:
                        if (random.Next(0, 100) <= fearResistance)
                        {
                            states.Remove(state);
                        }
                        break;
                    case StateType.POISON:
                        if (random.Next(0, 100) <= poisonResistance)
                        {
                            states.Remove(state);
                        }
                        break;
                }
            }

            foreach (IState state in states)
                state.Handle(this);
            if(CurrentHitpoints <= 0)
            {
                if (guardianAngel)
                {
                    guardianAngel = false;
                    CurrentHitpoints = Hitpoints;
                }else
                {
                    Die();
                }
            }
        }

        public void Die()
        {
            CurrentHitpoints = 0;
        }

        public override string ToString() => $" Name = {name}, HP = {CurrentHitpoints}, ATTACK = {Attack}, DEFENCE = {Defence} ";
    }
	
}
