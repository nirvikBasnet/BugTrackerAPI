using Microsoft.EntityFrameworkCore;

namespace Bugtracker.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string? Title {get;set;}
        public string? Description {get;set;}
    }

    class BugDb : DbContext
    {
        public BugDb(DbContextOptions options) : base(options){}
        public DbSet<Bug> Bugs {get;set;}
    }

    // public class BugDB{
    //     public static List<Bug> _bugs = new List<Bug>();

    //     public static List<Bug> GetBugs(){
    //         return _bugs;
    //     }

    //     public static Bug ? GetBug(int id){
    //         return _bugs.SingleOrDefault(bug => bug.Id == id);
    //     }

    //     public static Bug CreateBug(Bug bug){
    //         _bugs.Add(bug);

    //         return bug;
    //     }

    //     public static Bug UpdateBug(Bug update){
    //         _bugs = _bugs.Select(bug =>{
    //             if(bug.Id == update.Id){
    //                 bug.Title = update.Title;
    //             }
                
    //             return bug;

    //         }).ToList();

    //         return update;
    //     }

    //     public static void RemoveBug(int id){
    //        _bugs = _bugs.Where(bug => bug.Id != id).ToList();
    //     }


 
    // }

  
}