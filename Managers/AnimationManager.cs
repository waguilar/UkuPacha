using Microsoft.Xna.Framework;
using System.Collections.Generic;
using UkuPacha.Models;

namespace UkuPacha.Managers
{
    public class AnimationManager
    {
        private readonly Dictionary<object, Animation> animDictionary = new();
        private object lastKey;

        public void AddAnimation(object key, Animation animation)
        {
            animDictionary.Add(key, animation);
            lastKey ??= key;
        }

        public void Update(object key)
        {
            if (animDictionary.ContainsKey(key))
            {
                animDictionary[key].Start();
                animDictionary[key].Update();
                lastKey = key;
            }
            else
            {
                animDictionary[lastKey].Stop();
                animDictionary[lastKey].Reset();
            }
        }

        public void Draw(Vector2 position)
        {
            animDictionary[lastKey].Draw(position);
        }
    }
}