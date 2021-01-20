using System;
using System.Collections.Generic;
using System.Text;

namespace Verkeer
{
    public class Voertuig
    {
        private string _soort;
        private string _naam;
        private int _wielen;
        private double _posX;
        private double _posY;
        private double _oudX;
        private double _oudY;
        private double _hoek;
        private int _deuk;
        private int _beurten;
        private double TOLERANCE = 0.01;

        public Voertuig(string soort, string naam, int wielen, double posX, double posY)
        {
            _soort = soort;
            _naam = naam;
            _wielen = wielen;
            _posX = posX;
            _posY = posY;
        }

        public string Naam
        {
            get { return _naam; }
        }
        public string Soort
        {
            get { return _soort; }
        }

        private double Radians(double hoek)
        {
            return (Math.PI / 180) * hoek;
        }

        public void Beurt(float afstand)
        {
            _beurten++;
            _oudX = _posX;
            _oudY = _posY;
            if (Math.Abs(_hoek) > TOLERANCE && Math.Abs(_hoek - 180.0) > TOLERANCE)
            {
                var x = Math.Sin(Radians(_hoek));
                _posX += Math.Round(afstand * x,2);
            }
            if (Math.Abs(_hoek - 90.0) > TOLERANCE && Math.Abs(_hoek - 270.0) > TOLERANCE)
            {
                var y = Math.Cos(Radians(_hoek));
                _posY += Math.Round(afstand * y, 2);
            }
        }

        public int Beurten
        {
            get { return _beurten;  }
            set { _beurten = value;  }
        }

        public double PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public double PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public double OudX
        {
            get { return _oudX; }
        }
        public double OudY
        {
            get { return _oudY; }
        }
        public double Hoek
        {
            get { return _hoek;}
            set { _hoek = value; }
        }
        public void Draai(double graden)
        {
            _hoek += graden;
            while (_hoek >= 360.0) _hoek -= 360.0;
            while (_hoek < 0.0) _hoek += 360.0;
        }
        public int Wielen
        {
            get { return _wielen; }
        }
        public int Deuk()
        {
            return _deuk;
        }
        public void Deuk(int value)
        {
            _deuk += value; 
        }
        public string Botsing(List<Voertuig> anderen, Boolean andereOok)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"==>{_naam} tegen ");
            var telling = 0;
            foreach (var item in anderen)
            {
                if (_naam != item.Naam)
                {
                    if (Math.Abs(_posX - item.PosX) < TOLERANCE && Math.Abs(_posY - item.PosY) < TOLERANCE)
                    {
                        sb.Append(item.Naam);
                        sb.Append(" ");
                        _deuk++;
                        if (andereOok)
                        {
                            item.Deuk(1);
                            telling += 2;
                        }
                        else
                            telling++;
                    }
                }
            }
            if (telling == 0)
            {
                return ($"{_naam} schade vrij:0");
            }
            else
            {
                sb.Append("<==:");
                sb.Append(telling);
                return sb.ToString();
            }

            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Pos: ");
            sb.Append(_posX.ToString("0.00"));
            sb.Append(", ");
            sb.Append(_posY.ToString("0.00"));
            sb.Append(", hoek: ");
            sb.Append(_hoek.ToString("0.00"));
            sb.Append(", ");
            sb.Append(_deuk.ToString());
            return sb.ToString();

        }
    }


}
