namespace _11.Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            string input;
            Dictionary<string,Trainer> trainers = new Dictionary<string, Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArgs = input.Split();
                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = trainer;
                }
                
                    trainers[trainerName].Pokemons.Add(pokemon);
               
            }
            while ((input = Console.ReadLine()) != "End")
            {
                string command = input;

                foreach (var trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                           
                        }
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            var sortedTrainers = trainers.Values.OrderByDescending(t => t.NumberOfBadges).ToList();

            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
