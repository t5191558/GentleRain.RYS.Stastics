using Newtonsoft.Json;

namespace GentleRain.RYS.Statistic.Administration;
public class RolePermissionUpdateRequest : ServiceRequest
{
    public int? RoleID { get; set; }
    public List<string> Permissions { get; set; }
}