using UkuPacha.Models;

namespace UkuPacha.Managers
{
    public class GameManager
    {
        private Character _character;

        public void Init()
        {
            _character = new(new(300, 300));
        }

        public void Update()
        {
            InputManager.Update();
            _character.Update();
        }

        public void Draw()
        {
            _character.Draw();
        }
    }
}