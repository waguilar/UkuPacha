
namespace UkuPacha
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
            _character.Update();
        }

        public void Draw()
        {
            _character.Draw();
        }
    }
}
