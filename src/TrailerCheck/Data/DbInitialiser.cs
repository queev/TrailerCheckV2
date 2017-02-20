using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrailerCheck.Data;

namespace TrailerCheck.Models
{
    public static class DbInitialiser
    {
        public static void Initialise(TrailerCheckContext context)
        {
            context.Database.EnsureCreated();

            //Look for any owners
            if (context.Trailers.Any())
            {
                return;     //DB seeded
            }

            var trailers = new Trailer[]
            {
                new Trailer {TrailerID=709652, Model="DP120", Description="DP120 12' x 6'6\" x 6' Deck Tank & Front Flap"},
                new Trailer {TrailerID=709231, Model="P8e", Description="P8e 8'2\" x 4'9\" Ramp 750kg"},
                new Trailer {TrailerID=5136308, Model="LM105", Description="LM105 10' x 5'6\" Resin with Dropsides 2700kg"},
                new Trailer {TrailerID=5136306, Model="LM85", Description="LM85 8' x 5' Resin with Dropsides 2700kg"},
                new Trailer {TrailerID=5136307, Model="LM85", Description="LM85 8' x 5' Resin with Dropsides 2700kg"},
                new Trailer {TrailerID=710761, Model="CT166", Description="CT166 16' x 6'6\" Resin with Dropsides 3ft Ramp 3500kg"},
                new Trailer {TrailerID=710530, Model="GP106", Description="GP106 10' x 5'10\" Resin Low Side 175 x 16"}
            };
            foreach (Trailer t in trailers)
            {
                context.Trailers.Add(t);
            }
            context.SaveChanges();

            var owners = new Owner[]
            {
                new Owner {FirstName="Carson", LastName="Alexander", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Meredith", LastName="Alonso", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Arturo", LastName="Anand", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Gytis", LastName="Barzdukas", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Yan", LastName="Li", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Peggy", LastName="Justice", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Laura", LastName="Norman", RegistrationDate=DateTime.Parse("2017-02-20")},
                new Owner {FirstName="Nino", LastName="Olivetto", RegistrationDate=DateTime.Parse("2017-02-20")},
            };
            foreach (Owner o in owners)
            {
                context.Owners.Add(o);
            }
            context.SaveChanges();

            var registrations = new Registration[]
            {
                new Registration {OwnerID=1, TrailerID=709652},
                new Registration {OwnerID=1, TrailerID=709231},
                new Registration {OwnerID=1, TrailerID=5136308},
                new Registration {OwnerID=2, TrailerID=5136306},
                new Registration {OwnerID=2, TrailerID=5136307},
                new Registration {OwnerID=2, TrailerID=710761},
                new Registration {OwnerID=3, TrailerID=709652},
                new Registration {OwnerID=4, TrailerID=709652},
                new Registration {OwnerID=4, TrailerID=709231},
                new Registration {OwnerID=5, TrailerID=5136306},
                new Registration {OwnerID=6, TrailerID=710761},
                new Registration {OwnerID=7, TrailerID=710530}
            };
            foreach (Registration r in registrations)
            {
                context.Registrations.Add(r);
            }
            context.SaveChanges();
        }
    }
}
