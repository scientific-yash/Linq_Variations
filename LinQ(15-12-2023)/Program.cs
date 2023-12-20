using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace Linq_Practice
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] names = { "Anil", "Sharma", "Abdullah", "Imran", "Shiva", " Naresh" };

            //UsingLinq(names);
            //UsingLinqExtensions(names);

            //UsingLinqFunctions(names);
            //UsingAnonymousFunction(names);

            //LinqToXML();
            //LinqToXmlAddNode();
            LinqToXmlRemoveNode();

        }
        private static void UsingLinq(string[] names)
        {

            IEnumerable<string> query = from s in names
                                        where s.Length == 5
                                        orderby s
                                        select s.ToUpper();

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        private static void UsingLinqExtensions(string[] names)
        {
            IEnumerable<string> query = names.Where(s => s.Length == 5).OrderBy(s => s).Select(s => s.ToUpper());

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        public static void UsingLinqFunctions(string[] names)
        {
            Func<string, bool> filter = s => s.Length == 5;
            Func<string, string> extract = s => s;
            Func<string, string> project = s => s.ToUpper();

            IEnumerable<string> query = names.
                                        Where(filter).
                                        OrderBy(extract).
                                        Select(project);

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }

        }


        public static void UsingAnonymousFunction(string[] names)
        {
            Func<string, bool> filter = delegate (string s)
            {
                return s.Length == 5;
            };

            Func<string, string> extract = delegate (string s)
            {
                return s;
            };

            Func<string, string> project = delegate (string s)
            {
                return s.ToUpper();
            };

            IEnumerable<string> query = names.Where(filter).OrderBy(extract).Select(project);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }


        public static void LinqToXML()
        {
            string myXML = @"<Departments>
                                <Department>Accounts</Department>
                                <Department>Sales</Department>
                                <Department>Marketing</Department>
                                <Department>Pre-Sales</Department>
                            </Departments>";

            XDocument xdoc = XDocument.Parse(myXML);

            var result = xdoc.Element("Departments").Descendants();

            foreach (var item in result)
            {
                Console.WriteLine("Department Name -" + item.Value);
            }

            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }

        public static void LinqToXmlAddNode()
        {
            string myXML = @"<Departments>
                                <Department>Accounts</Department>
                                <Department>Sales</Department>
                                <Department>Marketing</Department>
                                <Department>Pre-Sales</Department>
                            </Departments>";

            XDocument xdoc = XDocument.Parse(myXML);

            xdoc.Element("Departments").Add(new XElement("Department", "Finance"));
            xdoc.Element("Departments").AddFirst(new XElement("Department", "Support"));

            var result = xdoc.Element("Departments").Descendants();

            foreach (var child in result)
            {
                Console.WriteLine("Department Name-" + child.Value);
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        public static void LinqToXmlRemoveNode()
        {
            string myXML = @"<Departments>
                        <Department>Accounts</Department>
                        <Department>Sales</Department>
                        <Department>Marketing</Department>
                        <Department>Pre-Sales</Department>
                    </Departments>";

            XDocument xdoc = XDocument.Parse(myXML);

            xdoc.Descendants().Where(s => s.Value == "Sales").Remove();

            var result = xdoc.Element("Departments").Descendants();
            foreach (var child in result)
            {
                Console.WriteLine("Department Name-" + child.Value);
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

    }
}