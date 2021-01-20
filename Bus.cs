using System.Text;

namespace Verkeer
{
    public class Bus: Auto
    {
        private int _stoelen;
        public Bus(string naam, int wielen, double posX, double posY, int deuren, int cc, int stoelen) :
            base("Bus", naam, wielen, posX, posY, deuren, cc)
        {
            _stoelen = stoelen;
        }
            public int Stoelen
        {
            get { return _stoelen; }
            set { _stoelen = value; }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{base.ToString()} en heeft {Stoelen} stoelen");
            return sb.ToString();
        }

    }
}
