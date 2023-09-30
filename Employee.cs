public class Employee
{
    private string _name;
    private int _id;
    private string _department;
    private decimal _salary;

    public string  Name { get => this._name; set => this._name = value; }
    public int ID { get => this._id; set => this._id = value; }
    public string Department { get => this._department; set => this._department = value; }
    public decimal Salary { get => this._salary; set => this._salary = value; }
   
}