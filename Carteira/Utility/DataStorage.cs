﻿using Carteira.Models;
using System.Collections.Generic;

namespace Carteira.Utility
{
    public static class DataStorage
    {
        public static List<Employee> GetEmployees() =>
            new List<Employee>
            {
                new Employee{ Name="Primeiro", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Segundo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Terceiro", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Quarto", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="Quinto", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Sexto", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Setimo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Oitavo", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Nono", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="Decimo", LastName="Doe", Age=45, Gender="Male"},

                new Employee{ Name="2 - Primeiro", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="2 - Segundo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="2 - Terceiro", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="2 - Quarto", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="2 - Quinto", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="2 - Sexto", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="2 - Setimo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="2 - Oitavo", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="2 - Nono", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="2 - Decimo", LastName="Doe", Age=45, Gender="Male"},

                new Employee{ Name="3 - Primeiro", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="3 - Segundo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="3 - Terceiro", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="3 - Quarto", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="3 - Quinto", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="3 - Sexto", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="3 - Setimo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="3 - Oitavo", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="3 - Nono", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="3 - Decimo", LastName="Doe", Age=45, Gender="Male"},

                new Employee{ Name="4 - Primeiro", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="4 - Segundo", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="4 - Terceiro", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Ultimo", LastName="Martins", Age=40, Gender="Male"},

                //Gerar Segunda Página;
                new Employee{ Name="Primeiro da Segunda página", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"},
                new Employee{ Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                new Employee{ Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee{ Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee{ Name="Sofia", LastName="Packner", Age=30, Gender="Female"},
                new Employee{ Name="John", LastName="Doe", Age=45, Gender="Male"}
            };
    }
}
