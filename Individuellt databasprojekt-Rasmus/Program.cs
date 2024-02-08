using Individuellt_databasprojekt_Rasmus.Data;
using Individuellt_databasprojekt_Rasmus.Models;
using System.Threading.Channels;

namespace Individuellt_databasprojekt_Rasmus
{
    internal class Program
    {

        static void Main(string[] args)
        {
            using SchoolDbContext db = new SchoolDbContext();

            bool program = true;
            while (program)
            {
                Console.Clear();
                Console.WriteLine("     Personal per Befattning");
                Console.WriteLine("     Information om alla elever");
                Console.WriteLine("     Visa aktiva kurser");
                Console.WriteLine("     Avsluta");

                int cursorPos = 0;
                Console.SetCursorPosition(0, cursorPos);
                Console.CursorVisible = false;
                Console.Write("-->");
                ConsoleKeyInfo navigator;

                do
                {
                    navigator = Console.ReadKey();
                    Console.SetCursorPosition(0, cursorPos);
                    Console.Write("   ");
                    if (navigator.Key == ConsoleKey.UpArrow && cursorPos > 0)
                    {
                        cursorPos--;
                    }

                    else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 3)
                    {
                        cursorPos++;
                    }

                    Console.SetCursorPosition(0, cursorPos);

                    Console.Write("-->");
                } while (navigator.Key != ConsoleKey.Enter);

                Console.Clear();

                switch (cursorPos)
                {
                    case 0://Personal per befattning
                        var Admin = db.Personals.Where(p => p.Befattning == "Admin");                        
                        Console.WriteLine("Alla med befattning Admin: ");
                        foreach (Personal a in Admin)
                        {
                            Console.WriteLine($"Namn : {a.FirstName} {a.LastName} - {a.Befattning}");
                        }

                        var IT = db.Personals.Where(p => p.Befattning == "IT-tekniker");
                        Console.WriteLine("\nAlla med befattning IT-tekniker: ");
                        foreach (Personal i in IT)
                        {
                            Console.WriteLine($"Namn : {i.FirstName} {i.LastName} - {i.Befattning}");
                        }

                        var Lärare = db.Personals.Where(p => p.Befattning == "Lärare");
                        Console.WriteLine("\nAlla med befattning Lärare: ");
                        foreach (Personal l in Lärare)
                        {
                            Console.WriteLine($"Namn : {l.FirstName} {l.LastName} - {l.Befattning}");
                        }

                        var Vaktmästare = db.Personals.Where(p => p.Befattning == "Vaktmästare");
                        Console.WriteLine("\nAlla med befattning Vaktmästare ");
                        foreach (Personal v in Vaktmästare)
                        {
                            Console.WriteLine($"Namn : {v.FirstName} {v.LastName} - {v.Befattning}");
                        }
                        Console.ReadKey();
                        break;
                    case 1://Information om alla elever
                        var Students = db.Students;
                        foreach(Student s in Students)
                        {
                            Console.WriteLine($"ID : {s.StudentId} - Namn : {s.FirstName} {s.LastName} - Klass : {s.Class} - Personnr : {s.PersonNr}");
                            Console.WriteLine(new string('-', 73));
                        }
                        Console.ReadKey();
                        break;
                    case 2://Visa aktiva kurser
                        var kur = db.Kurss;
                        Console.WriteLine("Aktiva kurser");
                        foreach (Kurs k in kur)
                        {
                            if (k.Active == true)
                            {
                                Console.WriteLine($"Kurs ID : {k.KursId} - {k.KursName}");
                            }
                        }
                        Console.WriteLine("\n\nInaktiva kurser");
                        foreach (Kurs k in kur)
                        {
                            if (k.Active == false)
                            {
                                Console.WriteLine($"Kurs ID : {k.KursId} - {k.KursName}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 3: //Avsluta programmet
                        Console.WriteLine("Avslutar programmet. . .");
                        Thread.Sleep(1000);
                        program = false;
                        break;
                }

            }
        }    
    }
}
