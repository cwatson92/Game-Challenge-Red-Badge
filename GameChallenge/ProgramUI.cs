using System;

namespace GameChallenge
{
    class ProgramUI
    {
        private HeroRepository _heroRepo = new HeroRepository();
        private EnemyRepository _enemyRepo = new EnemyRepository();

       public void Run()
        {
            SetUpGame();
            RunGame();
            EndGame();
        }

        private void SetUpGame()
        {
            CreateHero();
            CreateEnemy();
            ShowHeroDetails();
            ShowEnemyDetails();
        }

        private void CreateHero()
        {
            Console.WriteLine("Hello PokeMon Master, What PokeMon do you choose?");

            string name = Console.ReadLine();

            _heroRepo.CreateCharacter(name);
        }

        private void CreateEnemy()
        {
            Console.WriteLine("What is the name of your enemy");

            string name = Console.ReadLine();

            _enemyRepo.CreateCharacter(name);
        }

        private void ShowHeroDetails()
        {
            Console.WriteLine("Here are the details for your PokeMon:\n");

            var hero = _heroRepo.CharacterDetails();

            Console.WriteLine($"Character Details for {hero.Name}" +
                $"Health:{hero.Health}\n" +
                $"Attack:{hero.AttackPower}\n");

        }

        private void ShowEnemyDetails()
        {
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"Character Details for {enemy.Name}" +
                $"Health:{enemy.Health}" +
                $"Attack:{enemy.AttackPower}");
        }

        private void RunGame()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            while (hero.IsAlive && enemy.IsAlive)
            {
                //DO STUFF
                PromptPlayer();

            }
        }

        private void PromptPlayer()
        {
            Console.WriteLine("What would you like to do:\n" +
                "1.Attack\n" +
                "2.Flee\n" +
                "3.Hide\n");
            var input = int.Parse(Console.ReadLine());
            HandleBattleInput(input);
        }

        private void HandleBattleInput(int input)
        {
            switch (input)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Flee();
                    break;
                case 3:
                    Hide();
                    break;
                default:
                    break;
            }
        }

        private void Attack()
        {

            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            _enemyRepo.TakeDamage(hero.AttackPower);

            Console.WriteLine($"{enemy.Name}'s health is {enemy.Health}");
            Console.WriteLine($"{hero.Name}'s attack power is {hero.AttackPower}");
            
        }

        private void Flee()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();

            Console.WriteLine($"{enemy.Name}'s hates fleeing! Fleeing power is {enemy.FleePower}");

            _heroRepo.TakeDamage(enemy.FleePower);

            Console.WriteLine($"{enemy.Name}'s health is {enemy.Health}");
            Console.WriteLine($"{hero.Name}'s health is {hero.Health}");
        }

        private void Hide()
        {
            var hero = _heroRepo.CharacterDetails();
            var enemy = _enemyRepo.CharacterDetails();
            Console.WriteLine($"{enemy.Name}'s health is {enemy.Health}");
            Console.WriteLine($"{hero.Name}'s health is {hero.Health}");

            Console.WriteLine($"{hero.Name}'s Choose to be smart! Hide Power is {hero.HidePower}");
            Console.WriteLine($"{enemy.Name}'s Bit off more they could chew! Hide  power is  {enemy.HidePower}");

            Console.WriteLine("Both opponents live in disgrace!");

            string name = Console.ReadLine();


        }

        private void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}