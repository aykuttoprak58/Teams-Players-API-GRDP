using BusinessLayer.Concrete;
using EntityLayer;

class Program
{
     static void Main(string[] args)
    {
     

        TeamService aa = new TeamService();

        List<Teams> oyuncu  = new List<Teams>() { new() {TeamId=1, TeamName="a",PlayerId=1 } };    


        foreach (var item in aa.GetAll())
        {
            Console.WriteLine("takımid" + item.TeamId + "takım adı" + item.TeamName + "playerid" + item.PlayerId);
        }

        Console.WriteLine("DSADAS");
  
    }
}