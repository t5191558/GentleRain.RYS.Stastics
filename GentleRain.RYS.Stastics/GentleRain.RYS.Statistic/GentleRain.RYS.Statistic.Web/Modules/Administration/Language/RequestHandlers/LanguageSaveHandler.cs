using MyRequest = Serenity.Services.SaveRequest<GentleRain.RYS.Statistic.Administration.LanguageRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = GentleRain.RYS.Statistic.Administration.LanguageRow;


namespace GentleRain.RYS.Statistic.Administration;
public interface ILanguageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
public class LanguageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageSaveHandler
{
    public LanguageSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}