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

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Cognome: ");
            string cognome = Console.ReadLine();

            // gestisco controllo formato data

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

            //  gestisco controllo formato codice fiscale 

            string codiceFiscale = "";
            do
            {
                Console.WriteLine("Codice fiscale: ");
                codiceFiscale = Console.ReadLine();
                if (codiceFiscale.Length != 16)
                {
                    Console.WriteLine("Il codice fiscale deve essere lungo 16 caratteri");
                }
            } while (codiceFiscale.Length != 16); // ciclo finché non si inserisce un codice fiscale corretto

            // aggiungo controllo formato sesso

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
            Console.WriteLine("Comune di residenza: ");
            string comuneResidenza = Console.ReadLine();

            // reddito annuale
            Console.OutputEncoding = System.Text.Encoding.UTF8; // per visualizzare il simbolo dell'euro

            Console.WriteLine("Reddito annuale: ");
            Console.WriteLine("€ ");
            decimal redditoAnnuale = decimal.Parse(Console.ReadLine());

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
