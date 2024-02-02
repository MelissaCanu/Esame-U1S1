using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_U1S1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input dati contribuente

            Console.WriteLine("Inserisci i dati del contribuente");

            string nome = "";
            do
            {
                Console.WriteLine("Nome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("Inserire un valore");
                }
            } while (string.IsNullOrEmpty(nome)); // ciclo finché non si inserisce un nome corretto

           string cognome = "";
            do
            {
                Console.WriteLine("Cognome: ");
                cognome = Console.ReadLine();
                if (string.IsNullOrEmpty(cognome))
                {
                    Console.WriteLine("Inserire un valore");
                }
            } while (string.IsNullOrEmpty(cognome)); // ciclo finché non si inserisce un cognome corretto

            // data

            DateTime dataNascita = DateTime.MinValue;
            bool inputDataValido = false;

            do
            {
                Console.WriteLine("Data di nascita: (DD-MM-YYYY) ");
                string inputDataNascita = Console.ReadLine();

                try 
                {
                    dataNascita = DateTime.Parse(inputDataNascita);
                    inputDataValido = true;
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Formato data non corretto. Il formato corretto è DD-MM-YYYY");

                }

            } while (!inputDataValido); // ciclo finché non si inserisce una data corretta

            // codice fiscale

            string codiceFiscale = "";
            do
            {
                Console.WriteLine("Codice fiscale: ");
                codiceFiscale = Console.ReadLine().ToUpper();
                if (codiceFiscale.Length != 16)
                {
                    Console.WriteLine("Il codice fiscale deve essere lungo 16 caratteri");
                }
            } while (codiceFiscale.Length != 16); // ciclo finché non si inserisce un codice fiscale corretto

            // sesso

            char sesso = ' ';
            do
            {
                Console.WriteLine("Sesso: (f, m, x) ");
                sesso = char.Parse(Console.ReadLine());
                if (sesso != 'f' && sesso != 'm' && sesso != 'x')
                {
                    Console.WriteLine("Il sesso deve essere f, m o x");
                }
            } while (sesso != 'f' && sesso != 'm' && sesso != 'x'); // ciclo finché non si inserisce un sesso corretto

            // comune di residenza
            string comuneResidenza = "";
           do
            {
                Console.WriteLine("Comune di residenza: ");
                comuneResidenza = Console.ReadLine();
                if (string.IsNullOrEmpty(comuneResidenza))
                {
                    Console.WriteLine("Inserire un valore");
                }
                } while (string.IsNullOrEmpty(comuneResidenza)); // ciclo finché non si inserisce un comune di residenza corretto
            


            // reddito annuale
            Console.OutputEncoding = System.Text.Encoding.UTF8; 

            Console.WriteLine("Reddito annuale: ");
            Console.WriteLine("€ ");

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            decimal redditoAnnuale = 0;
            do
            {
                Console.WriteLine("Reddito annuale: ");
                string inputRedditoAnnuale = Console.ReadLine();
                if (string.IsNullOrEmpty(inputRedditoAnnuale))
                {
                    Console.WriteLine("Inserire un valore");
                }
                else if (!decimal.TryParse(inputRedditoAnnuale, out redditoAnnuale))
                {
                    Console.WriteLine("Il reddito annuale deve essere un numero");
                }
                } while (redditoAnnuale <= 0); // ciclo finché non si inserisce un reddito annuale corretto
            


            // istanzio oggetto contribuente

            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            // calcolo imposta richiamando il metodo CalcolaImposta della classe Contribuente e stampo il risultato

            decimal impostaDaPagare = contribuente.CalcolaImposta();

            // output imposta con menu 

            Console.WriteLine($"==================================================");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
            Console.WriteLine($"Nat* il: {contribuente.DataNascita.ToString("dd/MM/yyy")} ({contribuente.Sesso})");
            Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
            Console.WriteLine($"Codice fiscale: {contribuente.CodiceFiscale}");
            Console.OutputEncoding = System.Text.Encoding.UTF8; // per visualizzare il simbolo dell'euro
            Console.WriteLine($"Reddito dichiarato: {contribuente.RedditoAnnuale:C}");
            Console.WriteLine($"IMPOSTA DA VERSARE: {impostaDaPagare:C}");
            Console.WriteLine($"==================================================");

            Console.ReadLine();
        }
    }
}
