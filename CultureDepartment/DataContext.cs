using CultureDepartment.Entities;

namespace CultureDepartment
{
    public class DataContext
    {
        public List<Event> Events;
        public Manager Manager;
        public List<Resident> Residents;
        public List<Worker> Workers;

        public DataContext()
        {
            Events = new List<Event>(){
                new Event(){Name="start",Description="כנס פתיחה"},
                new Event(){Name="Rosh Hashana",Description="כנס לקראת ראש השנה"}
            };
            Manager = new Manager();
            Residents = new List<Resident>(){
                    new Resident("326679313"){FirstName="נחמי",LastName="בן מנחם",Age=19, Street="בלז", NumBuilding=13,Phone="035783598" },
                    new Resident("325749315"){FirstName="שבי",LastName="אורנשטיין",Age=19,Street="קוטלר", NumBuilding=12 ,Phone="036198243" }
            };
            Workers = new List<Worker>(){
                    new Worker(){ TZ="123456789",FirstName="Chaim",LastName="Choen",IsResident=true },
                    new Worker(){ TZ="123456798",FirstName="Moshe",LastName="Levi",IsResident=false }
            };
        }
    }
}
