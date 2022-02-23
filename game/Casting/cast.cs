using Greed.Game.Casting;
using System.Collections.Generic;

namespace Greed.Game.Casting
{
    public class Cast
    {
        private Dictionary<string, List<Actor>> actors = new Dictionary<string, List<Actor>>();
        
        public Cast()
        {

        }
        public void AddActor(string group, Actor actor)
        {
            if (!actors.ContainsKey(group))
            {
                actors[group] = new List<Actor>();
            }

            if (!actors[group].Contains(actor))
            {
                actors[group].Add(actor);
            }

        }

        public List<Actor> GetActors(string groups)
        {
            List<Actor> results = new List<Actor>();
            if (actors.ContainsKey(groups))
            {
                results.AddRange(actors[groups]);
            }
            return results;
        }

        public List<Actor> GetAllActors()
        {   
            List<Actor> results = new List<Actor>();
            foreach (List<Actor> result in actors.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        public Actor GetFirstActor(string groups)
        {
            Actor result = null;
            if (actors.ContainsKey(groups))
            {
                if (actors[groups].Count > 0)
                {
                    result = actors[groups][0];
                }
            }
            return result;
        }

        public void RemoveActor(string groups, Actor actor)
        {
            if (actors.ContainsKey(groups))
            {
                actors[groups].Remove(actor);
            }

        }

    }
}