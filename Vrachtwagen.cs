using System.Text;

namespace Verkeer
{
    public class Vrachtwagen: Auto
    {
        private int _last;
        public Vrachtwagen(string naam, int wielen, double posX, double posY, int deuren, int cc, int last) :
            base ("Vrachtwagen",naam, wielen, posX, posY, deuren, cc)
        {
            _last = last;
        }
        public int Last
        {
            get { return _last; }
            set { _last = value; }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{base.ToString()}, laadvermogen {Last}.");
            return sb.ToString();
        }
    }
}
