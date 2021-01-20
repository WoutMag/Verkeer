using System.Text;

namespace Verkeer
{
    public class Auto : Voertuig
    {
        private int _deuren;
        private int _cc;
        public Auto(string naam, int wielen, double posX, double posY, int deuren, int cc) :
            base("Auto", naam, wielen, posX, posY)
        {
            _deuren = deuren;
            _cc = cc;
        }

        protected Auto(string soort, string naam, int wielen, double posX, double posY, int deuren, int cc) :
            base(soort, naam, wielen, posX, posY)
        {
            _deuren = deuren;
            _cc = cc;
        }

        public int Deuren
        {
            get { return _deuren; }
            set { _deuren = value; }
        }
        public int CC
        {
            get { return _cc; }
            set { _cc = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.Naam);
            sb.Append(" (");
            sb.Append(base.Soort);
            sb.Append(") heeft ");
            sb.Append(Deuren);
            sb.Append(" deuren,  ");
            sb.Append(base.Wielen);
            sb.Append(" wielen en ");
            sb.Append(CC);
            sb.Append(" cc en is op ");
            sb.Append(base.ToString());

            return sb.ToString();
        }
    }
}
