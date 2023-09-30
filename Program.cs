



class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }



    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }

    // Build Attack method
    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}

class Wizard : Human
{
    public Wizard(string name, int str, int dex) : base(name, str, 25, dex, 50)
    {
    }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        //Cura al Wizard
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
    public void Heal(Human target){
        int heal = Intelligence * 3;
        target.Health += heal;
        Console.WriteLine($"{Name} Curo a {target.Name} por la cantidad de {heal} Vida");
    }

}
class Ninja : Human
{
    public Ninja(string name, int str, int intel, int hp) : base(name, str, intel, 75, hp)
    {
    }
    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");

        Random rand = new Random();
        int probabilidad = rand.Next(0,100);
        if(probabilidad < 20){
            int dmgextra = 10;
            Console.WriteLine($"{Name} a obtenido un golpe critico sobre el objetivo {target.Name} por la cantidad de {dmgextra}");
            target.Health -= dmgextra;
        }

        return target.Health;
    }
    public void Steal(Human target){
        target.Health -= 5;
        Health += 5;
    }
}
class Samurai : Human
{
    public Samurai(string name, int str, int intel, int dex) : base(name, str, intel, dex, 200)
    {
    }
    public override int Attack(Human target)
    {
        base.Attack(target);
        if(target.Health < 50){
            target.Health = 0;
        }
        Console.WriteLine("Ataque letal.");
        return target.Health;
    }
    public void Meditate(){
        Console.WriteLine("Comienza a meditar");
        Health = 200;
    }
}