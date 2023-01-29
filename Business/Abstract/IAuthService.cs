using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //public async Task<User> Authenticate(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        //{
        //    await Task.Delay(1);
        //    return this.FindUserOrAdd(payload);
        //}

        //private User FindUserOrAdd(Google.Apis.Auth.GoogleJsonWebSignature.Payload payload)
        //{
        //    var u = _users.Where(x => x.email == payload.Email).FirstOrDefault();
        //    if (u == null)
        //    {
        //        u = new User()
        //        {
        //            Id = Guid.NewGuid(),
        //            UserName = payload.Name,
        //            Email = payload.Email,
        //            oauthSubject = payload.Subject,
        //            oauthIssuer = payload.Issuer
        //        };
        //        _users.Add(u);
        //    }
        //    this.PrintUsers();
        //    return u;
        //}
    }
}
