#region FullTimeEmployee
FullTimeEmployee fullTimeEmployee1 = new FullTimeEmployee();
fullTimeEmployee1.FullName = "Name Surname Patronymic";
fullTimeEmployee1.Position = "Director";

while (true)
{
    if (fullTimeEmployee1.Salary == 0)
    {
        Console.WriteLine("Введите зарплату: ");
        fullTimeEmployee1.Salary = Convert.ToDouble(Console.ReadLine());
    }
    else if (fullTimeEmployee1.Bonus == 0)
    {
        Console.WriteLine("Введите бонус: ");
        fullTimeEmployee1.Bonus = double.Parse(Console.ReadLine());
    }
    else break;
}
double resultFullTimeSalary = fullTimeEmployee1.CalculateSalary();
Console.WriteLine($"Итоговая зарплата: {resultFullTimeSalary}");
#endregion

#region ContractEmployee
ContractEmployee contractEmployee1 = new ContractEmployee();
contractEmployee1.FullName = "Name Surname Patronymic";
contractEmployee1.Position = "Officiant";

while (true)
{
    if (contractEmployee1.Salary == 0)
    {
        Console.WriteLine("Введите зарплату сотруднику по удаленке: ");
        contractEmployee1.Salary = Convert.ToDouble(Console.ReadLine());
    }
    else break;
}
double resultContractSalary = contractEmployee1.CalculateSalary();
Console.WriteLine($"Итоговая зарплата: {resultContractSalary}");
#endregion













/// <summary>
/// Класс компании
/// </summary>
public class Company
{
    /// <summary>
    /// Имя компании
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Список отделов
    /// </summary>
    List<Department> Departments { get; set; } = new List<Department>();
}
/// <summary>
/// Класс отдела в компании
/// </summary>
public class Department
{
    /// <summary>
    /// Название отдела
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Количество сотрудников в отделе
    /// </summary>
    public int CountOfEmployee { get; set; }
}

/// <summary>
/// Класс сотрудника
/// </summary>
public class Employee
{
    /// <summary>
    /// Фамилия, имя, отчество сотрудника
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// Должность сотрудника
    /// </summary>
    public string Position { get; set; }

    private double _salary;
    /// <summary>
    /// Зарплата сотрудника
    /// </summary>
    public double Salary {
        get { return _salary; }
        set {
            try
            {
                if (value < 0)
                {
                    throw new ArgumentException("Введена отрицательная зарплата");
                }
                else
                {
                    _salary = value;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    /// <summary>
    /// Метод по подсчету зарплаты сотрудника
    /// </summary>
    /// <returns>Зарплата сотрудника</returns>
    public double CalculateSalary()
    {
        return Salary;
    }
}
/// <summary>
/// Класс штатного сотрудника
/// </summary>
public class FullTimeEmployee : Employee 
{
    /// <summary>
    /// Поле бонус
    /// </summary>
    private double _bonus;

    public double Bonus {
        get 
        { 
            return _bonus;
        }
        set 
        {
            try
            {
                if (value < 0)
                {
                    throw new BonusException("Введён отрицательный бонус", value);
                }
                else _bonus = value;
                
            }
            catch (BonusException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine($"Значение, которое вызвало ошибку: {ex.BonusError}");
            }
            
        } 
    }
    /// <summary>
    /// Метод по расчету зарплаты ЗП штатного сотрудника
    /// </summary>
    /// <returns></returns>
    public double CalculateSalary()
    {
        return Salary + Bonus;
    }
}
/// <summary>
/// Класс сотрудника в удаленке
/// </summary>
public class ContractEmployee : Employee
{
    /// <summary>
    /// Метод по расчету зарплаты ЗП сотрудника по удаленке
    /// </summary>
    /// <returns></returns>
    public double CalculateSalary()
    {
        //TODO: ЗП сотрудника по удаленке
        return Salary + (Salary / 100);
    }
}


public class BonusException : Exception
{
    public double BonusError { get; set; }
    public BonusException(string message, double error) : base(message)
    {
        BonusError = error;
    }
}