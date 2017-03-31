using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_ASP.Models
{
    public class PersonSharingInitializer : DropCreateDatabaseAlways<PersonSharingContext>
    {
        protected override void Seed(PersonSharingContext context)
        {
            base.Seed(context);

            var adreses = new List<Adres>
            {
                new Adres
                {
                    miasto = "Gdansk",
                    ulica = "Goralska",
                    nrBloku = "41D",
                    nrMieszkania = "5",
                    kodPocztowy = "80-292"
                },
                new Adres
                {
                    miasto = "Warszawa",
                    ulica = "Slowackiego",
                    nrBloku = "54",
                    nrMieszkania = "8",
                    kodPocztowy = "50-292"
                },
                new Adres
                {
                    miasto = "Gdansk",
                    ulica = "Slowackiego",
                    nrBloku = "56",
                    nrMieszkania = "36",
                    kodPocztowy = "80-243"
                },
                new Adres
                {
                    miasto = "Wroclaw",
                    ulica = "Harfowa",
                    nrBloku = "78E",
                    nrMieszkania = "1",
                    kodPocztowy = "30-987"
                },
                new Adres
                {
                    miasto = "Poznan",
                    ulica = "Fardowa",
                    nrBloku = "41",
                    nrMieszkania = "5",
                    kodPocztowy = "23-292"
                }
            };
            adreses.ForEach(s => context.Adreses.Add(s));
            context.SaveChanges();

            var persons = new List<Person>
            {
                new Person
                {
                    imie = "Katarzyna",
                    nazwisko = "Kowalska",
                    pesel = "65456789896",
                    adresId = 2
                },
                new Person
                {
                    imie = "Jan",
                    nazwisko = "Kowalski",
                    pesel = null,
                    adresId = 1
                },
                new Person
                {
                    imie = "Danuta",
                    nazwisko = "Nowak",
                    pesel = "45348789078",
                    adresId = 4
                },
                new Person
                {
                    imie = "Andrzej",
                    nazwisko = "Nowak",
                    pesel = "45326789678",
                    adresId = 3
                },
                new Person
                {
                    imie = "Ewa",
                    nazwisko = "Andrzejewska",
                    pesel = "45748907653",
                    adresId = 5
                }
            };
            persons.ForEach(s => context.Persons.Add(s));
            context.SaveChanges();
        }
    }
}