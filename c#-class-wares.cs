using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsArtikelliste
{
    class ClassArtikel
    {
        private string bezeichnung;
        private double preis;
        private int artnr;

        public ClassArtikel(string bez, double p, int nr) {
            this.bezeichnung = bez;
            this.preis = p;
            this.artnr = nr;
        }

        public string getBezeichnung() {
            return bezeichnung;
        }

        public void setBezeichnung(string bez) {
            bezeichnung = bez;
        }

        public double getPreis()
        {
            return preis;
        }

        public void setPreis(double pr)
        {
            preis = pr;
        }

        public int getArtNr()
        {
            return artnr;
        }

        public void setArtNr(int anr)
        {
            artnr = anr;
        }

    }
}
