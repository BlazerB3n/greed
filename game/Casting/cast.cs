using Greed.Game.Casting;
using System.Collections.Generic;

namespace Greed.Game.Casting
{
    public class Cast
    {
        private Dictionary<string, List<Actor>> actors = new Dictionary<string, List<Actor>>();
        

        /// <summary>
        /// Constructs a new instance of Cast.
        /// </summary>
        public Cast()
        {

        }

        
        /// <summary>
        /// Adds the given actor to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to add.</param>
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

        /// <summary>
        /// Gets the actors in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actors.</returns>
        public List<Actor> GetActors(string groups)
        {
            List<Actor> results = new List<Actor>();
            if (actors.ContainsKey(groups))
            {
                results.AddRange(actors[groups]);
            }
            return results;
        }

        /// <summary>
        /// Gets all the actors in the cast.
        /// </summary>
        /// <returns>A list of all actors.</returns>
        public List<Actor> GetAllActors()
        {   
            List<Actor> results = new List<Actor>();
            foreach (List<Actor> result in actors.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        /// <summary>
        /// Gets the first actor in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The first actor.</returns>
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

        /// <summary>
        /// Removes the given actor from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to remove.</param>
        public void RemoveActor(string groups, Actor actor)
        {
            if (actors.ContainsKey(groups))
            {
                actors[groups].Remove(actor);
            }

        }

        /// <summary>
        /// adds or replaceses the given actorList to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actorList">The list to add.</param>
        public void AddActorList(string group, List<Actor> actorList)
        {
            actors.Add(group, actorList);
        }
        

    }
}