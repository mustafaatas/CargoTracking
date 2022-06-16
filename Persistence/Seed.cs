using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Dealers.Any()) return;
            var dealers = new List<Dealer>
            {
                new Dealer{Adress="İzmir Karabağlar", ZIPCode=35120},
                new Dealer{Adress="İzmir Buca", ZIPCode=35150},
                new Dealer{Adress="İzmir Bornova", ZIPCode=35280},
                new Dealer{Adress="Manisa Merkez", ZIPCode=45120},
                new Dealer{Adress="Ankara Çankaya", ZIPCode=06050},
                new Dealer{Adress="İstanbul Ümraniye", ZIPCode=34190},
                new Dealer{Adress="İstanbul Kartal", ZIPCode=34330},
                new Dealer{Adress="İstanbul Beylükdüzü", ZIPCode=34650}
            };

            await context.Dealers.AddRangeAsync(dealers);

            if (context.Adresses.Any()) return;
            var adresses = new List<Adress>
            {
                new Adress{City="İzmir", District="Karşıyaka", Description="Çarşı Cadde no:10 daire:2", ZIPCode=35560},
                new Adress{City="İzmir", District="Bornova", Description="Ziraat Cadde no:20 daire:5", ZIPCode=35280},
                new Adress{City="İzmir", District="Karabağlar", Description="Okul Cadde no:15 daire:1", ZIPCode=35120},
                new Adress{City="Manisa", District="Merkez", Description="Pazar Cadde no:1 daire:40", ZIPCode=45120},
                new Adress{City="Manisa", District="Turgutlu", Description="Fakülte Cadde no:200 daire:11", ZIPCode=45150},
                new Adress{City="İstanbul", District="Esenyurt", Description="Merkez Cadde no:10 daire:2", ZIPCode=45120},
                new Adress{City="İstanbul", District="Beylikdüzü", Description="Ziya Paşa Cadde no:10/A daire:7", ZIPCode=34650},
                new Adress{City="Ankara", District="Çankaya", Description="Deniz Cadde no:17 daire:21", ZIPCode=06050}
            };

            await context.Adresses.AddRangeAsync(adresses);

            if (context.Employees.Any()) return;
            var employees = new List<Employee>
            {
                new Employee{Name="Mustafa Ataş"},
                new Employee{Name="Ahmet Aydın"},
                new Employee{Name="Ayşe Karaca"},
                new Employee{Name="Aslı Akas"},
                new Employee{Name="Eylül Beştaş"},
                new Employee{Name="Ferdi Yalçın"},
                new Employee{Name="Hilmi Duran"},
                new Employee{Name="İrfan Şen"},
                new Employee{Name="Yusuf Topal"}
            };

            await context.Employees.AddRangeAsync(employees);

            if (context.Cargos.Any()) return;
            var cargos = new List<Cargo>
            {
                new Cargo{Status=true},
                new Cargo{Status=false},
                new Cargo{Status=true},
                new Cargo{Status=true},
                new Cargo{Status=true},
            };

            await context.Cargos.AddRangeAsync(cargos);

            await context.SaveChangesAsync();
        }
    }
}
