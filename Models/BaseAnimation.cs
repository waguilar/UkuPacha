using Microsoft.Xna.Framework;

namespace UkuPacha.Models
{
    public class BaseAnimation
    {
        protected bool active = true;

        public virtual void Stop()
        {
            active = false;
        }

        public virtual void Start()
        {
            active = true;
        }

        public virtual void Reset()
        {
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 pos)
        {

        }
    }
}
