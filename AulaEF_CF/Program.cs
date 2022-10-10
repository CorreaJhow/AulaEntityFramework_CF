using System;
using AulaEF_CF.Context;
using AulaEF_CF.Models;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace AulaEF_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PersonContext())
            {
                #region INSERE DADOS
                context.Persons.Add(new Person() { Name = "Felipe", Phone = "123" });

                Person p = new Person();

                p.Name = "Baratao";
                p.Mail = "baratox@raid.com.br";
                p.Phone = "321";
                p.Mobile = "999";

                context.Persons.Add(p);
                context.SaveChanges();
                #endregion

                #region LISTA TODOS
                Console.WriteLine("### SelectAll ###");
                Console.WriteLine("-----------------");
                var persons = new PersonContext().Persons.ToList();
                foreach (var item in persons)
                {
                    Console.WriteLine(item.ToString());
                }
                #endregion

                #region LISTA UNICO
                Console.WriteLine("### Select One ###");
                Console.WriteLine("--------------");
                Console.WriteLine("Insira um nome: ");
                string n = Console.ReadLine();
                //Person xpto = new PersonContext().Persons.Find(args[0]);
                Person find = new PersonContext().Persons.FirstOrDefault(f => f.Name == n);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("[Pressione p/ Prosseguir]");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Registro não encontrado");
                    Console.WriteLine("[Pressione p/ Prosseguir]");
                    Console.ReadKey();
                }
                #endregion

                #region ATUALIZAR
                Console.WriteLine("### Atualizar ###");
                Console.WriteLine("--------------");
                find.Mobile = "UpdateSucess";
                context.Entry(find).State = EntityState.Modified;
                context.Persons.AddOrUpdate(find);
                context.SaveChanges();
                Console.WriteLine(find.ToString());
                Console.WriteLine("[Pressione p/ Prosseguir]");
                Console.ReadKey();
                #endregion

                #region REMOVE
                Console.WriteLine("### Remove ###");
                Console.WriteLine("--------------");
                context.Entry(find).State = EntityState.Deleted;
                context.Persons.Remove(find);
                context.SaveChanges();
                Console.WriteLine("Removido com sucesso!!!");
                Console.WriteLine("[Pressione p/ Prosseguir]");
                Console.ReadKey();
                #endregion                
            }
        }
    }
}
