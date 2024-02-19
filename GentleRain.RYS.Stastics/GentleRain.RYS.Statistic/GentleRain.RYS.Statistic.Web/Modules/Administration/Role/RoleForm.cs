namespace GentleRain.RYS.Statistic.Administration.Forms;

[FormScript("Administration.Role")]
[BasedOnRow(typeof(RoleRow), CheckNames = true)]
public class RoleForm
{
    public string RoleName { get; set; }
}