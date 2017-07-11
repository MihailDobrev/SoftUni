namespace _04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ForthProblem
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            Dictionary<string, Pokemon> pokemons = new Dictionary<string, Pokemon>();


            while (inputLine != "wubbalubbadubdub")
            {
                string[] inputWithPokemons = inputLine
                    .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string pokemonName = inputWithPokemons[0];

                string evolutionType = "";
                int evolutionIndex = 0;

               
                if (inputWithPokemons.Length == 3)
                {
                    evolutionType = inputWithPokemons[1];
                    evolutionIndex = int.Parse(inputWithPokemons[2]);

                    if (!pokemons.ContainsKey(pokemonName))
                    {
                        pokemons[pokemonName] = new Pokemon()
                        {
                            Name = pokemonName,
                            EvolutionTypes = new List<string>(),
                            EvolutionIndexes = new List<int>()

                        };
                     
                    }
                    pokemons[pokemonName].EvolutionTypes.Add(evolutionType);
                    pokemons[pokemonName].EvolutionIndexes.Add(evolutionIndex);
                }
                else if (inputWithPokemons.Length == 1)
                {
                    if (pokemons.ContainsKey(pokemonName))
                    {
                        Console.WriteLine($"# {pokemonName}");
                        for (int i = 0; i < pokemons[pokemonName].EvolutionIndexes.Count; i++)
                        {
                            Console.WriteLine($"{pokemons[pokemonName].EvolutionTypes[i]} <-> {pokemons[pokemonName].EvolutionIndexes[i]}");
                        }
                    }

                }

                inputLine = Console.ReadLine();              
            }
            

            foreach (var pokemonPair in pokemons)
            {
                string name = pokemonPair.Key;
                Pokemon pokemon = pokemonPair.Value;

                var orderedZip = pokemons[name].EvolutionIndexes.Zip(pokemons[name].EvolutionTypes, (x, y) => new { x, y })
                     .OrderByDescending(pair => pair.x)
                     .ToList();
                pokemons[name].EvolutionIndexes = orderedZip.Select(pair => pair.x).ToList();
                pokemons[name].EvolutionTypes = orderedZip.Select(pair => pair.y).ToList();


                Console.WriteLine($"# {name}");

                for (int i = 0; i < pokemon.EvolutionIndexes.Count; i++)
                {
                    Console.WriteLine($"{pokemons[name].EvolutionTypes[i]} <-> {pokemons[name].EvolutionIndexes[i]}");
                }
            }

        }
    }
    class Pokemon
    {
        public string Name { get; set; }

        public List<string> EvolutionTypes { get; set; }

        public List<int> EvolutionIndexes { get; set; }
    }
}
