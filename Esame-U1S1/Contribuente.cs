using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Esame_U1S1
{
    //creo classe contribuente con le proprietà richieste 
    internal class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public char Sesso { get; set; }
        public string ComuneResidenza { get; set; }

        public decimal RedditoAnnuale { get; set; }

        // creo costruttore con parametri per inizializzare le proprietà della classe 
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, decimal redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        // metodo senza parametri che calcola e ritorna l'imposta sul reddito
        public decimal CalcolaImposta()
        {
            decimal imposta = 0; // imposta da calcolare

            if (RedditoAnnuale <= 15000)
            {
                imposta = RedditoAnnuale * 23 / 100;
            }
            else if (RedditoAnnuale <= 28000)
            {
                imposta = 3450 + (RedditoAnnuale - 15000) * 27 / 100;
            }
            else if (RedditoAnnuale <= 55000)
            {
                imposta = 6960 + (RedditoAnnuale - 28000) * 38 / 100;
            }
            else if (RedditoAnnuale <= 75000)
            {
                imposta = 17220 + (RedditoAnnuale - 55000) * 41 / 100;
            }
            else if (RedditoAnnuale > 75000)
            {
                imposta = 25420 + (RedditoAnnuale - 75000) * 43 / 100;
            }
            return imposta;
        }
    }
}
