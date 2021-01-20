using System.Text;

namespace Verkeer
{
    public class Bromfiets : Fiets

    {
        private int _cc;
        public Bromfiets(string naam, int wielen, double posX, double posY, int zadels, int cc) :
            base ("Bromfiets", naam, wielen, posX, posY, zadels)
        {
            _cc = cc;
        }

        public int CC
        {
            get { return _cc; }
            set { _cc = value; }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{base.ToString()} heeft {CC} cc");

            return sb.ToString();
        }
    }

}
