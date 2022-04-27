
//bindestreg står det rigtige sted

//Første 6 tegn er tal

//Sidste 4 er tal

//Tjek den samlet længde

//6 første taler en gyldig dato


using System.Text.RegularExpressions;
using System.Globalization;

namespace CPR_Opgave
{
    internal class Program
    {
        static internal void Main(string[] args)
        {
            //hardcode bindestreg
            bool pass;
            do
            {
                string cprnr;
                string[] cpr;
                do
                {
                    Console.Write("Indtast CPR-Nummer(ddMMyy-xxxx): ");
                    cprnr = Console.ReadLine();
                    cpr = cprnr.Split("-");

                } while (cprnr == "" || cpr[0].Length != 6 || cpr[1].Length != 4);

                pass = Pass(cpr, cprnr);
                if (pass)
                {
                    Console.WriteLine("Godkendt");
                }
                else
                {
                    Console.WriteLine("Forkert");
                }

            } while (!pass);
        }
        static internal bool Pass(string[] cpr, string cprnr)
        {
            if (IsLength(cprnr) & IsNotNumbers(cpr[0]) & IsNotNumbers(cpr[1]) & Bindestreg(cprnr) & IsDate(cpr[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static internal bool IsNotNumbers(string cprnr)
        {
            Regex check = new Regex(@"\D");
            Match match = check.Match(cprnr);

            if (match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static internal bool IsDate(string cprnr)
        {
            DateTime result;
            if (!DateTime.TryParseExact(cprnr, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result))
            {
                Console.WriteLine("Ikke Korrekt dato");
                return false;
            }
            else
            {
                Console.WriteLine("Korrekt Dato!");
                return true;
            }
        }
        static internal bool IsLength(string cprnr)
        {
            if (cprnr.Length == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static internal bool Bindestreg(string cprnr)
        {
            char[] cpr = cprnr.ToCharArray();
            if (cpr[6] == '-')
            {
                return true;
            }
            else
                return false;
        }
    }
}