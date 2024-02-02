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

            // nome e cognome 

            string nome = "";
            do

            {
                Console.WriteLine("Nome: ");
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome)) // metodo statico per verificare che il nome non sia vuoto
                {
                    Console.WriteLine("Inserire un valore");
                }
            } while (string.IsNullOrEmpty(nome)); 

           string cognome = "";

            do
            {
                Console.WriteLine("Cognome: ");
                cognome = Console.ReadLine();
                if (string.IsNullOrEmpty(cognome)) // metodo statico per verificare che il cognome non sia vuoto
                {
                    Console.WriteLine("Inserire un valore");
                }
            } while (string.IsNullOrEmpty(cognome)); 

            // data

            DateTime dataNascita = DateTime.MinValue;
            bool inputDataValido = false;

            do
            {
                Console.WriteLine("Data di nascita: (DD-MM-YYYY) ");
                string inputDataNascita = Console.ReadLine();

                try 
                {
                    dataNascita = DateTime.Parse(inputDataNascita); // trasformo la stringa inserita in un oggetto DateTime
                    inputDataValido = true;
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Formato data non corretto. Il formato corretto è DD-MM-YYYY");

                }

            } while (!inputDataValido); 

            // codice fiscale

            string codiceFiscale = "";

            do
            {
                Console.WriteLine("Codice fiscale: ");
                codiceFiscale = Console.ReadLine().ToUpper(); // trasformo la stringa inserita in maiuscolo
                if (codiceFiscale.Length != 16)
                {
                    Console.WriteLine("Il codice fiscale deve essere lungo 16 caratteri");
                }
            } while (codiceFiscale.Length != 16); 

            // sesso

            char sesso = ' ';

            do
            {
                Console.WriteLine("Sesso: (f, m, x) ");
                string inputSesso = Console.ReadLine().ToLower(); // trasformo la stringa inserita in minuscolo

                if (string.IsNullOrEmpty(inputSesso)) // metodo statico per verificare che il sesso non sia vuoto
                {
                    Console.WriteLine("Inserire un valore");
                }
                else if (inputSesso != "f" && inputSesso != "m" && inputSesso != "x")
                {
                    Console.WriteLine("Il sesso deve essere f, m o x");
                }
                else
                {
                    sesso = inputSesso[0]; // prendo il primo carattere della stringa inserita 
                }

            } while (sesso != 'f' && sesso != 'm' && sesso != 'x'); 

            // comune di residenza

            string comuneResidenza = "";

           do
            {
                Console.WriteLine("Comune di residenza: ");
                comuneResidenza = Console.ReadLine();

                if (string.IsNullOrEmpty(comuneResidenza)) // metodo statico per verificare che il comune di residenza non sia vuoto
                {
                    Console.WriteLine("Inserire un valore");
                }
                } while (string.IsNullOrEmpty(comuneResidenza)); 
            


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

            // output imposta  

            Console.WriteLine($"==================================================");
            Console.WriteLine($"Contribuente: {contribuente.Nome} {contribuente.Cognome}");
            Console.WriteLine($"Nat* il: {contribuente.DataNascita.ToString("dd/MM/yyy")} ({contribuente.Sesso})");
            Console.WriteLine($"Residente in: {contribuente.ComuneResidenza}");
            Console.WriteLine($"Codice fiscale: {contribuente.CodiceFiscale}");
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine($"Reddito dichiarato: {contribuente.RedditoAnnuale:C}");
            Console.WriteLine($"IMPOSTA DA VERSARE: {impostaDaPagare:C}");
            Console.WriteLine($"==================================================");

            Console.ReadLine();
        }
    }
}
