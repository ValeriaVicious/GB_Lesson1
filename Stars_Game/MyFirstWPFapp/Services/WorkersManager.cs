using MyFirstWPFapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFapp.Services
{
    class WorkersManager
    {
        public List<Departaments> Departaments { get; private set; }
        public WorkersManager()
        {
            int workers_id = 1;
            Departaments = Enumerable.Range(1, 5)
                .Select(i => new Departaments
                {
                    Id = i,
                    Workers = Enumerable.Range(1, 5).
                    Select(j => new Workers
                    {
                        Id = workers_id,
                        Name = $"Name {workers_id}",
                        Surname = $"Surname {workers_id}",
                        Age = workers_id,
                        Salary = workers_id

                    }).ToList()
                })
                .ToList();

            foreach (Departaments departament in Departaments)
                foreach (Workers workers in departament.Workers)
                    workers.Departaments = departament;
        }
    }
}
