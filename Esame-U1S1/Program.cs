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

            Console.WriteLine("Data di nascita: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Codice fiscale: ");
            string codiceFiscale = Console.ReadLine();

            Console.WriteLine("Sesso: ");
            char sesso = char.Parse(Console.ReadLine());

            Console.WriteLine("Comune di residenza: ");
            string comuneResidenza = Console.ReadLine();

            Console.WriteLine("Reddito annuale: ");
            decimal redditoAnnuale = decimal.Parse(Console.ReadLine());

            // istanzio oggetto contribuente

            Contribuente contribuente = new Contribuente(nome, cognome, dateTime, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            // calcolo imposta richiamando il metodo CalcolaImposta della classe Contribuente e stampo il risultato

            decimal impostaDaPagare = contribuente.CalcolaImposta();


        }
    }
}
