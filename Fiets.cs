using System.Text;

namespace Verkeer
{
    public class Fiets: Voertuig
    {
        private int _zadels;

        protected Fiets(string soort, string naam, int wielen, double posX, double posY, int zadels) :
            base(soort, naam, wielen, posX, posY)
        {
            _zadels = zadels;
        }
        public Fiets( string naam, int wielen, double posX, double posY, int zadels) :
            base("Fiets", naam, wielen, posX, posY)
        {
            _zadels = zadels;
        }

        public int Zadels
        {
            get => _zadels;
            set => _zadels = value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.Naam);
            sb.Append($"({base.Soort}) heeft {base.Wielen} wielen en ");
            sb.Append($"{Zadels} zadels en is op ");
            sb.Append(base.ToString());

            return sb.ToString();
        }
    }
}
