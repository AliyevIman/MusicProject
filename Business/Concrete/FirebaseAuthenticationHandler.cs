//using FirebaseAdmin;
//using FirebaseAdmin.Auth;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using Microsoft.Identity.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;
//using System.Threading.Tasks;

//namespace Business.Concrete
//{
//    public class FirebaseAuthenticationHandler :AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        private readonly FirebaseApp _firebaseApp;
//        public FirebaseAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, FirebaseApp firebaseApp)
//            : base(options, logger, encoder, clock)
//        {
//            _firebaseApp = firebaseApp;
//        }


//        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            if (!Context.Request.Headers.ContainsKey("Authorization"))
//            {
//                return AuthenticateResult.NoResult();
//            }
//          string barerToken=   Context.Request.Headers["Authorization"];
//            if (barerToken ==null || !barerToken.StartsWith("Bearer"))
//            {
//                return AuthenticateResult.Fail("Invalid scheme");
//            }

//            string token = barerToken.Substring("Bearer".Length);

//           FirebaseToken firebaseToken= await FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token);

//            return AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new List<ClaimsIdentity>() 
//            {
//                new ClaimsIdentity(ToClaims(firebaseToken.Claims))
//            })));
//        }
//        private IEnumerable<Claim> ToClaims(IReadOnlyDictionary<string, object> claims)
//        {
//            return new List<Claim>
//            {

//            };
//        }
//    }
//}
