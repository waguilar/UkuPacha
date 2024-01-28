using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UkuPacha.Managers
{
    public static class InputManager
    {
        private static Vector2 direction;
        public static Vector2 Direction => direction;
        public static bool Moving => direction != Vector2.Zero;
        public static bool Forward;
        public static bool Backwards;

        public static void Update()
        {
            //TODO: Refactor to consider other input, such as Joypad or Mouse
            direction = Vector2.Zero;
            Forward = Backwards = false;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.GetPressedKeyCount() > 0)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    Backwards = true;
                    direction.X--;
                }
                if (keyboardState.IsKeyDown(Keys.D)) 
                {
                    Forward = true;
                    direction.X++;
                }

                if (keyboardState.IsKeyDown(Keys.W)) direction.Y--;
                if (keyboardState.IsKeyDown(Keys.S)) direction.Y++;
            }
        }
    }
}
