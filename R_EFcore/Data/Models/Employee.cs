namespace R_EFcore.Data.Models
{
    //poco class=>[plain pld clr object]

    //we have 4 ways to map classes into table
    //1-by convention [default behavior]
    internal class Employee
    {
        public int Id { get; set; }//public numeric property named as "Id", "EmployeeId"="classnameId" => pk identity (1,1)
        public string? Name { get; set; }//nvarchar(max)
                                         //nullable<string>
        public double Salary { get; set; }//float
        public int? age { get; set; }//nullable<int>
    }
}
