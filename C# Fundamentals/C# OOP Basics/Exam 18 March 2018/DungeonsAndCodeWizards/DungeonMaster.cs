namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Characters;
    using DungeonsAndCodeWizards.Factories;
    using DungeonsAndCodeWizards.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        #region Fields
        private List<Character> characterParty;
        private List<Item> itemPool;
        private int lastSurvivorRounds;
        #endregion

        #region Properties
        public bool isGameOver { get; private set; }
        public Character[] sortedCharactersAlive => this.characterParty.Where(c => c.IsAlive).ToArray();

        #endregion

        #region Constructors
        public DungeonMaster()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
            lastSurvivorRounds = 0;
            isGameOver = false;
        }
        #endregion

        #region Methods
        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];
            CharacterFactory characterFactory = new CharacterFactory();
            var character = characterFactory.CreateCharacter(faction, characterType, name);
            characterParty.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            ItemFactory itemFactory = new ItemFactory();
            var item = itemFactory.CreateItem(itemName);
            itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var searchedCharacter = CheckCharacter(characterName);

            if (!itemPool.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            var item = itemPool.Last();
            itemPool.RemoveAt(itemPool.Count - 1);
            searchedCharacter.ReceiveItem(item);

            return $"{searchedCharacter.Name} picked up {item.Name}!";
        }

        private Character CheckCharacter(string characterName)
        {
            var searchedCharacter = this.characterParty.FirstOrDefault(c => c.Name == characterName);

            if (searchedCharacter == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            return searchedCharacter;
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var searchedCharacter = CheckCharacter(characterName);

            searchedCharacter.UseItem(searchedCharacter.Bag.GetItem(itemName));

            return $"{searchedCharacter.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            Character giverCharacter, receiverCharacter;
            Item item;
            GetCharactersAndItem(args, out giverCharacter, out receiverCharacter, out item);
            giverCharacter.UseItemOn(item, receiverCharacter);

            return $"{giverCharacter.Name} used {item.Name} on {receiverCharacter.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            Character giverCharacter, receiverCharacter;
            Item item;
            GetCharactersAndItem(args, out giverCharacter, out receiverCharacter, out item);
            giverCharacter.GiveCharacterItem(item, receiverCharacter);

            return $"{giverCharacter.Name} gave {receiverCharacter.Name} {item.Name}.";
        }

        private void GetCharactersAndItem(string[] args, out Character giverCharacter, out Character receiverCharacter, out Item item)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            giverCharacter = CheckCharacter(giverName);
            receiverCharacter = CheckCharacter(receiverName);
            item = giverCharacter.Bag.GetItem(itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            var sortedCharacters = this.characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);
            foreach (var character in sortedCharacters)
            {
                string isAlive = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {isAlive}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var searchedAttacker = CheckCharacter(attackerName);
            var searchedReceiver = CheckCharacter(receiverName);


            if (!(searchedAttacker is Warrior))
            {
                throw new ArgumentException($"{searchedAttacker.Name} cannot attack!");
            }
            var attacker = (Warrior)searchedAttacker;
            attacker.Attack(searchedReceiver);

            string result = $"{attackerName} attacks {receiverName} for {searchedAttacker.AbilityPoints} hit points! {receiverName} has {searchedReceiver.Health}/{searchedReceiver.BaseHealth} HP and {searchedReceiver.Armor}/{searchedReceiver.BaseArmor} AP left!";

            if (!searchedReceiver.IsAlive)
            {
                result += Environment.NewLine + $"{searchedReceiver.Name} is dead!";
            }
            return result;

        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var searchedHealer = CheckCharacter(healerName);
            var searchedHealingReceiver = CheckCharacter(healingReceiverName);

            if (!(searchedHealer is Cleric))
            {
                throw new ArgumentException($"{searchedHealer.Name} cannot heal!");
            }
            var healer = (Cleric)searchedHealer;
            healer.Heal(searchedHealingReceiver);

            return $"{searchedHealer.Name} heals {searchedHealingReceiver.Name} for {healer.AbilityPoints}! {searchedHealingReceiver.Name} has {searchedHealingReceiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.sortedCharactersAlive)
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }
            if (this.sortedCharactersAlive.Length == 1 || sortedCharactersAlive.Length == 0)
            {
                lastSurvivorRounds++;
                if (lastSurvivorRounds > 1)
                {
                    isGameOver = true;
                }
            }
            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds > 1)
            {
                return true;
            }
            return false;
        }
        #endregion


    }
}
