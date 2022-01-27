using SmartTemplateProcessor;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Example 1 */
            string template = "Hello {{nome}}! How are you {{nome}}? Your e-mail address is: {{email.address}}?";

            object obj = new
            {
                nome = "JulioGold",
                email = new
                {
                    address = "julio.gold@gmail.com"
                }
            };

            Console.WriteLine(Processor.ProcessTemplate(template, obj));

            Console.WriteLine("");
            Console.WriteLine("");

            /* Example 2 */
            string template2 = "Hello {{company.nome}}! How are you {{company.nome}}? This is your {{company.email.type}} e-mail address {{company.email.address}}?";

            object obj2 = new
            {
                company = new
                {
                    nome = "JulioGold",
                    email = new
                    {
                        address = "julio.gold@gmail.com",
                        type = "Comercial"
                    }
                }
            };

            Console.WriteLine(Processor.ProcessTemplate(template2, obj2));

            Console.ReadKey();
        }
    }
}
