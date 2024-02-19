
namespace GentleRain.RYS.Statistic;

public interface IDirectoryService
{
    AppServices.DirectoryEntry Validate(string username, string password);
}