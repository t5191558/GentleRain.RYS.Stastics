using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<GentleRain.RYS.Statistic.Administration.LanguageRow>;
using MyRow = GentleRain.RYS.Statistic.Administration.LanguageRow;


namespace GentleRain.RYS.Statistic.Administration;
public interface ILanguageListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LanguageListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageListHandler
{
    public LanguageListHandler(IRequestContext context)
         : base(context)
    {
    }
}