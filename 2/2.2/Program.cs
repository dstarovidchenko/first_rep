Apartment ap181 = new Apartment(181, 14);
Tenant denis = new Tenant("Денис", 20, "Студент");
Tenant pavel = new Tenant("Павел", 23, "Неизвестно/студент");
//копирование структуры
Tenant anton = denis.CopyWithName("Антон");



ap181.AddTenant(denis);
ap181.ShowInfo();
ap181.AddTenant(pavel);
ap181.AddTenant(anton);
ap181.ShowInfo();
ap181.RemoveTenant("Павел");
//особенности значимового типа
denis.Job = "Миллионер";
ap181.ShowInfo();
ap181.UpdateTenant("Денис", 25, "Миллионер");
ap181.ShowInfo();
//особенности ссылочного типа
Apartment ap180 = ap181;
ap181.ShowInfo();
ap180.ShowInfo();
ap180.AddTenant(pavel);
ap181.ShowInfo();
ap180.ShowInfo();
//копирование класса
Apartment ap1 = ap181.DeepCopy(1, 1);
ap1.ShowInfo();
ap1.AddTenant(denis);
ap1.ShowInfo();
ap181.ShowInfo();





struct Tenant
{
    public string Name;
    public int Age;
    public string Job;
    //конструктор
    public Tenant(string name, int age, string job)
    {
        Name = name;
        Age = age;
        Job = job;
    }

    //методы
    //копирование
    public Tenant CopyWithName(string newName)
    {
        return(this with { Name =  newName });
    }
    public Tenant CopyWithAge(int newAge)
    {
        return (this with { Age = newAge });
    }
    public Tenant CopyWithJob(string newJob)
    {
        return (this with { Job = newJob });
    }

}
class Apartment
{
    //поля
    private int number;
    private int floor;
    private int quantity;
    private List<Tenant> tenants;

    //конструктор
    public Apartment(int number, int floor)
    {
        this.number = number;
        this.floor = floor;
        quantity = 0;
        tenants = new List<Tenant>();
    }

    //свойства
    public int Number { get { return number; } }
    public int Floor { get { return floor; } }
    public int Quantity { get { return quantity; } }

    //методы
    //добавление жильца
    public void AddTenant(Tenant tenant)
    {
        tenants.Add(tenant);
        quantity++;
    }

    //удаление жильца
    public void RemoveTenant(string name)
    {
        tenants.RemoveAll(t => t.Name == name);
        quantity--;
    }

    //обновление информации о жильце
    public void UpdateTenant(string name, int age, string job)
    {
        Tenant tenant = tenants.Find(t => t.Name == name);
        int index = tenants.IndexOf(tenant);
        tenant.Age = age;
        tenant.Job = job;
        tenants.RemoveAt(index);
        tenants.Insert(index, tenant);


    }

    //вывод информации по квартире
    public void ShowInfo()
    {
        Console.WriteLine($"Квартира №{number} на {floor} этаже");
        Console.WriteLine($"Количество жильцов: {quantity}");
        Console.WriteLine("Жильцы:");
        foreach (var tenant in tenants)
        {
            Console.WriteLine($"\t{tenants.IndexOf(tenant) + 1}. Имя:{tenant.Name} Возраст:{tenant.Age} Работа:{tenant.Job}");
        }
        Console.WriteLine("\n==========================================================================================");
    }

    //копирование
    public Apartment ShallowCopy(int otherNumber, int otherFloor)
    {
        Apartment copy = (Apartment)this.MemberwiseClone();
        copy.number = otherNumber;
        copy.floor = otherFloor;
        return copy;
    }
    public Apartment DeepCopy(int otherNumber, int otherFloor)
    {
        Apartment copy = (Apartment)this.MemberwiseClone();
        copy.number = otherNumber;
        copy.floor = otherFloor;
        copy.tenants = new List<Tenant>();
        foreach (var tenant in tenants)
        {
            copy.tenants.Add(tenant);
        }
        return copy;
    }
 
}
