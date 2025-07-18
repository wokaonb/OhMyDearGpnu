using OhMyDearGpnu.Api.Cas;
using OhMyDearGpnu.Api.Modules;

namespace OhMyDearGpnu.Api.Test;

public class LearnTeset
{
    [SetUp]
    public void Init()
    {
    }

    [Test]
    [Timeout(300000)]
    public async Task RespsetTest()
    {
        var cline = new GpnuClient();
        var casHandler = cline.cas;

        try
        {
            var context = await casHandler.CreateWechatLoginContext();
            var casLoginRes = await casHandler.LoginByWechat(context);
        }
        catch (CasLoginFailException e)
        {
            Console.WriteLine($"cas 登录失败，原因：{e.Message}");
            throw;
        }

        Console.WriteLine($"cas 登录成功，TGT为{casHandler.Tgt}");
    }
}