using AutoFixture;
using AutoFixture.Xunit2;

namespace XUnitDemo.Extensions
{
  public class RegisterUserAttribute : AutoDataAttribute
  {
    public RegisterUserAttribute() : base(() =>
    {
      Fixture fixture = new();
      fixture.Customize<RegisterUserModel>(x => x.With(x => x.Email, "howard.choi@email.com")
                                                 .With(x => x.Password, "12345678"));
      return fixture;
    })
    {

    }
  }
}
