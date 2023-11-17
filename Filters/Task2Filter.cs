using Microsoft.AspNetCore.Mvc.Filters;

namespace LR10.Filters
{
    public class Task2Filter : Attribute, IAuthorizationFilter
    {

        public int actionCount=0;
        public int totalUsers = 0;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            String line = File.ReadAllText("Task2.txt");
            if (line.Length != 0)
            {
                totalUsers = int.Parse(line);
            }
            else
            {
                totalUsers = 0;
            }

            if (actionCount == 0)
            {
                totalUsers++;
                actionCount++;
                File.WriteAllText("Task2.txt",totalUsers.ToString());
            }
        }
    }
}