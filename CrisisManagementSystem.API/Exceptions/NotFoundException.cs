namespace CrisisManagementSystem.API.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, string key):base($"{name} and {key} not found")
        {

        }
    }
}
