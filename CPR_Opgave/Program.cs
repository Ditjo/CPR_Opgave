
//bindestreg står det rigtige sted

//Første 6 tegn er tal

//Sidste 4 er tal

//Tjek den samlet længde

//6 første taler en gyldig dato

using System.Text.RegularExpressions;

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
                do {
                    Console.Write("Indtast CPR-Nummer(ddMMyy-xxxx): ");
                    cprnr = Console.ReadLine();
                }while (cprnr == "" || cprnr.Length != 11);

                string[] cpr = cprnr.Split("-");

                //bool length = IsLength(cprnr);
                //bool bind = Bindestreg(cprnr);
                //bool num = IsNotNumbers(cpr[0]);
                //bool num1 = IsNotNumbers(cpr[1]);

                //Console.WriteLine(bind);
                //Console.WriteLine(num);
                //Console.WriteLine(num1);
                //Console.WriteLine(length);

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
        //static internal bool IsDate(string cprnr)
        //{

        //}
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
            if(cpr[6] == '-')
            {
                return true;
            }
            else            
                return false;            
        }
        static internal bool Pass(string[] cpr, string cprnr)
        {
            if(IsLength(cprnr) & IsNotNumbers(cpr[0]) & IsNotNumbers(cpr[1]) & Bindestreg(cprnr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}