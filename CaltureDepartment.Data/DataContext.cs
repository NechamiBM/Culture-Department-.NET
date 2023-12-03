using CultureDepartment.Core.Entities;

namespace CultureDepartment.Data
{
    public class DataContext
    {
        public List<Event> Events { get; set; }
        public Manager Manager { get; set; }
        public List<Resident> Residents { get; set; }
        public List<Worker> Workers { get; set; }

        public DataContext()
        {
            Events = new List<Event>(){
                new Event(){Name="start",Description="כנס פתיחה"},
                new Event(){Name="Rosh Hashana",Description="כנס לקראת ראש השנה"}
            };
            Manager = new Manager();
            Residents = new List<Resident>(){
                    new Resident("326679313",new DateOnly(2004,07,21)){FirstName="נחמי",LastName="בן מנחם", Street="בלז", NumBuilding=13,Phone="035783598" },
                    new Resident("325749315",new DateOnly(2004,01,23)){FirstName="שבי",LastName="אורנשטיין",Street="קוטלר", NumBuilding=12 ,Phone="036198243" }
            };
            Workers = new List<Worker>(){
                    new Worker(){ TZ="123456789",FirstName="Chaim",LastName="Choen",IsResident=true },
                    new Worker(){ TZ="123456798",FirstName="Moshe",LastName="Levi",IsResident=false }
            };
        }
    }
}
