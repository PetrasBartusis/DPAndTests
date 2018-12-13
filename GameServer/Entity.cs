

using GameServer.Models;
using System.Collections.Generic;
using GameServer.State;
/**
* @(#) Entity.cs
*/
namespace GameServer
{
	public class Entity
	{
        private string name;
        private int hitpoints;
        private int currentHitpoints;
        private int attack;
        private int defence;
        private List<IState> states = new List<IState>();

        public string Name { get => name; private set => name = value; }
        public int Hitpoints { get => hitpoints; private set => hitpoints = value; }
        public int CurrentHitpoints { get => currentHitpoints; set => currentHitpoints = value; }
        public int Attack { get => attack; private set => attack = value; }
        public int Defence { get => defence; private set => defence = value; }

        public Entity( string n, int hp, int a, int d )
        {
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

        public void EndTurn()
        {
            foreach (IState state in states)
                state.Handle(this);
            if(CurrentHitpoints < 0)
            {
                Die();
            }
        }

        public void Die()
        {
            CurrentHitpoints = 0;
        }

        public override string ToString() => $" Name = {name}, HP = {CurrentHitpoints}, ATTACK = {Attack}, DEFENCE = {Defence} ";
    }
	
}
