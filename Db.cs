namespace Bugtracker.DB
{
    public record Bug
    {
        public int Id { get; set; }
        public string ? Title {get;set;}
    }

    public class BugDB{
        public static List<Bug> _bugs = new List<Bug>(){
            new Bug{Id=1, Title="Photo - Click to open gallery." },
            new Bug{Id=2, Title="Push Notification - Crashing." },
            new Bug{Id=3, Title="Change Buttons." }

        };

        public static List<Bug> GetBugs(){
            return _bugs;
        }

        public static Bug ? GetBug(int id){
            return _bugs.SingleOrDefault(bug => bug.Id == id);
        }

        public static Bug CreateBug(Bug bug){
            _bugs.Add(bug);

            return bug;
        }

        public static Bug UpdateBug(Bug update){
            _bugs = _bugs.Select(bug =>{
                if(bug.Id == update.Id){
                    bug.Title = update.Title;
                }
                
                return bug;

            }).ToList();

            return update;
        }

        public static void RemoveBug(int id){
            _bugs = _bugs.FindAll(bug => bug.Id == id).ToList();
        }


 
    }

  
}